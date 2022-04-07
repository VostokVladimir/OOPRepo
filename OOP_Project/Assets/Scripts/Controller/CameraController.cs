using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OOP
{

    public sealed class CameraController : IExecute
    {
        //public PlayerBall PlayerBall;
        private Transform _player;
        private Transform _main_camera;
        private Vector3 _offset;

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _main_camera = mainCamera;
            _offset = _main_camera.position-_player.position;
        }

        //private void Start()
        //{
        //    _offset = transform.position - PlayerBall.transform.position;
        //}

        //private void LateUpdate()
        //{
        //    transform.position = PlayerBall.transform.position + _offset;
        //}

        public void Execute()
        {
            _main_camera.LookAt(_player);
            _main_camera.position = _player.position + _offset;
        }

    }
       
}


    





