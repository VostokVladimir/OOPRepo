using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstModule
{
    public sealed partial class PlayerMovements : PlayerBall
    {
        

        // Update is called once per frame
        void FixedUpdate()
        {
            Move();
        }
    }
}
