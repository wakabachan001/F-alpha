using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // Start is called before the first frame update
    public class PlayerManager : MonoBehaviour
    {
    public float speed = 1.0f;      //�ړ�����
    public float shotSpeed = 0.2f;  //�藠���̑��x
    public float playerHP = 4.0f;   //�v���C���[�̗̑�
    public float HPcount;
    
    public float EffectLimit;       //�ߋ����U���̔��肪�c�鎞��
    public float ShotLimit = 3.5f;  //�������U���̔򋗗��̏��
    public float ShotLange;        //�������U���̔򋗗�
    public float SwordDamage = 2.0f;     //�ߋ����U���_���[�W
    public float SyurikenDamage = 1.5f;  //�������U���_���[�W

    public float leftLimit = 1.0f;  //�N���ł��鍶�̌��E
    public float rightLimit = 5.0f; //�N���ł���E�̌��E
    public float upLimit = 20.0f;   //�N���ł����̌��E
    public float HPposX = 1.0f;
    public float HPposY = 1.0f;

    bool onAttack = false;      //�ߋ����U���t���O
    bool onShot = false;        //�������U���t���O
    bool onBottomColumn = true; //����ɂ��邩�ǂ���
    private float time; //���Ԍv���p

    public GameObject AttackEffect; //�ߋ����U��
    public GameObject ShotEffect;   //�������U��

    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        //�v���C���[���W�̎擾
        Vector2 position = transform.position;

        //�ړ�(��O�ɂ����Ȃ��悤�ɂ���)
        if (Input.GetKeyDown("left") && 
            position.x > leftLimit)
        {
            position.x -= speed;
        }
        if (Input.GetKeyDown("right") && 
            position.x < rightLimit)
        {
            position.x += speed;
        }
        if (Input.GetKeyDown("up") && 
            position.y < upLimit)
        {
            position.y += speed;
            onBottomColumn = false;
        }
        if (Input.GetKeyDown("down") && 
            !onBottomColumn)
        {
            position.y -= speed;
            onBottomColumn = true;  //��ގ��ɉ���ɂ��邱�Ƃɂ���
        }
        

        transform.position = position;  //���W�̍X�V

        //�ߋ����U��
        if (Input.GetKeyDown(KeyCode.Space) && !onAttack && !onShot)//�U���J�n��(Space�L�[�������ƍU���J�n)
        {
            //�v���C���[�̑O���ɍU���G�t�F�N�g�̃N���[������
            Instantiate(AttackEffect, transform.position + transform.up, Quaternion.identity);

            time = 0.0f;        //���Ԃ̃��Z�b�g
            onAttack = true;    //�U���t���O�I��
        }

        //�������U��
        if (Input.GetKeyDown(KeyCode.LeftShift) && !onAttack && !onShot)//�U���J�n��(Space�L�[�������ƍU���J�n)
        {
            //���݂����ɂ���Ĕ򋗗���ύX
            if (onBottomColumn)
                ShotLange = ShotLimit;
            else
                ShotLange = ShotLimit - 1.0f;

            //�v���C���[�̈ʒu�Ɏ藠���̃N���[������
            Instantiate(ShotEffect, transform.position, Quaternion.identity);

            time = 0.0f;        //���Ԃ̃��Z�b�g
            onShot = true;      //�U���t���O�I��
        }

    }

        private void FixedUpdate()
        {
        //�ߋ����U������
        if (onAttack)
        {
            //�P�b��1.0f���₷
            time += 0.02f;

            //time���w�肵�����Ԉȏ�ɂȂ��
            if (time >= EffectLimit)
            {
                //�U���t���O��������
                onAttack = false;
            }
        }

        //�������U������
        if (onShot)
        {
            //time�𑬓x�Ɠ����������₷
            time += shotSpeed;

            //time���w�肵�����Ԉȏ�ɂȂ��
            if (time >= ShotLange)
            {
                //�U���t���O��������
                onShot = false;
            }
        }
        }

    //�G�ȂǂƂ̐ڐG���̃_���[�W����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�ڐG�^�O���G�̍U�����A�G�{�̂Ȃ�HP�����炷
        if(collision.gameObject.tag == "EnemyAttack"|| collision.gameObject.tag == "Enemy")
        {
            playerHP -= 1.0f;   //�v���C���[�̗̑͂����炷�i��ŉE��ύX�j
            PlayerDead();       //�v���C���[���|��邩�`�F�b�N
        }
    }

    //�v���C���[�����ꂽ�Ƃ��֐�
    void PlayerDead()
    {
        if (playerHP <= 0)
        {
            Debug.Log("���ꂽ");
            Destroy(gameObject, 0.4f);
        }
    }
}



