using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;



namespace OOP
{
    public sealed class BadBonus : InteractiveObjects, IRotation, IFlay, IDamagable
    {
        private int damage=5;
        private float _lengthFlay;
        private float _speedRotation;
        public delegate void BadBonusDel(string s, Color c,int damaging);
        public event BadBonusDel ContactBadBonusPlayer;
        
        private float _maxhealth = 4;
        private float _currentHealth;
        public bool _isContact;
        
       


        
        

        private void Awake()
        {
            _lengthFlay = Random.Range(1.0f, 2.0f);
            _speedRotation = Random.Range(5.0f, 40.0f);
            _currentHealth = _maxhealth;

        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var player = other.gameObject.GetComponent<Transform>();//было раньше взять элемент Player Moovment
                var _skriptPlayerBall = other.gameObject.GetComponent<PlayerBall>();
                player.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                Debug.Log("Уменьшение");
                _skriptPlayerBall.flageIsContact = true;

                Interaction();


            }
        }


        
        public override void Interaction()
        {
            ContactBadBonusPlayer.Invoke(gameObject.name, _color,damage);
            Destroy(gameObject);


            if (PlayerBall.bonus <= 0)
            {
                //throw new System.Exception ("Бонус не может быть ниже нуля");
                try
                {
                    PlayerBall.bonus -= 5;
                    

                }
                catch (System.Exception ex)
                {
                    print(ex.Message);
                    System.Console.WriteLine(ex.Message);

                }
                finally
                {
                    PlayerBall.bonus = 0;
                }
            }
        }


        public override void Execute()
        {
            if (!IsInteractable)
            {
                return;
            }

            Flay();
            Rotation();
        }


        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);

        }

        public void Rotation()
        {

            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        /// <summary>
        /// Метод уменьшает текущее здоровье обьекта на который производится воздействие
        /// </summary>
        /// <param name="damagevalue"></задать уровень урона при каждом воздействии на обьект класса >
        public void ApplyDamage(int damagevalue)
        {
            _currentHealth -= damagevalue;
            Debug.Log("У БедБонуса текущее здоровье" + _currentHealth + "  балов");
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Обьект уничтожен");
            }
        }

        //public object Clone()
        //{
        //    var result = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
        //    return result;


        //}

    }

}
