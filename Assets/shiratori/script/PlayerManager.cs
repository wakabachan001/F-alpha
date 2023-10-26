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
    private float ShotLange;        //�������U���̔򋗗�
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
    public GameObject HPIcon;       //HP�̃A�C�R��
    public Transform HPParent;     //HP�A�C�R���̐e

    void Start()
    {
        //for (HPcount = playerHP; HPcount > 0; HPcount--)
        //{
        //    Instantiate(HPIcon, new Vector3(HPposX + HPcount, HPposY, 0), Quaternion.identity, HPParent);
        //    Debug.Log("�N���[������");
        //}
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
            //�U���G�t�F�N�g�̗L����
            AttackEffect.gameObject.SetActive(true);
                
            //�v���C���[�̂P�}�X�O�ɍU���G�t�F�N�g���ړ�
            AttackEffect.transform.position = this.transform.position + transform.up;
           
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

            //�U���G�t�F�N�g�̗L����
            ShotEffect.gameObject.SetActive(true);            

            //�v���C���[�̈ʒu�Ɉړ�
            ShotEffect.transform.position = this.transform.position;

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
                //�I�u�W�F�N�g�̖�����
                AttackEffect.gameObject.SetActive(false);
                //�U���t���O��������
                onAttack = false;
            }
        }

        //�������U������
        if (onShot)
        {
            //time�𑬓x�Ɠ����������₷�i�P�b��y��1.0���₷�j
            time += shotSpeed;

            //�������U���G�t�F�N�g�̍��W�擾
            Vector3 shotpos = ShotEffect.transform.position;

            //������ɐi�܂���
            shotpos += new Vector3(0, shotSpeed, 0);

            //���W�X�V
            ShotEffect.transform.position = shotpos;

            //time���w�肵�����Ԉȏ�ɂȂ��
            if (time >= ShotLange)
            {
                //�I�u�W�F�N�g�̖�����
                ShotEffect.gameObject.SetActive(false);
                //�U���t���O��������
                onShot = false;
            }
        }
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyAttack"|| collision.gameObject.tag == "Enemy")
        {
            playerHP -= 1.0f;//�v���C���[�̗̑͂����炷�i��ŉE��ύX�j
            PlayerDead();
        }
        PlayerDead();
    }

    void PlayerDead()
    {
        if (playerHP <= 0)
        {
            Debug.Log("���ꂽ");
            Destroy(gameObject, 0.4f);
        }
    }
}



