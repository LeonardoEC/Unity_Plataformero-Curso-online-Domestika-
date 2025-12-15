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
    private int idWeapon;
    public WeaponType weaponType;
    public GameObject weaponMunition;
    public Sprite weaponSkin;
}
