using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class NormalEnemyFactory : EnemyFactoryBase
    {
        public NormalEnemyFactory()
        {
            Type = "Normal Enemy";
            Health = new Health(80, 80);
        }

        public override GameObject CreateEnemy()
        {
            return Object.Instantiate(Resources.Load<GameObject>("Enemy/NormalEnemy"));

        }

        public override GunBase CreateGun()
        {
            return new LazerGun();
        }
    }
}