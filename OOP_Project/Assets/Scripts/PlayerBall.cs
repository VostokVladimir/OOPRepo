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
        public static bool flage_size;
        private  Rigidbody _rigidbody;
        public Text bonusScoreText;
        private string poem;

        public float Speed
        {
            get { return speed; }

            set { speed = value; }

        }
        private void Awake()

        {
            bonus = 0;
            speed = 3.0f;

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
               
        void Update()
        {
            bonusScoreText.text = bonus.ToString();
            if (flage)
            { Invoke("Change", 5.0f); }

            if (flage_size)
            { StartCoroutine(SizeChange()); }

            if (!flage_size)
            { StopCoroutine(SizeChange()); }
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
