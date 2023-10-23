using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class cameraMove : MonoBehaviour
{
  
        GameObject playerObj;
        PlayerMove player;
        Transform playerTransform;
        void Start()
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
            player = playerObj.GetComponent<PlayerMove>();
            playerTransform = playerObj.transform;
        }
        void LateUpdate()
        {
            MoveCamera();
        }
        void MoveCamera()
        {
            if(player.transform.position.y>2)
            //â°ï˚å¸ÇæÇØí«è]
            transform.position = new Vector3(transform.position.x, playerTransform.position.y+1.5f, transform.position.z);
        }
 }
