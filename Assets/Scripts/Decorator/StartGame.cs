using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private IFire _fire;
    [Header("Start Gun")]
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private Transform _barrelPosition;

    [Header("Muffler Gun")]
    [SerializeField] private float _volumeFireOnMuffler;
    [SerializeField] private Transform _barrelPositionMuffler;
    [SerializeField] private GameObject _muffler;

    private void Start()
    {

        IAmmunition ammunition = new Bullet(_bullet, 3.0f);
        var weapon = new Weapon(ammunition, _barrelPosition, 999.0f);
        var muffler = new Muffler(_volumeFireOnMuffler,
        _barrelPosition, _muffler);
        ModificationWeapon modificationWeapon = new
        ModificationMuffler( muffler, _barrelPositionMuffler.position);
        modificationWeapon.ApplyModification(weapon);
        _fire = modificationWeapon;

    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _fire.Fire();
        }
    }

}
