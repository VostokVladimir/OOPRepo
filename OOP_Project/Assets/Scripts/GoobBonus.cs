using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOP
{
    public sealed class GoobBonus : InteractiveObject,IFlay, IFliker
        
    {
        private GameObject _player;
        private Material _material;
        private float _lenthFlay;
        private DisplayBonuses _displayBonuses;
        private bool _flag;
        private float _currentSpeed;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lenthFlay = Random.Range(0.5f, 1.0f);
            _displayBonuses = new DisplayBonuses();
            _flag = false;
        }
        

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var player = other.gameObject.GetComponent<PlayerMovements>();
                player.speed = 15.0f;
                print("Увеличение скорости 10");
                PlayerBall.flage = true;                       
                Interaction();
                 
            }
        }


        void Update()
        {
            //if (_flag == true)//не принимает новое значение true из метода OnTriggerEnter
            //{
            //    StartCoroutine(SpeedChange());
                
            //}

        }

        private IEnumerator SpeedChange()
        {   
            yield return new WaitForSeconds(5.0f);
            print("5 сек прошло");
                       
            
            
        }

        protected override void Interaction()
        {
           // Add bonus
           PlayerBall.bonus+=5;
           Destroy(gameObject);
            
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
