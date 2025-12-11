using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Main : MonoBehaviour
{
    Weapon_Controller _wepaonController;

    [SerializeField]GameObject _weaponShooter;
    [SerializeField]GameObject _bulletPrefab;
    [SerializeField]Transform _weaponFirePoint;

    void WeaponComponents()
    {
        if(_wepaonController == null)
        {
            _wepaonController = GetComponentInChildren<Weapon_Controller>();
            Debug.Log("Controladroes del arma listos");
        }
        if(_weaponShooter == null)
        {
            _weaponShooter = GetComponentInParent<GameObject>();
        }
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Awake()
    {
        WeaponComponents();
    }

    void Start()
    {
        _wepaonController.WeaponShoot(_bulletPrefab, _weaponFirePoint, _weaponShooter);
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        
    }

    private void OnDestroy()
    {
        
    }
}
