using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class Player : MonoBehaviour { 

        private IMove _moveTransform;
        private IRotation _rotation;
     
        [SerializeField] private float _speed;
        [SerializeField] private float _turnSpeed;
       

     
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
        }
      
    }
}