using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject
{
     public abstract class EnemyBase : MonoBehaviour
     {
        public Health Health { get; private set; }
        public static EnemyBase CreateEnemy(Health hp)
        {
            GameObject enemyPrefab = Object.Instantiate(Resources.Load<GameObject>("Enemy/PrimitiveEnemy"));
            if (enemyPrefab == null)
            {
                Debug.Log("Chego richish?");
                return null;
            }
            var enemy = enemyPrefab.AddComponent<PrimitiveEnemy>();
            enemy.Health = hp;
            return enemy;
        }
    }
}