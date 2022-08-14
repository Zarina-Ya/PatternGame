using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject {

    [System.Serializable]
    public class Enemy 
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public Health Health { get; private set; }
        public GameObject Prefab { get => _prefab; set => _prefab = value; }
        public GunBase Gun { get => _gun; }

        private GunBase _gun;
        private GameObject _prefab;


        public Enemy(string name, EnemyFactoryBase factoryBase)
        {
            if (string.IsNullOrEmpty(name) || factoryBase == null)
                throw new System.Exception("Error");
            Name = name;
            Type = factoryBase.Type;
            _gun = factoryBase.CreateGun();
            Prefab = factoryBase.CreateEnemy();

           
        }

        public int Shoot()
        {
            return Gun.Shoot();
        }

        public void Move(Transform target, float minDistance, float speed) {
            var enemyTransform = Prefab.GetComponent<Transform>().position;
            if ( Vector3.Distance(target.position, enemyTransform) < Gun.Distance && Vector3.Distance(target.position, enemyTransform) > minDistance)
            {
                Prefab.GetComponent<Transform>().position = Vector3.MoveTowards(enemyTransform, target.position, speed * Time.deltaTime);
            }
        }
        public void TakeDamage(int damage) {
            Health.ChangeCurrentHealth((int)Health.Current - damage);
        }

        public override string ToString()
        {
            return $"{Type} : {Name} ";

        }
    }
}
