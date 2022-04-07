using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OOP
{

    public class PlayerBall : MonoBehaviour
    {
        public float speed;
        [SerializeField] public float helth;
        public static float bonus;
        public static Vector3 _size;
        public static bool flage;
        public  bool flageIsContact;
        public static bool flage_size;
        private  Rigidbody _rigidbody;
        public Text bonusScoreText;
        public AudioSource badBonusSound;
        
        private string poem;

        
        private void Awake()

        {
            bonus = 0;
            speed = 3.0f;
            flageIsContact = false;
            badBonusSound = GetComponent<AudioSource>();

            
        }

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            BadBonus badBonus = new BadBonus();
            badBonus.Event += BadBonus_Event;
            //var resourceSphere=Resources.Load("Sphere");пример загрузки обьекта их папки
           // var go = Instantiate(resourceSphere, new Vector3(1, 1, 1),Quaternion.identity) as GameObject;//пример загрузки ресурса из папки
                

        }

        private void BadBonus_Event()
        {
            
            badBonusSound.Play();


        }

        public void DisplayException()
        {
            //throw new OutRangeException("Вы ввели не тот ");
        }

        protected void Move(float speed)
        {
            try
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");
                Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
               if (speed < 0) 
                { throw new MyException(); }
               else
                _rigidbody.AddForce(movement * speed);
            }
            catch (MyException ex)
            {
                Debug.Log("Параметр скорости не может быть отрицательным числом");
                Debug.Log (ex.Message);
            }
            

            

        }
               
        void Update()
        {
            bonusScoreText.text = bonus.ToString();
            if (flage)
            { Invoke("Change", 5.0f);
                       
            }

            if (flage_size)
            { StartCoroutine(SizeChange()); }

            if (!flage_size)
            { StopCoroutine(SizeChange()); }

            if (flageIsContact) 
            {
                BadBonus_Event();
                flageIsContact = false;
            }


        }


        public void Change()
        {
            print("Уменьшение скорости 3 ");
            speed = 3.0f;

        }


        private IEnumerator SizeChange()
        {
            yield return new WaitForSeconds(5.0f);
            transform.localScale= new Vector3(0.27f, 0.27f, 0.27f);
            print("5 сек прошло");
            flage_size = false;
            

        }

        



    }
    
}
