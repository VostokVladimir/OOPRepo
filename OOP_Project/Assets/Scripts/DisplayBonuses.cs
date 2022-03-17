using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OOP
{
    
    public class DisplayBonuses
    {   private Text _text;
        public DisplayBonuses()//конструктор для доступа к свойству
        {
            _text = Object.FindObjectOfType<Text>();
        }

        public void Display (int info)
        {
            _text.text = $"Бонусы {info}";
        }

    }
}
