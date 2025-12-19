using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Equipment_Detector : MonoBehaviour
{
    IEnemy_Equipment enemy_Equipment;

    private void OnEnable()
    {
        EquipmentEnemyDetector();
    }

    void EquipmentEnemyDetector()
    {
        enemy_Equipment = GetComponentInChildren<IEnemy_Equipment>();
    }


    public void EnemyUseWeapon(int shoots, float delay)
    {
        Debug.Log("Arma recibió orden de disparar");
        enemy_Equipment?.EnemyUseEquipmentPrimary(shoots, delay);
    }
    public void OnFlipDirection(bool lookRight)
    {
        Debug.Log("Detector: reenviando flip al equipamiento");
        enemy_Equipment?.OnFlipDirection(lookRight);
    }

}
