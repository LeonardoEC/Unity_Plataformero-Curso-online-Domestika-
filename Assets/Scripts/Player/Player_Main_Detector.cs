using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Main_Detector : MonoBehaviour
{
    Player_Grounded_Detector _playerGroundedDetector;
    public string playerGroundedState;
    public bool isPlayerInAir;

    void PlayerMainDetectorOnline()
    {
        _playerGroundedDetector = GetComponentInChildren<Player_Grounded_Detector>();
    }

    void PlayerStateSucrition()
    {
        _playerGroundedDetector._onGroundedStateChanged += (state) =>
        {
            playerGroundedState = state;
        };
        _playerGroundedDetector._onAir += (isAir) =>
        {
            isPlayerInAir = isAir;
        };
    }

    private void OnEnable()
    {
        PlayerMainDetectorOnline();
        PlayerStateSucrition();
    }
}
