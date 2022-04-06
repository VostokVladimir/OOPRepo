using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OOP
{
    class Shotter: MonoBehaviour
    {

        [SerializeField] private Transform _targetPoint;
        private Camera _camera;
        [SerializeField] private int _damage;//устанавливаем какой урон дает этот шутер

        private void Awake()
        {
            _camera = Camera.main;


        }


        private void Update()
        {
            Ray traccer = _camera.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(transform.position, traccer.direction * 15);//15 это длина луча
            RaycastHit hit;
            if(Physics.Raycast(traccer,out hit))
            {
                //_targetPoint.position = hit.point;
                if(Input.GetKeyDown(KeyCode.Mouse0)&&hit.collider.TryGetComponent(out IDamagable obj_damagable)) 
                {
                    obj_damagable.ApplyDamage(_damage);
                }
            }


        }
    }
}
