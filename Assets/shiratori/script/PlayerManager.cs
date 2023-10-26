using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // Start is called before the first frame update
    public class PlayerManager : MonoBehaviour
    {
    public float speed = 1.0f;      //移動距離
    public float shotSpeed = 0.2f;  //手裏剣の速度
    public float playerHP = 4.0f;   //プレイヤーの体力
    public float HPcount;
    
    public float EffectLimit;       //近距離攻撃の判定が残る時間
    public float ShotLimit = 3.5f;  //遠距離攻撃の飛距離の上限
    private float ShotLange;        //遠距離攻撃の飛距離
    public float SwordDamage = 2.0f;     //近距離攻撃ダメージ
    public float SyurikenDamage = 1.5f;  //遠距離攻撃ダメージ

    public float leftLimit = 1.0f;  //侵入できる左の限界
    public float rightLimit = 5.0f; //侵入できる右の限界
    public float upLimit = 20.0f;   //侵入できる上の限界
    public float HPposX = 1.0f;
    public float HPposY = 1.0f;

    bool onAttack = false;      //近距離攻撃フラグ
    bool onShot = false;        //遠距離攻撃フラグ
    bool onBottomColumn = true; //下列にいるかどうか
    private float time; //時間計測用

    public GameObject AttackEffect; //近距離攻撃
    public GameObject ShotEffect;   //遠距離攻撃
    public GameObject HPIcon;       //HPのアイコン
    public Transform HPParent;     //HPアイコンの親

    void Start()
    {
        //for (HPcount = playerHP; HPcount > 0; HPcount--)
        //{
        //    Instantiate(HPIcon, new Vector3(HPposX + HPcount, HPposY, 0), Quaternion.identity, HPParent);
        //    Debug.Log("クローン生成");
        //}
    }

    // Update is called once per frame

    void Update()
    {
        //プレイヤー座標の取得
        Vector2 position = transform.position;

        //移動(場外にいかないようにする)
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
            onBottomColumn = true;  //後退時に下列にいることにする
        }
        

        transform.position = position;  //座標の更新

        //近距離攻撃
        if (Input.GetKeyDown(KeyCode.Space) && !onAttack && !onShot)//攻撃開始時(Spaceキーを押すと攻撃開始)
        {
            //攻撃エフェクトの有効化
            AttackEffect.gameObject.SetActive(true);
                
            //プレイヤーの１マス前に攻撃エフェクトを移動
            AttackEffect.transform.position = this.transform.position + transform.up;
           
            time = 0.0f;        //時間のリセット
            onAttack = true;    //攻撃フラグオン
        }

        //遠距離攻撃
        if (Input.GetKeyDown(KeyCode.LeftShift) && !onAttack && !onShot)//攻撃開始時(Spaceキーを押すと攻撃開始)
        {
            //現在いる列によって飛距離を変更
            if (onBottomColumn)
                ShotLange = ShotLimit;
            else
                ShotLange = ShotLimit - 1.0f;

            //攻撃エフェクトの有効化
            ShotEffect.gameObject.SetActive(true);            

            //プレイヤーの位置に移動
            ShotEffect.transform.position = this.transform.position;

            time = 0.0f;        //時間のリセット
            onShot = true;      //攻撃フラグオン
        }



    }

        private void FixedUpdate()
        {
        //近距離攻撃処理
        if (onAttack)
        {
            //１秒で1.0f増やす
            time += 0.02f;

            //timeが指定した時間以上になると
            if (time >= EffectLimit)
            {
                //オブジェクトの無効化
                AttackEffect.gameObject.SetActive(false);
                //攻撃フラグを下げる
                onAttack = false;
            }
        }

        //遠距離攻撃処理
        if (onShot)
        {
            //timeを速度と同じだけ増やす（１秒でyに1.0増やす）
            time += shotSpeed;

            //遠距離攻撃エフェクトの座標取得
            Vector3 shotpos = ShotEffect.transform.position;

            //上方向に進ませる
            shotpos += new Vector3(0, shotSpeed, 0);

            //座標更新
            ShotEffect.transform.position = shotpos;

            //timeが指定した時間以上になると
            if (time >= ShotLange)
            {
                //オブジェクトの無効化
                ShotEffect.gameObject.SetActive(false);
                //攻撃フラグを下げる
                onShot = false;
            }
        }
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyAttack"|| collision.gameObject.tag == "Enemy")
        {
            playerHP -= 1.0f;//プレイヤーの体力を減らす（後で右を変更）
            PlayerDead();
        }
        PlayerDead();
    }

    void PlayerDead()
    {
        if (playerHP <= 0)
        {
            Debug.Log("やられた");
            Destroy(gameObject, 0.4f);
        }
    }
}



