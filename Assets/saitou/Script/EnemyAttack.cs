using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float clonepos = -1.0f;//�N���[�������ʒu�����p
    public float coolTime = 2.0f;//�U���̃N�[���^�C��
    private float time = 0.0f;//���Ԍv���p

    private bool moveOn = false;//�s���\�t���O

    public GameObject AttackEffect;//�N���[������I�u�W�F�N�g

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�A�N�e�B�u�G���A���ɓ�������
        if (collision.gameObject.tag == "ActiveArea")
        {
            moveOn = true;//�s���\�t���O���I��
        }
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "ActiveArea")
    //    {
    //        moveOn = false;
    //    }
    //}

    private void FixedUpdate()
    {
        if (moveOn)
        {
            time += 0.02f;//1�b��1������

            //time���N�[���^�C���𒴂�����
            if (time >= coolTime)
            {
                //�U������
                //����̑O��(������)�ɍU���G�t�F�N�g�̃N���[������
                Instantiate(AttackEffect, transform.position + (transform.up * clonepos), Quaternion.identity);
                time = 0.0f;
            }
        }
    }
}
