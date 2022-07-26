using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject
{
    public abstract class GunBase
    {
        public int Ammo { get; protected set; } = 10;
        public int Distance { get; protected set; }
        public abstract int Shoot();
    }
}