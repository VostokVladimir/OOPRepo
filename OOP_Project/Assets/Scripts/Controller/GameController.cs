using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OOP
{
    public class GameController : MonoBehaviour


    {
        public PlayerTypes typeOffPlayer;//тип игрока

        private InteractiveObject[] _interactiveObjects; //список интерактивных обьектов
        private DisplayBonuses _displayBonuses; 
        private DisplayEndGame _displayEndGame;
        private CameraController _cameraController;
        private References _references;//класс ссылок выгруженных на сцену
        public GameObject player;// 


        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            typeOffPlayer = new PlayerTypes();
            typeOffPlayer = PlayerTypes.Ball;
            _references = new References();

            //var Loadplayerball = Resources.Load<GameObject>("Player");//Вопрос 1. вар 1 почему ругается и не загружает ??
           
            
            

            if (typeOffPlayer == PlayerTypes.Ball)
            {
               var player1 = _references.PlayerBall;//активируем игрока// Вопрос 2  вар 2 почему не загружает префаб ??? 
            }

        }

        void Start()
        {
                //var Loadplayerball = Resources.Load<GameObject>("Player"); //Вопрос 3 вар 3 почему не загружает префаб ???
                //Debug.Log("Загрузка игрока");
                //player = Instantiate(Loadplayerball);
            
            
            
            
        }

        public void Execute()
        {
            
        }

        // Update is called once per frame
        void Update()

        {   
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFlay flay)
                {
                    flay.Flay();
                }
                if (interactiveObject is IFliker fliker)
                {
                    fliker.Fliker();
                }
                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }

    }
}

