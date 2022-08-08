using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject {
    public class BallGun : GunBase
    {
        public BallGun()
        {
            _minDmg = 10;
            _maxDmg = 40;
            _missChance = 10;
            Distance = 20;
            //_prefabBullet = rigidbody;
        }
  
    }

}