using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OOP
{
    public class BadBonus : InteractiveObject,IRotation,IFlay //ICloneable
    {
        private float _lengthFlay;
        private float _speedRotation;

        private void Awake()
        {
            _lengthFlay = Random.Range(1.0f, 2.0f);
            _speedRotation = Random.Range(5.0f, 40.0f);

        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var player = other.gameObject.GetComponent<PlayerMovements>();
                player.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                Debug.Log("Уменьшение");

                Interaction();


            }
        }
        protected override void Interaction()
        {
            Destroy(gameObject);
            PlayerBall.bonus -= 5;
        }

        public void Flay() 
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
                               
        }

        public void Rotation ()
        {

            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        //public object Clone()
        //{
        //    var result = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
        //    return result;


        //}

    }
}
