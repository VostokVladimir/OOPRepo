using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEndGame 
{
    private Text _endGameText;

    public DisplayEndGame(GameObject anyobject)//обьект создаем передаем туда геймобьект и там храним ссылку на его поле текст. Туда передается загруженный префаб из папки ресурсес с полем текст
    {
        _endGameText = anyobject.GetComponentInChildren<Text>();//получаем доступ к полю текст , перебираем иерархию всех вложенных обьектов и ищем у какого есть компонент Текст 
        _endGameText.text = string.Empty;//ставим заглушку 

        
    }

    public void GameOver(string name, Color color)//здесь метод принимающий параметры Имя обьекта
    {
        _endGameText.text = $"Вы проиграли. Вас убил {name} {color} ";
    }

}
