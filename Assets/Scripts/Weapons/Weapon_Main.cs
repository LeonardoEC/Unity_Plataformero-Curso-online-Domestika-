using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Main : MonoBehaviour
{
    Weapon_Controller _wepaonController;
    Weapon_Render _weaponRender;
    [SerializeField]Weapon_Scheme _weaponScheme;

    [SerializeField]GameObject _weaponShooter;
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
        if(_weaponScheme == null)
        {
            Debug.Log("No se encontro datos sobre el arma, revisar el inspcetor");
        }
        if(_weaponRender == null)
        {
            _weaponRender = GetComponentInChildren<Weapon_Render>();
            if(_weaponRender._weaponRenderSprite.sprite == null)
            {
                _weaponRender.SetSpriteWeapon(_weaponScheme.weaponSkin);
            }
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
        _wepaonController.Initialize(_weaponScheme.weaponMunition, _weaponFirePoint, _weaponShooter);
    }

    void Start()
    {

        StartCoroutine(_wepaonController.WeaponMultipleShoot(1, 0.1f));
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
