using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOP
{
    
    public class PlayerBall : MonoBehaviour
    {   public float speed;
        [SerializeField]public float helth;
        public float bonus;
        //private Vector3 _size;
        private Rigidbody _rigidbody;
        //public float timer;
        

        private void Awake()
        {
            speed = 3.0f;
            //timer = 3.0f;
        }

        // Start is called before the first frame update
        void Start()
        {

            _rigidbody = GetComponent<Rigidbody>();
           


        }

       

        protected void Move(float speed)
        {
            
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            _rigidbody.AddForce(movement * speed);
                             

        }


        //public void SizeChanging()
        //{   _size = new Vector3(0.4f, 0.4f, 0.4f);
        //    transform.localScale = _size;
        //    timer = timer - 1.0f * Time.deltaTime;
        //    if (timer <= 0) { transform.localScale = new Vector3(0.27f, 0.27f, 0.27f); }


        //}

        


        // Update is called once per frame
        void FixedUpdate()
        {
            
            Move(speed);
            
            
        }

    }
}
