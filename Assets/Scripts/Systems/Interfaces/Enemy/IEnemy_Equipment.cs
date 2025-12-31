using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public enum EnemyEquipType
{
    None,
    Smallm,
    Medium
}
*/

public interface IEnemy_Equipment
{
    // EnemyEquipType TypeEnemyWeapon { get; }
    void EnemyUseEquipmentPrimary(int shoots, float delay);
    void OnFlipDirection(bool lookRight);

}
