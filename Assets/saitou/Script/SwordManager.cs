using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    public float EffectTime = 0.2f;//�U���G�t�F�N�g���c�鎞��

    private float time = 0;//���Ԍv���p

    private void FixedUpdate()
    {
        //�P�b��1.0f���₷
        time += 0.02f;

        //time���w�肵�����Ԉȏ�ɂȂ��
        if (time >= EffectTime)
        {
            Destroy(gameObject);//���̃I�u�W�F�N�g���폜
        }
    }
}
