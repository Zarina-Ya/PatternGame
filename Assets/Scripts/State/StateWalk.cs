using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class StateWalk : State
    {
        public override void Handle()
        {
            _speed = 10;
            _player.MoveTransform.Speed = 10;
            Debug.Log($"Walk, speed : {_speed}");
            _context.TransitionTo(new StateRun());
        }

      
    }

    public class StateRun : State
    {
        public override void Handle()
        {
            _speed = 50;
            Debug.Log($"Run, speed : {_speed}");
            _player.MoveTransform.Speed = _speed;
            _context.TransitionTo(new StateWalk());
        }
    }
}