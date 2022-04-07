using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

namespace OOP
{    /// <summary>
///  Этот клас нужен для активации и дезактивации интерактивных обьектов на сцене для взаимодействия друг с другом (при этом взаиможействие только с плеером или наделенным этим правом обьектом. То есть если обьект не имеет класс InteractiveObject он не будет взаимодействовать
/// </summary>
      public  abstract class InteractiveObjects:MonoBehaviour,IExecute
    {
        protected Color _color;
        private bool _isInteractable;

        protected bool IsInteractable // свойство для работы с обьектов вкдючать и отключать его активность и взаимодействие
        {   get { return _isInteractable; }
            set
            { _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!IsInteractable||!other.CompareTag("Player"))
            { return; }
            Interaction();
            IsInteractable = false;


        }





        public abstract void Interaction();// Вопрос : зачем тут абстрактный метод ? абстрактные методы могут быть только в абстрактных классах

        public abstract void Execute();//Вопрос : зачем тут абстрактный метод ? абстрактные методы могут быть только в абстрактных классах


        private void Start() 
        {
            IsInteractable = true;//активируем обьект на старте 
            _color = ColorHSV();//рамдомный выбор цвета 
            if(TryGetComponent(out Renderer rend))
            {
                rend.material.color = _color;
            }
        }

         
    }
  
}
