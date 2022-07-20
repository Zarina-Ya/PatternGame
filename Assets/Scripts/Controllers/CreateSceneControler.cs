using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class CreateSceneControler : MonoBehaviour
    {
        private ReferenceSceneObject _reference;
        [SerializeField] string _groundPath = "LevelObject/Ground";
        [SerializeField] string _gameObjectsPath = "LevelObject/GameObjectsScene";
        private void Awake()
        {
            _reference = new ReferenceSceneObject();

            _reference.PathGround = _groundPath;
            _reference.PathGameObjects = _gameObjectsPath;
        }
        void Start()
        {
            var ground = _reference.Ground;
            var gameObjectsScene = _reference.GameObjectsScene;
        }

    }
}
