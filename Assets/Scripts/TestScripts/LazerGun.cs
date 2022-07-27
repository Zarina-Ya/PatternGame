using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class LazerGun : GunBase
    {
        private readonly int _minDmg = 10;
        private readonly int _maxDmg = 40;
        private readonly int _missChance = 10;

        public LazerGun()
        {
            Distance = 30;
        }

        public override int Shoot()
        {
            if (Ammo > 0)
            {
                var miss = Random.Range(0, 100);
                if (miss < _missChance)
                    return 0;
                var dmg = Random.Range(_minDmg, _maxDmg);
                return dmg;
            }
            else return 0;
        }


    }
}