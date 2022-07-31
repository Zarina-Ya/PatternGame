using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class Player : MonoBehaviour { 

        private IMove _moveTransform;
        private IRotation _rotation;
        private Health Health { get; set; }
        [SerializeField] private float _speed;
        [SerializeField] private float _turnSpeed;

        private void Awake()
        {
            Health = new Health(100, 100);
        }

        public void TakeDamage(int damage)
        {
            if (Health.Current <= damage)
                Destroy(gameObject);
            else
            {
                Health.ChangeCurrentHealth((int)Health.Current - damage);
                Debug.Log(Health.Current);
            }
        }

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