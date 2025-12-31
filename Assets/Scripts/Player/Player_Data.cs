using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Data
{
    public Player_Scheme template;
    public Role_Scheme role;
    public float currentHealth;
    public float currentSpeed;
    public float currentJumpForce;

    public Player_Data(Player_Scheme template)
    {
        this.template = template;
        this.role = template.playerRole;
        currentHealth = template.playerHealth;
        currentSpeed = template.playerSpeed;
        currentJumpForce = template.playerJumpForce;
    }
}
