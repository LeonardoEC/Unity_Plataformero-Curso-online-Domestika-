using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Render : MonoBehaviour
{
    SpriteRenderer _enemyRenderer;
    Animator _enemyAnimator;
    GameObject _enemyDust;

    public System.Action OnShootFrame;

    void EnemyRenderOnline()
    {
        _enemyRenderer = GetComponent<SpriteRenderer>();
        _enemyAnimator = GetComponent<Animator>();
        _enemyDust = GetComponentInChildren<Transform>().Find("Dust")?.gameObject;
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
        _enemyDust.SetActive(!walk);
    }

    public void FrameShoot()
    {
        _enemyAnimator.SetTrigger("Shoot");
    }
    // Conectar por el animador
    // Mejorar el detector de accion y colocar un nombre mas generico
    // Implementar deteccion de elemento a usar y que aqui solo accione el usar sin importar el elemento
    // Cambiar nomrbe a useInAnimationFrame
    // Las animaciones son fijas por ender pueden efectuar acciones siempre y cuando tenga la animacion correspondiente con el item a usar
    // el detector debe de indicar que item usar y este metodo solo acciona el uso en el frame correspondiente
    public void UseEquipment()
    {
        OnShootFrame?.Invoke();
    }
}
