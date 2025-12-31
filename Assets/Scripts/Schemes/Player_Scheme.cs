using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GoldenLyonCodeFramework/PlayerData", fileName = "PlayerData", order = 1)]
public class Player_Scheme : ScriptableObject
{
    public string playerName;
    public Role_Scheme playerRole;
    public float playerHealth;
    public float playerSpeed;
    public float playerJumpForce;
    public GameObject playerEquipment;
    public Sprite[] playerSkin;
    public Sprite[] playerFaces;
}
