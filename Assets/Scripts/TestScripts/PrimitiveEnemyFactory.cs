using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject
{
    public class PrimitiveEnemyFactory : EnemyFactoryBase
    {
        public PrimitiveEnemyFactory()
        {
            Type = "Primitive Enemy";
            Health = new Health(40, 40);
        }

        public override GameObject CreateEnemy()
        {
            return Object.Instantiate(Resources.Load<GameObject>("Enemy/PrimitiveEnemy"));
          
        }

        public override GunBase CreateGun()
        {
           return new BallGun();
        }
    }


}
