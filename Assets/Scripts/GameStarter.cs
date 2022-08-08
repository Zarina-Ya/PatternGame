using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject
{
   public class GameStarter : MonoBehaviour
   {
        Enemy primitiveEnemy;
        Enemy normalEnemy;
        [SerializeField] Transform _targetTransform;
        private Player _player;
        [SerializeField] float _minDistance;
        [SerializeField] float _speed;
        [SerializeField] GameObject _bullet;



        bool canShoot = true;
        private void Start()
        {
            primitiveEnemy = new Enemy("TEstEnemy", new PrimitiveEnemyFactory());
            normalEnemy = new Enemy("TEstNormalEnemy", new NormalEnemyFactory());

            _targetTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

            ViewService viewService = new ViewService();
           var test = viewService.Instantiate<Rigidbody>(_bullet);
            test.transform.position = Vector3.zero;
        }

        private void Update()
        {
            if(_targetTransform)
                normalEnemy.Move(_targetTransform, _minDistance, _speed);
           
            if (_player  && Vector3.Distance(_targetTransform.position, normalEnemy.Prefab.GetComponent<Transform>().position) <= _minDistance)
            {
                if(canShoot) {
                     canShoot = false;
                    _player.TakeDamage(normalEnemy.Shoot());
                    Debug.Log("SHOOT");
                    Invoke(nameof(Reloading), 3);
                }
             
            }
        }

        private void Reloading()
        {
            canShoot = true;
        }
     
    }
}