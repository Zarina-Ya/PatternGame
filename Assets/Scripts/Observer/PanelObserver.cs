using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace ZarinkinProject
{
    public class PanelObserver : MonoBehaviour, IObserver
    {
        public void ReturnInformation(ISubject subject)
        {
            GetComponentInChildren<TMP_Text>().text = $"Dead {(subject as EnemySubject).name}";
        }
    }
}