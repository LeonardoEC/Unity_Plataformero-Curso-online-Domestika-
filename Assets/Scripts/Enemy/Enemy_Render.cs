using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Render : MonoBehaviour
{
    SpriteRenderer _enemyRenderer;
    Animator _enemyAnimator;

    public System.Action OnShootFrame;

    void EnemyRenderOnline()
    {
        _enemyRenderer = GetComponent<SpriteRenderer>();
        _enemyAnimator = GetComponent<Animator>();
    }

    private void Awake()
    {
        EnemyRenderOnline();
    }

    public void EnemyFlipXState(bool flip)
    {
        _enemyRenderer.flipX = flip;
    }

    public void EnemyWalkinState(bool walk)
    {
        _enemyAnimator.SetBool("Idle", walk);
    }

    public void FrameShoot()
    {
        _enemyAnimator.SetTrigger("Shoot");
    }
    // Conectar por el animador
    public void UseEquipment()
    {
        OnShootFrame?.Invoke();
    }
}
