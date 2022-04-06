using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OOP
{
    public class GameController : MonoBehaviour
    {
        private InteractiveObject[] _interactiveObjects;
        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
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

