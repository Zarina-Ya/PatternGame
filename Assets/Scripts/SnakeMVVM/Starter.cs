using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private SnakeView _snakeView;
        [SerializeField] private List<FoodView> _foodsView = new List<FoodView>();
        [SerializeField] private List<ObstaclesView> _obstaclesView = new List<ObstaclesView>();
        private void Start()
        {
            var snakeModel = new SnakeModel("Snake");
            var snakeViewModel = new SnakeViewModel(snakeModel);
            _snakeView.Initialize(snakeViewModel);

            foreach (var food in _foodsView)
                food.Initialize(snakeViewModel);

            foreach (var obstacle in _obstaclesView)
            {
                obstacle.Initialize(snakeViewModel);
            }
        } }
}