using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public interface IObserver
    {
        void ReturnInformation(ISubject subject);
    }
}