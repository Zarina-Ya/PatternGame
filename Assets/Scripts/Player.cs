using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class Player
    {
        private List<IComponent> _components = new List<IComponent>();
        public void AddComponent(IComponent component)
        {
            _components.Add(component);
            
        }
    }
}