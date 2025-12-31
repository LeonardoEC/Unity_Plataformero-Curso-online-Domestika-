using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn_Manager : MonoBehaviour
{
    [Header("Enemy Spawn Settings")]
    [SerializeField]GameObject[] _enemyActors;
    [SerializeField]int _maxEnemies = 5;

    List<GameObject> _spawnedEnemies = new List<GameObject>();

    private void OnEnable()
    {
        InitializeEnemySpanw();
        StartCoroutine(EnemySpawnRoutine());
    }

    void InitializeEnemySpanw()
    {
        int randomIndexEnemy = Random.Range(0,_enemyActors.Length);
        for (int i = 0; i < _maxEnemies; i++)
        {
            GameObject _enemy = Instantiate(_enemyActors[randomIndexEnemy]);
            _enemy.SetActive(false);
            _spawnedEnemies.Add(_enemy);
        }
    }

    GameObject GetPooledEnemy()
    {
        foreach(var enemy in _spawnedEnemies)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }
        return null;
    }

    void SpanwEnemy()
    {
        GameObject enemy = GetPooledEnemy();
        if(enemy != null)
        {
            enemy.transform.position = transform.position;
            enemy.SetActive(true);
        }
    }

    IEnumerator EnemySpawnRoutine()
    {
        while(true)
        {
            SpanwEnemy();
            yield return new WaitForSeconds(2f);
        }
    }

}
