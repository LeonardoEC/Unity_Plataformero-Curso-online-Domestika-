using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_Movement : MonoBehaviour
{
    Vector2 _playerDirectionMovement;
    float _playerSpeed = 1f;
    float _playerJumpForce = 5f;

    public System.Action<bool> onPlayerStateIdle;
    public System.Action onPlayerAttacking;
    

    float horizontalInput;
    bool playerJumping;
    public bool attakingInProgress;
    public bool playerAttack;

    // implementar un activador y desactiviador de inputs para cuando se abran menus o se pause el juego, tambien para restricciones de movimiento en ciertas areas o durante ciertas animaciones
    public void PlayerInpunt(bool onAir)
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && onAir == false)
        {
            playerJumping = true;
        }
        if(Input.GetMouseButtonDown(0) && onAir == false && playerAttack == false)
        {
            playerAttack = true;
        }

    }

    void SetPlayerFlip()
    {
        if(_playerDirectionMovement.x >= 1)
        {
            transform.parent.localScale = new Vector3(1, transform.parent.localScale.y, transform.parent.localScale.x);
        }
        if(_playerDirectionMovement.x <= -1)
        {
            transform.parent.localScale = new Vector3(-1, transform.parent.localScale.y, transform.parent.localScale.x);
        }
    }

    public void SetIdleAnimation()
    {
        if (_playerDirectionMovement == Vector2.zero)
        {
            onPlayerStateIdle?.Invoke(true);
        }
        else
        {
            onPlayerStateIdle?.Invoke(false);
        }
    }

    public void PlayerMovement(Rigidbody2D playerRB)
    {
        if(attakingInProgress == false)
        {
            _playerDirectionMovement = new Vector2(horizontalInput, 0f).normalized * _playerSpeed;
            playerRB.velocity = new Vector2(_playerDirectionMovement.x, playerRB.velocity.y);

            SetIdleAnimation();
            SetPlayerFlip();
        }

    }

    public void PlayerJumping(Rigidbody2D playerRB, string grounde)
    {
        if(playerJumping && grounde == "Grounded" && attakingInProgress == false)
        {
            playerRB.AddForce(Vector2.up * _playerJumpForce, ForceMode2D.Impulse);
            playerJumping = false;
        }

    }

    public void PlayerAttack(Rigidbody2D playerRB)
    {
        if(!playerAttack) return;
        if(attakingInProgress == false)
        {
            _playerDirectionMovement = Vector2.zero;
            playerRB.velocity = Vector2.zero;
            onPlayerAttacking?.Invoke();
            playerAttack = false;
        }
    }
}
