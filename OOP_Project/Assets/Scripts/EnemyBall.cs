using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace N
{
    class EnemyBall: MonoBehaviour,Interface_IDamageable
    {
        [SerializeField] private float maxHealth;
        private float _curenthealth;

        void Start()
        {
            _curenthealth = maxHealth;
        }



        public void ApplyDamage(int damageValue) 
        {
            _curenthealth = _curenthealth - damageValue;
            Debug.Log("У вражеского шарика осталось" + _curenthealth + "здоровья");
            

            if(_curenthealth<=0)
            {
                Destroy(gameObject);
                Debug.Log("Шарик ликвидирован");
            }
        
        
        }
    }
}
