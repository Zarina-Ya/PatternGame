using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject
{
    public abstract class GunBase
    {
        public Rigidbody _prefabBullet;
        public int _minDmg ;
        public int _maxDmg ;
        public int _missChance;
        public bool canShoot = true;
        public int Ammo { get; protected set; } = 10;
        public int Distance { get; protected set; }
        public virtual int Shoot() {
            if (Ammo > 0 && canShoot)
            {
                var miss = Random.Range(0, 100);
                if (miss < _missChance)
                    return 0;
                var dmg = Random.Range(_minDmg, _maxDmg);
                Ammo--;

                return dmg;
            }
            else return 0;
        }
    }
}