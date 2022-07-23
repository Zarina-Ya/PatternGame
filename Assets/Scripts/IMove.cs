using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove 
{
    float Speed { get; }
    void Move(float vertical);
}
