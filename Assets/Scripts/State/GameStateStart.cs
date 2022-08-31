using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject {
    public class GameStateStart : MonoBehaviour
    {
        [SerializeField] GameObject _player;
        Context context;
        void Awake()
        {
            context = new Context(new StateWalk(), _player.GetComponent<NewPlayer>());
        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
                context.Request();
        }

    }
}

