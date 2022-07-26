using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject
{
   public class GameStarter : MonoBehaviour
   {
        private void Start()
        {
            //EnemyBase.CreateEnemy(new Health(100.0f, 100.0f));

            Enemy enemy = new Enemy("TEstEnemy", new PrimitiveEnemyFactory());
        }
    

   }
}