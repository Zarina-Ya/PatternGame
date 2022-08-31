using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class Context 
    {
       private State _state = null;
       private NewPlayer _player;
     

        public Context(State state, NewPlayer player) {
            _player = player;
            TransitionTo(state);
        
        }
        public void TransitionTo(State state) {
            _state = state;
            _state.SetContext(this);
            _state.SetPlayer(_player);
        }
        public void Request() => _state.Handle();

    }
}