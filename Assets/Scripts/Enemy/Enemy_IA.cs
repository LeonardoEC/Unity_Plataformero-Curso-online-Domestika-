using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_IA : MonoBehaviour
{
    [SerializeField] float _enemySpeed = 1f;
    [SerializeField] float _enemyMinPositionX;
    [SerializeField] float _enemyMaxPositionX;
    [SerializeField] float _enemyWaitingTime = 2f;

    public System.Action<bool> OnLookDirectionChanged;

    GameObject _target;

    public void Initialize()
    {
        CreateTarget();
        SetTargetToMin();
    }

    void CreateTarget()
    {
        if (_target == null)
        {
            _target = new GameObject("Target");
        }
    }

    void SetTargetToMin()
    {
        _target.transform.position = new Vector2(_enemyMinPositionX, transform.position.y);
        OnLookDirectionChanged?.Invoke(false);
    }

    void SetTargetToMax()
    {
        _target.transform.position = new Vector2(_enemyMaxPositionX, transform.position.y);
        OnLookDirectionChanged?.Invoke(true);
    }

    void FlipTarget()
    {
        if (_target.transform.position.x == _enemyMinPositionX)
            SetTargetToMax();
        else
            SetTargetToMin();
    }

    public IEnumerator PatrolToTarget()
    {
        while (Vector2.Distance(transform.parent.position, _target.transform.position) > 0.05f)
        {
            Vector2 direction = _target.transform.position - transform.parent.position;
            transform.parent.Translate(direction.normalized * _enemySpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(_enemyWaitingTime);

        FlipTarget();
        yield return PatrolToTarget();
    }

}
