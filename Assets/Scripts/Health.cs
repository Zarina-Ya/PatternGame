using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class Health : MonoBehaviour
    {
        public float Max { get; }
        public float Current { get; private set; }
        public Health(float max, float current)
        {
            Max = max;
            Current = current;
        }
        public void ChangeCurrentHealth(float hp)
        {
            Current = hp;

        }
    }
}
