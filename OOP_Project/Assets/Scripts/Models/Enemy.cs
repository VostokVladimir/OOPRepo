using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OOP
{
    public class Enemy : MonoBehaviour, IDamagable
    {
        private float _curenthealth;
        private float _maxhealth=10;

        public void Start() 
        {
            _curenthealth = _maxhealth;

        }

        public void ApplyDamage(int damagevalue)
        {
            _curenthealth -= damagevalue;
            Debug.Log("У Врага осталось  здоровья"+  _curenthealth);
            if (_curenthealth <= 0)
            { Destroy(gameObject);
                Debug.Log("Враг уничтожен");
            }
        }

        
    }
}
