using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class MovableComponent : IComponent
    {
        public float _moveSpeed;
        public bool _isMoving;
        public Vector3 _moveDirection;
    }
}