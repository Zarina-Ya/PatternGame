using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZarinkinProject { 
    public interface ICommand 
    {
        void Execute();
    }

    public class StartCommand : ICommand
    {
        private int _indexLevel;
        public StartCommand(int indexLevel) { _indexLevel = indexLevel; }

        public void Execute() => SceneManager.LoadScene(_indexLevel);
     
    }

    public class QuitCommand : ICommand
    {
        public void Execute()
        {
            Application.Quit();
        }
    }

}
