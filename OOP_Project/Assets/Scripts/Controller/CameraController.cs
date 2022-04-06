using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OOP
{

    public sealed class CameraController : MonoBehaviour
    {
        public PlayerBall PlayerBall;
        
        private Vector3 _offset;

        private void Start()
        {
            _offset = transform.position - PlayerBall.transform.position;
        }

        private void LateUpdate()
        {
            transform.position = PlayerBall.transform.position + _offset;
        }


    }
       
}


    





