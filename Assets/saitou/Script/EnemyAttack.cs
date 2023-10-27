using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float clonepos = -1.0f;

    public float coolTime = 2.0f;//�U���̃N�[���^�C��
    private float time = 0.0f;//���Ԍv���p

    public GameObject AttackEffect;

    private void FixedUpdate()
    {
        time += 0.02f;//1�b��1������

        //time���N�[���^�C���𒴂�����
        if(time >= coolTime)
        {
            //�U������
            //����̑O��(������)�ɍU���G�t�F�N�g�̃N���[������
            Instantiate(AttackEffect, transform.position + (transform.up * clonepos), Quaternion.identity);
            time = 0.0f;
        }
    }
}
