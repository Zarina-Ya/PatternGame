using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    internal sealed class SnakeView : MonoBehaviour
    {
        private ISnakeViewModel _snakeViewModel;

        public GameObject SnakeBody;
        public List<GameObject> BodySnake = new List<GameObject> { };
        public float speed = 0.1f;
        public float rotationSpeed = 0.5f;

        public float _distanse;
        public void Initialize(ISnakeViewModel snakeViewModel)
        {
            _snakeViewModel = snakeViewModel;
            _snakeViewModel.OnLenghtChange += OnLenghtChange;
            _snakeViewModel.OnChangeState += OnChangeState;
        }
        private void OnLenghtChange()
        {
            BodySnake.Add(Instantiate(SnakeBody));
        }
        private void OnChangeState()
        {
            foreach (var snake in BodySnake)
                Destroy(snake);
             Destroy(gameObject);
        }


        public void Update()
        {
            MoveSnake();
            RotateSnake(Input.GetAxis("Horizontal"));
        }

        private void MoveSnake()
        {
            var sqrDistance = _distanse * _distanse;
            var positionPrevios = transform.position;
           
            foreach (var bone in BodySnake)
            {
                if ((bone.transform.position - positionPrevios).sqrMagnitude > sqrDistance)
                {
                    var tmp = bone.transform.position;
                    bone.transform.position = positionPrevios;
                    positionPrevios = tmp;
                }
                else break;
            }
            transform.position = transform.position + transform.forward * speed;
        }
        private void RotateSnake(float angel) => transform.Rotate(0f, angel, 0f);

        ~SnakeView()
        {
            _snakeViewModel.OnLenghtChange -= OnLenghtChange;
        }

    }
}