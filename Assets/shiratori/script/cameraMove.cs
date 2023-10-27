using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class cameraMove : MonoBehaviour
{
    public float Movespeed1 = 1.5f;
    public float Movespeed2 = 0.5f;

    GameObject playerObj;
    PlayerManager player;
    Transform playerTransform;

    public float bottomLimit = 3.0f;//カメラのY下限
    public float upLimit = 18.0f;//カメラのY上限
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerManager>();
        playerTransform = playerObj.transform;
    }
    void LateUpdate()
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        if (player.transform.position.y >= bottomLimit && player.transform.position.y <= upLimit)
        {
            //縦方向だけ追従
            transform.position = new Vector3(transform.position.x, playerTransform.position.y + Movespeed1, transform.position.z);
            transform.position = new Vector3(transform.position.x, playerTransform.position.y + Movespeed2, transform.position.z);
            bottomLimit++;
        }

    }

 }
