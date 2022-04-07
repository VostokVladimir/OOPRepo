using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OOP
{
    
    public class DisplayBonuses
    {   private Text _text;
        public DisplayBonuses(GameObject b)//конструктор для доступа к свойству
        {
            _text = b.GetComponentInChildren<Text>();//что тут происходит ?
            _text.text = string.Empty;

        }

        public void Display (int info)
        {
            _text.text = $"Бонусы {info}";
        }

    }
}
