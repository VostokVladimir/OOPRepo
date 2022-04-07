using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Windows.Forms;



public class MyException : System.Exception
{
     public MyException()
    {
        Debug.LogWarning("Ошибка ввода : введено отрицательное число");
       //MessageBox.Show("Не тупи");
    }


}
