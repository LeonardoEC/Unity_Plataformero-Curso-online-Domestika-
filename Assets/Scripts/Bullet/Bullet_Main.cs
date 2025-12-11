using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Main : MonoBehaviour
{
    Bullet_Controller _bulletController;
    SpriteRenderer _bulletSpriteRenderer;
    Bullet_Render _bulletRender;

    float _startTime;
    public Vector2 bulletDirection;

    void BulletComponents()
    {
        if(_bulletController == null)
        {
            _bulletController = GetComponentInChildren<Bullet_Controller>();
            Debug.Log("Controllador de Bullet listo para usar");
        }

        if (_bulletSpriteRenderer == null)
        {
            _bulletSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
            Debug.Log("Render del Bullet listo para usar");
        }
        if(_bulletRender == null)
        {
            _bulletRender = GetComponentInChildren<Bullet_Render>();
        }

    }

    private void OnEnable()
    {
        _bulletController.BuilletLivingTimeOver(Bullet_Controller._bulletState.Disable, 2f);
    }

    private void OnDisable()
    {

    }
    
    private void Awake()
    {
        BulletComponents();
    }

    void Start()
    {
        _startTime = Time.time;
    }

    void Update()
    {
        _bulletController.BulletMovmenet(1f, bulletDirection);
    }

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        _bulletRender.BulletColor(_bulletSpriteRenderer, _startTime, 2f);
    }

    private void OnDestroy()
    {
        
    }
}
