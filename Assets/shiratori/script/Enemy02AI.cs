using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy02AI : MonoBehaviour
{
    public float movelength = 1.0f;

    GameObject cameraObj;
    cameraMove camera;
    Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        camera = cameraObj.GetComponent<cameraMove>();
        cameraTransform = cameraObj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        //float MoveCT = 2.0f;

        if (cameraTransform.position.y + 2 >= position.y && cameraTransform.position.y - 2.5 <= position.y) 
        {
            transform.position = new Vector2(position.x, position.y - movelength);
            Debug.Log("aa");
        }
    }
}
