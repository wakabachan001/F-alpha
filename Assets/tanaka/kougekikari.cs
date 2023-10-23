        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using UnityEngine.UI; 

public class kougekikari : MonoBehaviour
    {
        Rigidbody2D rd; //Rigidbodyオブジェクト
       // float attspeed = 6.0f;  //オブジェクト移動スピード

        // 速度
         public float Speed;

        // 角度
         public float Angle;

        // 移動ベクトル
        Vector3 vec;

       private float limit;

        void Start()
        {
            rd = GetComponent<Rigidbody2D>();   //Rigidbodyコンポーネント取得

            limit = 1.0f;

            float rad = Angle * Mathf.Deg2Rad;

            Vector3 direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0);

            vec = direction * Speed * Time.deltaTime;


        }

        void Update()
        {
        if (Input.GetKeyDown(KeyCode.Space))//攻撃開始時(Spaceキーを押すと攻撃開始)
        {
            transform.position += vec;

            limit -= Time.deltaTime;
            if (limit <= 0)
            {
                Destroy(gameObject);    //攻撃オブジェクトの破棄
            }

            
        }
             //rd.velocity = new Vector2(0, attspeed); //スピードをつけて攻撃オブジェクトを移動
        }

       

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject);    //攻撃オブジェクトの破棄
        }
    }
