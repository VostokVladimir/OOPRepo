using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OOP
{
    public class InputKontroller : IExecute
    {
        private readonly PlayerBase _playerBase;
        public InputKontroller(PlayerBase p)
        {
            _playerBase = p;
        }



    public void Execute()
       {
         _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
       }
        
    }
}
