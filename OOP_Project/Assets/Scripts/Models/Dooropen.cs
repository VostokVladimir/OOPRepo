using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOP
{
    public class Dooropen : MonoBehaviour,IDamagable
    {
        public Animator _anim;
        [SerializeField]private float _currenthealth;
        private float _maxhealth;

        // Start is called before the first frame update
        void Start()
        {
            _maxhealth = 10;
            _anim = GetComponent<Animator>();
            _currenthealth = _maxhealth;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _anim.SetBool("Isopen", true);
                print("Энтер");
            }

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _anim.SetBool("Isopen", false);
            }

        }
        /// <summary>
        /// Метод для работы с интерфейсом IDamagable, расчитывает ущерб от поращения
        /// </summary>
        /// <param name="damagevalue"></param>
        public void ApplyDamage(int damagevalue)
        {
            
                _currenthealth -= damagevalue;
                Debug.Log("У Двери текущая крепость" + _currenthealth + "  балов");
                if (_currenthealth <= 0)
                {
                    Destroy(gameObject);
                    Debug.Log("Дверь уничтожена");
                }
            
        }
    }
}
