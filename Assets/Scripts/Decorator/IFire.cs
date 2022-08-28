using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFire 
{
    public void Fire();
}
public interface IAmmunition
{
    Rigidbody BulletInstance { get; }
    float TimeToDestroy { get; }
}
public interface IMuffler
{
    float VolumeFireOnMuffler { get; }
    Transform BarrelPositionMuffler { get; }
    GameObject MufflerInstance { get; }
}

