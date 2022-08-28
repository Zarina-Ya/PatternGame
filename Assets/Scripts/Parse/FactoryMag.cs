using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject {

    public interface FactoryPlayer
    {
        Player Create(Health health);
    }
    public class FactoryMag 
    {
        public Mag Create(Health health) => new Mag(health) ;
    }

    public class FactoryInfantry 
    {
        public Infantry Create(Health health) => new Infantry(health);
    }

    public class FactoryArcher 
    {
        public Archer Create(Health health) => new Archer(health);
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



    public class Archer : Player
    {
        public Archer(Health health) => this.Health = health;

       
    }
 }