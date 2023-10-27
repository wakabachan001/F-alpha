using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float clonepos = -1.0f;

    public float coolTime = 2.0f;//攻撃のクールタイム
    private float time = 0.0f;//時間計測用

    public GameObject AttackEffect;

    private void FixedUpdate()
    {
        time += 0.02f;//1秒で1増える

        //timeがクールタイムを超えたら
        if(time >= coolTime)
        {
            //攻撃処理
            //これの前方(下方向)に攻撃エフェクトのクローン生成
            Instantiate(AttackEffect, transform.position + (transform.up * clonepos), Quaternion.identity);
            time = 0.0f;
        }
    }
}
