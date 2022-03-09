using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOP
{
    public sealed class GoobBonus : InteractiveObject,IFlay, IFliker
        
    {
        //private int _points;
        private Material _material;
        private float _lenthFlay;
        private DisplayBonuses _displayBonuses;
        

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lenthFlay = Random.Range(0.5f, 1.0f);
            _displayBonuses = new DisplayBonuses();
            //_points = 5;

            

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var player = other.gameObject.GetComponent<PlayerBall>();

                player.speed = 30.0f;


                Interaction();
            }
        }


        protected override void Interaction()
        {
           // _displayBonuses.Display(5);
            Destroy(gameObject);
            Debug.Log("Гудбонус сработал");
            

            // Add bonus
        }

        
        

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lenthFlay), transform.localPosition.z);

        }

        public void Fliker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,Mathf.PingPong(Time.time,1.0F));

        }
    }
}
