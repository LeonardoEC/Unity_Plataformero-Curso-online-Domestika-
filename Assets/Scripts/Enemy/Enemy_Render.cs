using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Render : MonoBehaviour
{
    SpriteRenderer _enemyRenderer;

    void EnemyRenderOnline()
    {
        _enemyRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Awake()
    {
        EnemyRenderOnline();
    }

    public void EnemyFlipXState(bool flip)
    {
        _enemyRenderer.flipX = flip;
    }

}
