using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public sealed class ViewPlayer
    {
        private GameObject _playerPrefab;
        private string _pathPlayer;

        public string PathPlayer { get => _pathPlayer; set => _pathPlayer = value; }
        public GameObject PlayerPrefab
        {
            get
            {
                if (_playerPrefab == null)
                {

                    GameObject player = Resources.Load<GameObject>(_pathPlayer);
                    _playerPrefab = Object.Instantiate(player);

                }
                return _playerPrefab;
            }
            set => _playerPrefab = value;
        }
    }
}
