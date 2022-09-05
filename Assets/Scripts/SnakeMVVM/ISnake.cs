using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZarinkinProject
{
    public interface ISnake 
    {

        public int LengthSnake { get; set; }
        public bool IsDead { get; set; }
        public string Name { get; }
    }

    internal sealed class SnakeModel : ISnake
    {
        public int LengthSnake { get; set; }

        public string Name { get; }
        public bool IsDead { get; set ; }

        public SnakeModel(string name)
        {
            Name = name;
            LengthSnake = 0;
        }
    }

    public interface ISnakeViewModel
    {
        ISnake SnakeModel { get; }
        
        void IncreaseLength();
        void Kill();
        event Action OnLenghtChange;
        event Action OnChangeState;
    }

    internal sealed class SnakeViewModel : ISnakeViewModel
    {
        
   
        public event Action OnLenghtChange;
        public event Action OnChangeState;

        public ISnake SnakeModel { get; }


        public SnakeViewModel(ISnake snakeModel)
        {
            SnakeModel = snakeModel;
        }
       
        public void IncreaseLength()
        {
            SnakeModel.LengthSnake += 1;
            OnLenghtChange?.Invoke();
        }

        public void Kill()
        {
            SnakeModel.IsDead = false;
            OnChangeState?.Invoke();
        }
    }

   

  
}