using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstModule
{
    
    public class PlayerBall : MonoBehaviour
    {   public float speed = 3.0f;
        private Rigidbody _rigidbody;

        // Start is called before the first frame update
        void Start()
        {

            _rigidbody = GetComponent<Rigidbody>();


        }

        protected void Move()
        {
           // float moveHorizontal = Input.GetAxis("Horizontal");
           // float moveVertical = Input.GetAxis("Vertical");
           // Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
           // _rigidbody.AddForce(movement * speed);

            

            if (Input.GetKey(KeyCode.UpArrow))
            {
                Vector3 direction = new Vector3(0.0f, 0.0f, 1.0f);
                _rigidbody.AddForce(direction * speed);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Vector3 direction = new Vector3(0.0f, 0.0f, -1.0f);
                _rigidbody.AddForce(direction * speed);

            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Vector3 direction = new Vector3(-1.0f, 0.0f, 0.0f);
                _rigidbody.AddForce(direction * speed);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector3 direction = new Vector3(1.0f, 0.0f, 0.0f);
                _rigidbody.AddForce(direction * speed);

            }

           // Vector3 direction = new Vector3(0.0f, 0.0f, 0.0f);







        }


    }
}
