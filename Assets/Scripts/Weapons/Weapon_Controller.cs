using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Controller : MonoBehaviour
{
    GameObject _munition;
    Transform _firePoint;
    GameObject _shooter;


    public void Initialize(GameObject munition, Transform firePoint, GameObject shooter)
    {
        _munition = munition;
        _firePoint = firePoint;
        _shooter = shooter;
    }

    Bullet_Main CreateMunition()
    {
        GameObject instance = Instantiate(_munition, _firePoint.position, Quaternion.identity);
        return instance.GetComponent<Bullet_Main>();
    }


    void ApplyDirection(Bullet_Main bullet)
    {
        if (_shooter.transform.localScale.x < 0f)
            bullet.bulletDirection = Vector2.left;
        else
            bullet.bulletDirection = Vector2.right;
    }

    void WeaponShoot()
    {
        Bullet_Main bullet = CreateMunition();
        ApplyDirection(bullet);
    }

    public IEnumerator WeaponMultipleShoot(int count, float delay)
    {
        for (int i = 0; i < count; i++)
        {
            WeaponShoot();
            yield return new WaitForSeconds(delay);
        }
    }

}
