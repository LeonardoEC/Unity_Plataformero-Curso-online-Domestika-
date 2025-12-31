using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Main : MonoBehaviour
{
    Rigidbody2D _enemyRigidbody2D;
    // EnemeyScheme _enemyScheme;

    Enemy_IA _enemyIAController;
    Enemy_Equipment_Detector _enemyEquipmentDetector;
    Enemy_View_Manager _enemyViewManager;
    Enemy_Render _enemyRender;

    Enemy_Detector _enemyDetector;


    void EnemyComponets()
    {
        if(_enemyRigidbody2D == null)
        {
            _enemyRigidbody2D = GetComponent<Rigidbody2D>();
        }

        if (_enemyIAController == null)
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

        if (_enemyDetector == null)
        {
            _enemyDetector = GetComponentInChildren<Enemy_Detector>();
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
        // debe de pasar por el detector para saber como usar el equipo
        // mejorar nombre
        // volver esto mas generico
        _enemyRender.OnShootFrame = () =>
        {
            // esto sera el disparador de animacion por la funcion de animacion
            // debemos de mejorar esto para que sea mas generico y no dependa de un arma
            // debe de saber que equipo usar y como usarlo
            _enemyEquipmentDetector.EnemyUseWeapon(1, 0.1f);
        };

        _enemyDetector._onEnemyViewDetected = (enemyView) =>
        {
            _enemyIAController._enemyView = enemyView;
        };
    }

    void EnemySuscriptionExplicit()
    {
        if(_enemyIAController != null)
        {
            _enemyIAController._enemyRtihidBodyMain = _enemyRigidbody2D;
            //_enemyIAController._enemeyData = new Enemy_Data(_enemyScheme);
        }
    }
    private void OnEnable()
    {
        EnemyComponets();
        EnemySuscriptionBySignals();
        EnemySuscriptionExplicit();
        _enemyIAController.Initialize();
        StartCoroutine(_enemyIAController.PatrolToTarget());

    }

    private void OnDisable()
    {
        
    }

    private void Awake()
    {

    }

    void Start()
    {

    }

    private void FixedUpdate()
    {
        _enemyIAController.EnemyMovement();
    }

    private void Update()
    {
        _enemyIAController.TryAttack();
        _enemyDetector.EnemyVision();
    }
}
