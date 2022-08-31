using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove 
{
    float Speed { get; set; }
    void Move(float vertical);
}
