using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject {
    public class FactoryMag
    {
        public Mag Create(Health health) => new Mag(health);
    }

    public class FactoryInfantry
    {
        public Infantry Create(Health health) => new Infantry(health);
    }

    public class Mag : Player
    {
        private float _magicDamage = 12;

        public Mag(Health health) => this.Health = health;
    }


    public class Infantry : Player
    {
        private float _damage = 5;
        public Infantry(Health health) => this.Health = health;
    }




 }