using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_IA : MonoBehaviour
{
    [SerializeField] float _enemySpeed = 1f;
    [SerializeField] float _enemyMinPositionX;
    [SerializeField] float _enemyMaxPositionX;
    [SerializeField] float _enemyWaitingTime = 2f;

    public System.Action<bool> OnAnimationWalking;
    public System.Action OnAttack;

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

    void FlipTarget()
    {
        if (_target.transform.position.x == _enemyMinPositionX)
            SetTargetToMax();
        else
            SetTargetToMin();
    }

    void SetTargetToMin()
    {
        _target.transform.position = new Vector2(_enemyMinPositionX, transform.position.y);
        Vector3 scale = transform.parent.localScale;
        scale.x = -Mathf.Abs(scale.x);
        transform.parent.localScale = scale;

    }

    void SetTargetToMax()
    {
        _target.transform.position = new Vector2(_enemyMaxPositionX, transform.position.y);
        Vector3 scale = transform.parent.localScale;
        scale.x = Mathf.Abs(scale.x);
        transform.parent.localScale = scale;

    }

    void TryAttack()
    {
        OnAttack?.Invoke();
    }


    public IEnumerator PatrolToTarget()
    {
        while (Vector2.Distance(transform.parent.position, _target.transform.position) > 0.05f)
        {
            Vector2 direction = _target.transform.position - transform.parent.position;
            transform.parent.Translate(direction.normalized * _enemySpeed * Time.deltaTime);
            OnAnimationWalking?.Invoke(true);

            yield return null;
        }


        OnAnimationWalking?.Invoke(false);
        FlipTarget();
        TryAttack();
        yield return new WaitForSeconds(_enemyWaitingTime);

        yield return PatrolToTarget();
    }

}
