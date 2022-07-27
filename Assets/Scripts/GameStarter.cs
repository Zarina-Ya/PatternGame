using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject
{
   public class GameStarter : MonoBehaviour
   {
        Enemy primitiveEnemy;
        Enemy normalEnemy;
        [SerializeField] Transform _target;
        [SerializeField] float _minDistance;
        [SerializeField] float _speed;
        private void Start()
        {
            primitiveEnemy = new Enemy("TEstEnemy", new PrimitiveEnemyFactory());
            normalEnemy = new Enemy("TEstNormalEnemy", new NormalEnemyFactory());

            _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        private void Update()
        {
            normalEnemy.Move(_target, _minDistance, _speed);
        }


    }
}