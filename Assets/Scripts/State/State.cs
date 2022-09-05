using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public abstract class State 
    {
       protected Context _context;
       protected int _speed;
       protected static NewPlayer _player;
       public void SetContext(Context context)
        {
            _context = context;
        }
        public void SetPlayer(NewPlayer player) => _player = player;

        public abstract void Handle();
    }
}