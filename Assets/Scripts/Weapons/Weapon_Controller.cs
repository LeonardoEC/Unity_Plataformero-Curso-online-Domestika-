using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Controller : MonoBehaviour
{

    public void WeaponShoot(GameObject munition, Transform firePoint, GameObject shooter)
    {
        if(munition != null && firePoint != null && shooter != null )
        {
            GameObject bullet = (Instantiate(munition, firePoint.position, Quaternion.identity)) as GameObject;
            Bullet_Main bulletMain = bullet.GetComponent<Bullet_Main>();

            if(shooter.transform.localScale.x < 0f)
            {
                bulletMain.bulletDirection = Vector2.left;
            }
            else
            {
                bulletMain.bulletDirection = Vector2.right;
            }
        }
    }
}
