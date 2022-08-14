using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject
{
    public class ViewService
    {
        private readonly Dictionary<string, ObjectPool> _viewCache = new Dictionary<string, ObjectPool>();


        public T Instantiate<T>(GameObject prefab)
        {
            if (!_viewCache.TryGetValue(prefab.name, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab);
                _viewCache[prefab.name] = viewPool;
            }

            if (viewPool.Pop().TryGetComponent(out T component))
                return component;

            throw new InvalidOperationException($"{typeof(T)} not found");
        }

        public void Destroy(GameObject value)
        {
            _viewCache[value.name].Push(value);
        }
    }
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _service—ontainer =
        new Dictionary<Type, object>();
        public static void SetService<T>(T value) where T : class
        {
            var typeValue = typeof(T);
            if (!_service—ontainer.ContainsKey(typeValue))
            {
                _service—ontainer[typeValue] = value;
            }
        }
        public static T Resolve<T>()
        {
            var type = typeof(T);
            if (_service—ontainer.ContainsKey(type))
            {
                return (T)_service—ontainer[type];
            }
            return default;
        }
    }
}