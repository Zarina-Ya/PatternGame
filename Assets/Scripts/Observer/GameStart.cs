using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject {
    public class StartGameState : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _subjects = new List<GameObject>();
        [SerializeField] private GameObject _observer;
        void Start()
        {
            foreach (GameObject subject in _subjects)
            {
                subject.GetComponent<ISubject>().Attach(_observer.GetComponent<IObserver>());
            }
        }

       
    }
}