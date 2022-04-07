using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OOP
{
    public class GameController : MonoBehaviour


    {
        public PlayerTypes typeOffPlayer;
          
        private InteractiveObject[] _interactiveObjects;
        private DisplayBonuses _displayBonuses;
        private DisplayEndGame _displayEndGame;
        private CameraController _cameraController;
        private References _references;



        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            typeOffPlayer = new PlayerTypes();
            typeOffPlayer = PlayerTypes.Ball;
            _references = new References();
            PlayerBall player = null;
            if (typeOffPlayer == PlayerTypes.Ball)
            {
               // player = _references.PlayerBall;//активируем игрока
            }

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

