using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponType
{
    Small,
    Medium,
    Heavy,
    Big
}

[CreateAssetMenu(menuName = "GoldenLyonCodeFramework/WeaponData", fileName ="WeaponData", order =0)]
public class Weapon_Scheme : ScriptableObject
{
    // darle un nombre y un tag para identificar tambien ademas de usar mejor el id para identificar y un
    // id para modificar en caso de querer personalizar
    private int idWeapon;
    public WeaponType weaponType;
    public GameObject weaponMunition;
    public Sprite weaponSkin;
}
