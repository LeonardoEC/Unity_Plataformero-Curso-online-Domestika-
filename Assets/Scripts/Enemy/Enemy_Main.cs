using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Main : MonoBehaviour
{
    Enemy_IA _enemyIAController;
    Enemy_Render _enemyRender;

    void EnemyComponets()
    {
        if(_enemyIAController == null)
        {
            _enemyIAController = GetComponentInChildren<Enemy_IA>();
        }
        if(_enemyRender == null)
        {
            _enemyRender = GetComponentInChildren<Enemy_Render>();

            _enemyIAController.OnLookDirectionChanged = (lookRight) =>
            {
                _enemyRender.EnemyFlipXState(!lookRight);
            };
        }
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Awake()
    {
        EnemyComponets();
    }

    // Start is called before the first frame update
    void Start()
    {
        _enemyIAController.Initialize();
        StartCoroutine(_enemyIAController.PatrolToTarget());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
