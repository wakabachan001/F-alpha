using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // Start is called before the first frame update
    public class idou : MonoBehaviour
    {
        public float speed = 0.5f;


        void Start()
        {

        }

        // Update is called once per frame

        void Update()
        {
            Vector2 position = transform.position;

            if (Input.GetKeyDown("left"))
            {
                position.x -= speed;
            }
            if (Input.GetKeyDown("right"))
            {
                position.x += speed;
            }
            if (Input.GetKeyDown("up"))
            {
                position.y += speed;
            }
            if (Input.GetKeyDown("down"))
            {
                position.y -= speed;
            }

            transform.position = position;

        }

        private void FixedUpdate()
        {
           

        }
    }



