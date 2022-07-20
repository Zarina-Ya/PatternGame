using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject
{
    public sealed class ReferenceSceneObject
    {
        private GameObject _ground;
        private GameObject _gameObjectsScene;
        private string _pathGameObjects;
        private string _pathGround;


        public string PathGround { get => _pathGround; set => _pathGround = value; }
        public string PathGameObjects { get => _pathGameObjects; set => _pathGameObjects = value; }

        public GameObject Ground
        {
            get
            {
                if (_ground == null)
                {
                    
                    GameObject groundLevel = Resources.Load<GameObject>(_pathGround);
                    _ground = Object.Instantiate(groundLevel);

                }
                return _ground;
            }
            set => _ground = value;
        }

        public GameObject GameObjectsScene 
        { 
            get
            {
                if (_gameObjectsScene == null)
                {
                    GameObject gameObjectsScene = Resources.Load<GameObject>(_pathGameObjects);
                    _gameObjectsScene = Object.Instantiate(gameObjectsScene);
                }
                return _gameObjectsScene;
            }
            set => _gameObjectsScene = value; 
        }

       

    }
}
