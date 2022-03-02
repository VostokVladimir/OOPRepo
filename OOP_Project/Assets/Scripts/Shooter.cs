using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class Shooter
    {
        [SerializeField] private Transform _targetPosition;
        private Camera _cam;
        [SerializeField] private int _damage;

        private void Awake() 
        {
            _cam = Camera.main;
        }

        private void Update()
        {
            Ray luchik = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(luchik,out hit)) 
            {
                _targetPosition.position = hit.point;
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.TryGetComponent(out Interface_IDamageable damagable))
                {
                    damagable.ApplyDamage(_damage);
                }
                        
            
            }
        }

    }



}
