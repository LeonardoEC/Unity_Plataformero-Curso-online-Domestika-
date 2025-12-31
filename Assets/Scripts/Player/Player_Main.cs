using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Main : MonoBehaviour
{
    public Player_Scheme _playerSchema;
    Player_Data _playerData;

    Rigidbody2D _playerRigidBody;
    Collider2D _playerCollider;

    Player_Main_Detector _playerMainDetector;
    Player_Controller_Movement _playerControllers;
    Player_Animator_Controller _playerAnimatorController;

    Player_Script_State _playerScriptState;

    void PlayerComponentsOnLoad()
    {
        if(_playerRigidBody == null)
        {
            _playerRigidBody = GetComponent<Rigidbody2D>();
        }

        if(_playerCollider == null)
        {
            _playerCollider = GetComponent<Collider2D>();
        }

        if (_playerControllers == null)
        {
            _playerControllers = GetComponentInChildren<Player_Controller_Movement>();
        }
        if (_playerMainDetector == null)
        {
            _playerMainDetector = GetComponentInChildren<Player_Main_Detector>();
        }

        if(_playerAnimatorController == null)
        {
            _playerAnimatorController = GetComponentInChildren<Player_Animator_Controller>();
        }
    }

    void PlayerSuscription()
    {
        _playerControllers.onPlayerStateIdle = (idle) =>
        {
            _playerAnimatorController?.PlayerWalkinAnimation(idle);
        };

        _playerAnimatorController._onPlayerAttaking = (attaking) =>
        {
            _playerControllers.attakingInProgress = attaking;
        };

        _playerControllers.onPlayerAttacking = () =>
        {
            _playerAnimatorController?.PlayerAttack();
        };
    }

    void PlayerInitialice()
    {
        gameObject.tag = GameTags.PLAYER;
        gameObject.layer = LayerMask.NameToLayer(GameLayers.PLAYER);
        _playerData = new Player_Data(_playerSchema);
        // maquina de estados de componentes
        // controllar los componentes y las sucripciones
        _playerScriptState = new Player_Script_State()
        {
            rb = _playerRigidBody,
            detector = _playerMainDetector,
            data = _playerData
        };
        _playerControllers?.Initialice(_playerScriptState);
    }



    void OnEnable()
    {
        PlayerComponentsOnLoad();
        PlayerSuscription();
        PlayerInitialice();
    }

    void OnDisable()
    {
        
    }

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerControllers.PlayerInpunt(_playerMainDetector.isPlayerInAir);
        _playerControllers.PlayerAttack(_playerRigidBody);
        _playerAnimatorController.AnimationInProgres();
    }

    void FixedUpdate()
    {
        _playerControllers.PlayerMovement();
        _playerControllers.PlayerJumping(_playerRigidBody, _playerMainDetector.playerGroundedState, _playerData.currentJumpForce);

    }

    void LateUpdate()
    {
        _playerAnimatorController.PlayerJumping(_playerMainDetector.isPlayerInAir);
        _playerAnimatorController.PlayerFalling(_playerRigidBody.velocity.y);
    }

    void OnDestroy()
    {
        
    }
}

