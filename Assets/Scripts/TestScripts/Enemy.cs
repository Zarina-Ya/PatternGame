using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject {
    public class Enemy
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public Health Health { get; private set; }

        private GunBase _gun;
        private GameObject _prefab;


        public Enemy(string name, EnemyFactoryBase factoryBase)
        {
            if (string.IsNullOrEmpty(name) || factoryBase == null)
                throw new System.Exception("Error");
            Name = name;
            Type = factoryBase.Type;
            _gun = factoryBase.CreateGun();
            _prefab = factoryBase.CreateEnemy();
        }

        public int Shoot()
        {
            return _gun.Shoot();
        }

        public void Move() { }
        public void TakeDamage(int damage) {
            Health.ChangeCurrentHealth((int)Health.Current - damage);
        }

        public override string ToString()
        {
            return $"{Type} : {Name} ";

        }
    }
}
