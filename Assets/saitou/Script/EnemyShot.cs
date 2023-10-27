using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float EffectTime = 0.2f;//�U���G�t�F�N�g���c�鎞��

    public float speed = -0.1f; //�藠���̑��x
    public float lange = -3.0f;  //�򋗗�

    private float time = 0;//���Ԍv���p

    private void FixedUpdate()
    {
        //���W�X�V
        transform.position += (transform.up * speed);

        //�򋗗��Ə����鎞�Ԃ������ɂȂ�悤�ɂ���
        time += speed;

        //time���򋗗���ɂȂ��
        if (time <= lange)
        {
            Destroy(gameObject);//���̃I�u�W�F�N�g���폜
        }
    }
}
