using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class ObstaclesView : MonoBehaviour
    {
        private ISnakeViewModel _snakeViewModel;
        public void Initialize(ISnakeViewModel snakeViewModel)
        {
            _snakeViewModel = snakeViewModel;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.GetComponent<SnakeView>() != null)
                _snakeViewModel.Kill();
        }
    }
}