using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class EnemySubject : MonoBehaviour, ISubject
    {
        public bool State { get; set; }
        private List<IObserver> _observers = new List<IObserver>();
        public void Attach(IObserver observer) => _observers.Add(observer);
        public void Detach(IObserver observer) => _observers.Remove(observer);

        public void Noyify()
        {
            foreach (var observer in _observers)
                observer.ReturnInformation(this);
        }

        private void OnMouseDown()
        {
            State = false;
            Noyify();
            Destroy(gameObject);
        }
       
    }
}