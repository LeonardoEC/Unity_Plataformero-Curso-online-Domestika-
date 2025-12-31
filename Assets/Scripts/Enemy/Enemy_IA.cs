using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemy_IA : MonoBehaviour
{
    [SerializeField] float _enemySpeed = 5f;
    [SerializeField] float _enemyMinPositionX;
    [SerializeField] float _enemyMaxPositionX;
    [SerializeField] float _enemyWaitingTime = 2f;

    bool canMovement;

    public Rigidbody2D _enemyRtihidBodyMain;
    public Enemy_Data _enemeyData;

    public System.Action<bool> OnAnimationWalking;
    public System.Action OnAttack;

    GameObject _target;

    public string _enemyView;

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
        if(_enemyView == NotGameTags.NONE)
        {
            if (_target.transform.position.x == _enemyMinPositionX)
                SetTargetToMax();
            else
                SetTargetToMin();
        }

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



    public void TryAttack()
    {

        if (_enemyView == GameTags.PLAYER)
        {
            canMovement = false;
            OnAnimationWalking?.Invoke(false);
            OnAttack?.Invoke();
        }

    }

    public void EnemyMovement()
    {
        if(canMovement)
        {
            Vector2 direction = _target.transform.position - transform.parent.position;
            _enemyRtihidBodyMain.velocity = new Vector2(direction.normalized.x * _enemySpeed, _enemyRtihidBodyMain.velocity.y);
            OnAnimationWalking?.Invoke(true);
        }
        else
        {
            OnAnimationWalking?.Invoke(false);
            _enemyRtihidBodyMain.velocity = Vector2.zero;
        }
    }
    // mejorar para que el patruyage se detenga cuando vea al jugador

    public IEnumerator PatrolToTarget()
    {
        while(true)
        {
            while (Mathf.Abs(transform.parent.position.x - _target.transform.position.x) > 0.05f && _enemyView == NotGameTags.NONE)
            {
                canMovement = true;
                yield return null;

            }

            canMovement = false;
            FlipTarget();
            yield return new WaitForSeconds(_enemyWaitingTime);

        }

    }

}
