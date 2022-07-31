using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject {
    public abstract class EnemyFactoryBase
    {
        public Health Health { get; protected set; }
        public string Type { get; protected set; } = "Enemy";
        public abstract GunBase CreateGun();
        public abstract GameObject CreateEnemy();
    }

}