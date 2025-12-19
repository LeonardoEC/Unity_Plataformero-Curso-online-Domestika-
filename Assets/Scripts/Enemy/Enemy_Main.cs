using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Main : MonoBehaviour
{
    Enemy_IA _enemyIAController;
    Enemy_Equipment_Detector _enemyEquipmentDetector;
    Enemy_View_Manager _enemyViewManager;
    Enemy_Render _enemyRender;

    void EnemyComponets()
    {
        if(_enemyIAController == null)
        {
            _enemyIAController = GetComponentInChildren<Enemy_IA>();
        }

        if(_enemyEquipmentDetector == null)
        {
            _enemyEquipmentDetector = GetComponentInChildren<Enemy_Equipment_Detector>();
        }
        if ( _enemyViewManager == null)
        {
            _enemyViewManager = GetComponentInChildren<Enemy_View_Manager>();
        }

        if (_enemyRender == null)
        {
            _enemyRender = GetComponentInChildren<Enemy_Render>();
        }
    }

    void EnemySuscriptionBySignals()
    {
        _enemyIAController.OnAnimationWalking = (walkin) =>
        {
            _enemyRender.EnemyWalkinState(!walkin);
        };
        _enemyIAController.OnAttack = () =>
        {
            _enemyRender.FrameShoot();
        };
        // Suscripcion externa
        _enemyRender.OnShootFrame = () =>
        {
            _enemyEquipmentDetector.EnemyUseWeapon(1, 0.1f);
        };
    }

    private void OnEnable()
    {
        EnemyComponets();
        EnemySuscriptionBySignals();
    }

    private void OnDisable()
    {
        
    }

    private void Awake()
    {

    }

    void Start()
    {
        _enemyIAController.Initialize();
        StartCoroutine(_enemyIAController.PatrolToTarget());

    }
}
