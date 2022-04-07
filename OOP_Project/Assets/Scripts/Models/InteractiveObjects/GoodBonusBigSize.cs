using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOP
{
    public class GoodBonusBigSize : InteractiveObject, IFlay, IFliker
    {

        private Material _material;
        private float _lenthFlay;
        private DisplayBonuses _displayBonuses;
        public float timer=5f;
        private Vector3 _size;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lenthFlay = Random.Range(0.5f, 1.0f);
            _displayBonuses = new DisplayBonuses();

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var player = other.gameObject.GetComponent<PlayerMovements>();
                player.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                Debug.Log("ГудбонусРазмер сработал");
                PlayerBall.flage_size = true;
                Interaction();
               

            }
        }


        protected override void Interaction()
        {
            // _displayBonuses.Display(5);
            PlayerBall.bonus += 5;
            Destroy(gameObject);
                       
            // Add bonus
        }


        

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lenthFlay), transform.localPosition.z);

        }

        public void Fliker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0F));

        }
    }
}


