using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Main : MonoBehaviour, IEnemy_Equipment
{

    // tiene que ser publicos para gestionar
    Weapon_Controller _wepaonController;
    Weapon_Render _weaponRender;

    // personales del weapon
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
    // esto se debe de cargar siempre que el arma este activa y al instante que este activa
    private void OnEnable()
    {
        WeaponComponents();
        _wepaonController.Initialize(_weaponScheme.weaponMunition, _weaponFirePoint, _weaponShooter);
    }

    private void OnDisable()
    {
        
    }

    // Quitar tiempos de ejecusion por que el arma ya no se auto gestiona
    // La gestiona el portador

    public void EnemyUseEquipmentPrimary(int shoots, float delay)
    {
        StartCoroutine(_wepaonController.WeaponMultipleShoot(shoots, delay));
    }

    public void OnFlipDirection(bool lookRight)
    {
        Vector3 scale = transform.localScale; 
        scale.x = lookRight ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
        transform.localScale = scale;

    }

}
