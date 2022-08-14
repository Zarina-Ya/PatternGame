using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class GameObjectVisualBuilder : GameObjectBuilder
    {
        public GameObjectVisualBuilder(GameObject gameObject) : base(gameObject)
        { }
        public GameObjectVisualBuilder Name(string name)
        {
            _gameObject.name = name;
            return this;
        }
        //public GameObjectVisualBuilder Sprite(Sprite sprite)
        //{
        //    var component = GetOrAddComponent<SpriteRenderer>();
        //    component.sprite = sprite;
        //    return this;
        //}



        public GameObjectVisualBuilder MeshFilter(Mesh mesh)
        {
            var component = GetOrAddComponent<MeshFilter>();
            component.mesh = mesh;
            return this;
        }

        public GameObjectVisualBuilder MeshRenderer(Material material)
        {
            var component = GetOrAddComponent<MeshRenderer>();
            component.material = material;
            return this;
        }
        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _gameObject.GetComponent<T>();
            if (!result)
            {
                result = _gameObject.AddComponent<T>();
            }
            return result;
        }

    }
}