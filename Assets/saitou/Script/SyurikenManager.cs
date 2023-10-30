using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyurikenManager : MonoBehaviour
{
    public float EffectTime = 0.2f;//�U���G�t�F�N�g���c�鎞��

    private float speed;  //�藠���̑��x
    private float lange;  //�򋗗�

    private float time = 0;//���Ԍv���p



    private void Start()
    {
        //PlayerManager���擾
        PlayerManager playermanager;
        GameObject obj = GameObject.Find("Player");
        playermanager = obj.GetComponent<PlayerManager>();

        //lange,speed��player����擾
        lange = playermanager.ShotLange;
        speed = playermanager.shotSpeed;
    }

    private void FixedUpdate()
    {
        //���W�X�V
        transform.position += (transform.up * speed);

        //�򋗗��Ə����鎞�Ԃ������ɂȂ�悤�ɂ���
        time += speed;

        //time���򋗗���ɂȂ��
        if (time >= lange)
        {
            Destroy(gameObject);//���̃I�u�W�F�N�g���폜
        }
    }
}
