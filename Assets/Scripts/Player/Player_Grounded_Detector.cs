using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Grounded_Detector : MonoBehaviour
{
    public System.Action<string> _onGroundedStateChanged;
    public System.Action<bool> _onAir;
    public LayerMask groundLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            _onGroundedStateChanged?.Invoke("Grounded");
            _onAir?.Invoke(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // si esta en agua, o el fuego, o el barro, etc.
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            _onGroundedStateChanged?.Invoke("Air");
            _onAir?.Invoke(true);
        }
    }
}
