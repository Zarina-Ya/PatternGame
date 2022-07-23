using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlayer : IRotation
{
    private readonly Transform _transform;
    private readonly float _turnSpeed;
    public RotationPlayer(Transform transform, float turnSpeed)
    {
        _transform = transform;
        _turnSpeed = turnSpeed;
    }
    public void Rotation(float horizontal)
    {
        _transform.Rotate(_transform.up * horizontal * _turnSpeed);
    }

   
}
