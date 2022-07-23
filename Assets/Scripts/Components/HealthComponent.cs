using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class HealthComponent : IComponent
    {
        public float _health;
        public bool _isDead;
        public float _maxHealth = 100;
    }
}
