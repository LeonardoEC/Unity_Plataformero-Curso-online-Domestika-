using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Controller : MonoBehaviour
{
    GameObject _munition;
    Transform _firePoint;
    GameObject _shooter;

    int _bulletPoolSize = 5;
    List<GameObject> _bulletPool = new List<GameObject>();

    public void Initialize(GameObject munition, Transform firePoint, GameObject shooter)
    {
        _munition = munition;
        _firePoint = firePoint;
        _shooter = shooter;
        InitializeBulletPool();
    }
    void InitializeBulletPool()
    {
        _bulletPool.Clear();

        for (int i = 0; i < _bulletPoolSize; i++)
        {
            GameObject bulletInstance = Instantiate(_munition, _firePoint.position, Quaternion.identity);
            bulletInstance.SetActive(false);
            _bulletPool.Add(bulletInstance);
        }
    }

    GameObject GetBulletFromPool()
    {
        foreach (var bullet in _bulletPool)
        {
            if (!bullet.activeInHierarchy)
                return bullet;
        }

        // Opcional: si querés que la pool sea elástica, podrías instanciar una nueva acá.
        // Por ahora, si no hay balas, devolvemos null.
        return null;
    }



    Bullet_Main CreateMunition()
    {
        /* obsoleto
        GameObject instance = Instantiate(_munition, _firePoint.position, Quaternion.identity);
        return instance.GetComponent<Bullet_Main>();
        */
        GameObject bulletGO = GetBulletFromPool();
        if (bulletGO == null)
            return null; // no hay balas disponibles

        bulletGO.transform.position = _firePoint.position;
        bulletGO.transform.rotation = Quaternion.identity;
        bulletGO.SetActive(true);

        return bulletGO.GetComponent<Bullet_Main>();

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
        if (bullet == null) return;
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
