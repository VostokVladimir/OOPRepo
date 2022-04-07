using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace OOP
{
    public class GameController : MonoBehaviour


    {
        public PlayerTypes typeOffPlayer=PlayerTypes.Ball;// задан тип игрока
        private ListExecuteObject _inteactiveObject;//список интерактивных обьектов
         
        //private InteractiveObject[] _interactiveObjects; //
        private DisplayBonuses _displayBonuses; 
        private DisplayEndGame _displayEndGame;
        private CameraController _cameraController;
        private References _references;//класс ссылок выгруженных на сцену
        public GameObject player;// 
        private InputKontroller  _inputController; //класс задающий способ управления в зависимости от вида игрока
        private int _countBonuses;// поле подсчета бонусов

        private void Awake()
        {
            //_interactiveObjects = FindObjectsOfType<InteractiveObject>();
            _inteactiveObject = new ListExecuteObject(); //создали контейнер для хранения интерактивных обьектов
             _references = new References();//создали ссылки для хранения ссылок;
                        
            PlayerBase player = null;//ссылка на управление игрока обнулена. Зачем ???? 


            //var Loadplayerball = Resources.Load<GameObject>("Player");//Вопрос 1. вар 1 почему ругается и не загружает ??

            
            if (typeOffPlayer == PlayerTypes.Ball)
            {
               player= _references.PlayerBall;//активируем игрока// Вопрос 2  вар 2 почему не загружает префаб ??? 
            }

            _cameraController = new CameraController(player.transform, _references.CameraMain.transform); //создаем контейнер для камеры, иередаем туда позишн игрока, и позишн камеры через референсы
            _inteactiveObject.AddExecuteObject(_cameraController);    //в список интеректив объектов добавляем контейнер с камерой.ВОПРОС№1: ЗАЧЕМ ЭТО ВНОСИТЬ В СПИСОК?? КАКОЙ ЗАМЫСЕЛ??


            if(Application.platform==RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputKontroller(player);
                _inteactiveObject.AddExecuteObject(_inputController);//в список интеректив объектов добавляем контейнер с камерой.ВОПРОС№1: ЗАЧЕМ ЭТО ВНОСИТЬ В СПИСОК?? КАКОЙ ЗАМЫСЕЛ??
            }




            _displayBonuses = new DisplayBonuses(_references.BonusScore); //создаем экземпляр класса и передаем туда ссылку на загруженный UI элемент - префаб текстового элемента канваса
             _displayEndGame = new DisplayEndGame(_references.EndGameLabel);// создаем экземпляр класса и передаем туда ссылку на загруженный UI префаб текстового элемента канваса


            foreach(var o in _inteactiveObject)// ВОПРОС №3 : МЫ НЕ ДОБАВЛЯЛИ В СПИСОК _INTERACTIVEOBJECT goodBONUSES , ОТКУДА ОНИ ВОЗЬМУТСЯ ТАМ ?
            {
                if (o is GoobBonus goobBonus)
                {
                    goobBonus.ContactPlayerGoodBonus += AddingGoodBonuses;
                }
            }

            foreach (var o in _inteactiveObject)
            {
                if (o is BadBonus badbonus)// ВОПРОС №3 : МЫ НЕ ДОБАВЛЯЛИ В СПИСОК _INTERACTIVEOBJECT BADBONUSES , ОТКУДА ОНИ ВОЗЬМУТСЯ ТАМ ?
                {
                    badbonus.ContactBadBonusPlayer += DamageBadBonuses;
                }



            }


            _references.RestartGameButton.onClick.AddListener(RestartGame);
            _references.RestartGameButton.gameObject.SetActive(false);//что делает эта команда
        }

        public void AddingGoodBonuses(int a)
        {
            
            _countBonuses = a;
            _displayBonuses.Display(_countBonuses);
        }

        public void DamageBadBonuses(string value,Color color,int damage)
        {
            if (_countBonuses >= 0)
            { 
            _countBonuses -= damage;
            _displayBonuses.Display(_countBonuses);
            }
            _references.RestartGameButton.gameObject.SetActive(true);//вопрос требуется пояснения по команде как она работает
            Time.timeScale = 0.0f;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }



            void Start()
        {
            //var Loadplayerball = Resources.Load<GameObject>("Player"); //Вопрос 3 вар 3 почему не загружает префаб ???
            //Debug.Log("Загрузка игрока");
            //player = Instantiate(Loadplayerball);
             
            
            
            
        }

        

        // Update is called once per frame
        void Update()

        {   
            for (var i = 0; i < _inteactiveObject.Length; i++)
            {
                var interactiveObject = _inteactiveObject[i];
                interactiveObject?.Execute();



                //if (interactiveObject == null)
                //{
                //    continue;
                //}

                //if (interactiveObject is IFlay flay)
                //{
                //    flay.Flay();
                //}
                //if (interactiveObject is IFliker fliker)
                //{
                //    fliker.Fliker();
                //}
                //if (interactiveObject is IRotation rotation)
                //{
                //    rotation.Rotation();
                //}
            }
        }

    }
}

