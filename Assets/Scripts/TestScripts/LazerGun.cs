using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class LazerGun : GunBase
    {
        public LazerGun()
        {
            _minDmg = 10;
            _maxDmg = 40;
            _missChance = 10;
            Distance = 30;
            //_prefabBullet = rigidbody;
        }

        
    }
}