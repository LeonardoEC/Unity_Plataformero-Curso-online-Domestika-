using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Animator_Controller : MonoBehaviour
{
    Animator _playerAnimator;
    SpriteRenderer _playerSpriteRenderer;

    public System.Action<bool> _onPlayerAttaking;

    // ordenar esto y crear un metodo que gestione la duracion de las animaciones y estados para 
    // que no se pisen entre ellas


    public void AnimationInProgres()
    {
        AnimatorStateInfo state = _playerAnimator.GetCurrentAnimatorStateInfo(0);
        if(state.IsTag("Player_Attack"))
        {
            _onPlayerAttaking?.Invoke(true);
        }
        else
        {
            _onPlayerAttaking?.Invoke(false);
        }

        Debug.Log(state.IsTag("Player_Attack"));
    }

    void PlayerViewOnline()
    {
        if(_playerSpriteRenderer == null)
        {
            _playerSpriteRenderer = GetComponent<SpriteRenderer>();
        }
        if(_playerAnimator == null)
        {
            _playerAnimator = GetComponent<Animator>();
        }
    }

    void OnEnable()
    {
        PlayerViewOnline();
    }

    public void PlayerWalkinAnimation(bool playerWalkin)
    {
        _playerAnimator.SetBool("IsIdle", playerWalkin);
    }

    public void PlayerJumping(bool isJunping)
    {
        _playerAnimator.SetBool("IsJump", isJunping);
    }

    public void PlayerAttack()
    {
        _playerAnimator.SetTrigger("IsAttack");

    }

    public void PlayerFalling(float falleVelocity)
    {
        _playerAnimator.SetFloat("VerticalVelocity", falleVelocity);
    }
}
