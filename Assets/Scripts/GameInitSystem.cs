using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class GameInitSystem : MonoBehaviour
    {
        private Player _player;
        private void Awake()
        {
            _player = new Player();
            _player.AddComponent(new MovableComponent());
            _player.AddComponent(new AminatedCharacterComponent());

            
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
