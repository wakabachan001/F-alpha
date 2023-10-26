using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy02AI : MonoBehaviour
{
    public float movelength = 0.02f;
    float hanpuku = -1.0f;

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
        
    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position; 


        if (cameraTransform.position.y + 2 >= position.y && cameraTransform.position.y - 2.5 <= position.y)
        {

          //@“G‚O‚Q‚ð¶‰E‚ÉˆÚ“®‚³‚¹‚é----------------------------------------------------------------
             transform.position = new Vector2(position.x += movelength , position.y);

             if(transform.position.x > 5)
             {
                //position.x = 5;
                movelength *= hanpuku ; 
             }
             if(transform.position.x <= 1)
             {
                //position.x = 1;
                movelength *= hanpuku;
             }
            // -----------------------------------------------------------------------------------------
            Debug.Log(position.x);
        }
    }
}
