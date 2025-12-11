using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{

    public enum _bulletState
    {
        Disable,
        Destroy
    }

    public void BulletMovmenet(float bulletSpeed, Vector2 bulletDirection)
    {
        transform.parent.transform.Translate(bulletDirection.normalized * bulletSpeed * Time.deltaTime);
    }

    void BulletDestroy()
    {
        Destroy(transform.parent.gameObject);
    }

    void BulletDisable()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void BuilletLivingTimeOver(_bulletState order, float _bulletLivinTime)
    {
        switch(order)
        {
            case _bulletState.Disable:
                Invoke(nameof(BulletDisable), _bulletLivinTime);
                break;
            case _bulletState.Destroy:
                Invoke(nameof(BulletDestroy), _bulletLivinTime);
                break;
            default:
                Debug.Log("Orden denegada, no se encuentra entre las opciones, las opciones disponible son Disable o Destroy");
                break;
        }
    }
}
