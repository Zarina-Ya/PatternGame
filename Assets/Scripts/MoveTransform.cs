using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public sealed class MoveTransform: IMove
    {
        private readonly Transform _transform;
        private readonly Rigidbody _rigidbody;
        private readonly Animator _animator;
        private Vector3 _move;
        public MoveTransform(Transform transform, float speed, Rigidbody rigidbody, Animator animator )
        {
            _transform = transform;
            Speed = speed;
            _rigidbody = rigidbody;
            _animator = 
                animator;
        }

        public float Speed { get; protected set; }


    //public void Rotate(float horizontal, float vertical)
    //{
    //    _transform.Rotate(_transform.up * horizontal * _turnSpeed);
    //    _move = _transform.forward * vertical;
    //    _animator.SetBool("AnimationWalk", _move != Vector3.zero);
    //}
        public void Move(float vertical)
        {
            var speed = Speed;
            _move = _transform.forward * vertical;
            _rigidbody.AddForce(_move * speed * 10, ForceMode.Acceleration);
            _animator.SetBool("AnimationWalk", _move != Vector3.zero);
        }
    }
}