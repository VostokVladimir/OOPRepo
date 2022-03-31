using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MyException : System.Exception
{
     public MyException()
    {
        Debug.LogWarning("Ошибка ввода : введено отрицательное число");
    }
}
