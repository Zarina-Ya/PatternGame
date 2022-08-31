using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class NewPlayer : MonoBehaviour
    {
        private IMove _moveTransform;
        protected IRotation _rotation;
        [SerializeField] private float _speed;
        [SerializeField] protected float _turnSpeed;
        public float Speed { get => _speed; set => _speed = value; }
        public IMove MoveTransform { get => _moveTransform; set => _moveTransform = value; }

        private void Start()
        {
            _moveTransform = new MoveTransform(transform, _speed, GetComponent<Rigidbody>(), GetComponent<Animator>());
           
            _rotation = new RotationPlayer(transform, _turnSpeed);


        }

     
        private void Update()
        {
           
            _rotation.Rotation(Input.GetAxis("Horizontal"));
        }

      

        private void FixedUpdate()
        {
           
            _moveTransform.Move(Input.GetAxis("Vertical"));
            // _moveTransform.Move();
        }

    }
}