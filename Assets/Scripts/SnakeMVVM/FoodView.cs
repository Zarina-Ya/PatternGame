using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    internal sealed class FoodView : MonoBehaviour
    {
        private ISnakeViewModel _snakeViewModel;
        public void Initialize(ISnakeViewModel snakeViewModel)
        {
            _snakeViewModel = snakeViewModel;
        }

        private void OnCollisionEnter(Collision collision)
        { 
            _snakeViewModel.IncreaseLength();
            Destroy(gameObject);
        }
    }
}