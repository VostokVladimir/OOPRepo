using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OOP


{
    public sealed class References
    {

        private PlayerBall _playerBall;
        private Canvas _canvas;
        private Button _restartgameButton;
        private GameObject _endGameLabel;
        private Camera _mainCamera;
        private GameObject _bonusScore;


        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)

                { _canvas = Object.FindObjectOfType<Canvas>(); }//ищем канвасы на сцене

                return _canvas;
            }


        }

        public Button RestartGameButton
        {
            get
            {

                if (_restartgameButton == null)
                {
                    var loadRestartButton = Resources.Load<Button>("UI/ButtonRestart");
                    _restartgameButton = Object.Instantiate(loadRestartButton, Canvas.transform);
                }
                return _restartgameButton;
            }
        }



        public PlayerBall PlayerBall
        {
            get {

                if (_playerBall == null)
                {
                    var Loadplayerball = Resources.Load<PlayerBall>("Player");//загружаем префаб в переменную
                    _playerBall = Object.Instantiate(Loadplayerball);//размещаем префаб на сцене в
                }

                return _playerBall;


            }



        }

        public GameObject EndGameLabel
        {
            get
            {

                if (_endGameLabel == null)
                {
                    var loadEndGameLabel = Resources.Load<GameObject>("UI/EndGame");
                    _endGameLabel = Object.Instantiate(loadEndGameLabel, Canvas.transform);


                }

                return _endGameLabel;
            }


        }


        public Camera CameraMain
        {
            get 
            {  if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                
                }
                
                return _mainCamera;
            
            }
        }


        public GameObject BonusScore
        {
            get 
            {   if (_bonusScore == null)
                {
                    var loadBonusScoreLabel = Resources.Load<GameObject>("UI/BonusesScore");
                }
                return _bonusScore;
            }
        }




    }
}
