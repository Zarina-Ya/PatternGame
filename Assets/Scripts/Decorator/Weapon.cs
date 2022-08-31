using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : IFire
{
    private Transform _barrelPosition;
    private IAmmunition _bullet;
    private float _force;
 
    public Weapon(IAmmunition bullet, Transform barrelPosition, float force)
    {
        _bullet = bullet;
        _barrelPosition = barrelPosition;
        _force = force;
  
    }
    public void SetBarrelPosition(Transform barrelPosition)
    {
        _barrelPosition = barrelPosition;
    }
    public void SetBullet(IAmmunition bullet)
    {
        _bullet = bullet;
    }
    public void SetForce(float force)
    {
        _force = force;
    }

    public void Fire()
    {
        var bullet = Object.Instantiate(_bullet.BulletInstance,
        _barrelPosition.position, Quaternion.identity);
        bullet.AddForce(_barrelPosition.forward * _force);
        Object.Destroy(bullet.gameObject, _bullet.TimeToDestroy);
       
    }
}
internal sealed class Bullet : IAmmunition
{
    public Rigidbody BulletInstance { get; }
    public float TimeToDestroy { get; }
    public Bullet(Rigidbody bulletInstance, float timeToDestroy)
    {
        BulletInstance = bulletInstance;
        TimeToDestroy = timeToDestroy;
    }
}
internal abstract class ModificationWeapon : IFire
{
    private Weapon _weapon;
    protected abstract Weapon AddModification(Weapon weapon);
    public void ApplyModification(Weapon weapon)
    {
        _weapon = AddModification(weapon);
    }
    public void Fire()
    {
        _weapon.Fire();
    }
}
internal sealed class ModificationMuffler : ModificationWeapon
{
    
    private readonly IMuffler _muffler;
    private readonly Vector3 _mufflerPosition;
    public ModificationMuffler( IMuffler muffler,
    Vector3 mufflerPosition)
    {
        _muffler = muffler;
        _mufflerPosition = mufflerPosition;
    }
    protected override Weapon AddModification(Weapon weapon)
    {
        var muffler = Object.Instantiate(_muffler.MufflerInstance,
        _mufflerPosition, Quaternion.identity);
        weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
        return weapon;
    }
}

internal sealed class Muffler : IMuffler
{
    public float VolumeFireOnMuffler { get; }
    public Transform BarrelPositionMuffler { get; }
    public GameObject MufflerInstance { get; }
    public Muffler( float volumeFireOnMuffler,
    Transform barrelPositionMuffler, GameObject mufflerInstance)
    {
        VolumeFireOnMuffler = volumeFireOnMuffler;
        BarrelPositionMuffler = barrelPositionMuffler;
        MufflerInstance = mufflerInstance;
    }
}
