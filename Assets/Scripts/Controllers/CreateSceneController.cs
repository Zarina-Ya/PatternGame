using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class CreateSceneController : MonoBehaviour
    {
        private ReferenceSceneObject _reference;
        [SerializeField] string _groundPath = "LevelObject/Ground";
        [SerializeField] string _gameObjectsPath = "LevelObject/GameObjectsScene";

        private ViewPlayer _viewPlayer;
        [SerializeField] private string _playerPrefabPath;
        private void Awake()
        {
            _reference = new ReferenceSceneObject();

            _reference.PathGround = _groundPath;
            _reference.PathGameObjects = _gameObjectsPath;


            _viewPlayer = new ViewPlayer();
            _viewPlayer.PathPlayer = _playerPrefabPath;
        }
        void Start()
        {
            var ground = _reference.Ground;
            var gameObjectsScene = _reference.GameObjectsScene;
            var player = _viewPlayer.PlayerPrefab;
        }

    }
}
