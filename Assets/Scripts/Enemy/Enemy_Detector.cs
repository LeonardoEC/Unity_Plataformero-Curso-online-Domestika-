using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Detector : MonoBehaviour
{
    public System.Action<string> _onEnemyViewDetected;
    public void EnemyVision()
    {
        Vector2 origin = transform.parent.position;
        Vector2 direction = transform.parent.localScale.x > 0 ? Vector2.right : Vector2.left;
        float distance = 3f;
        int layerMask = LayerMask.GetMask("Player");

        RaycastHit2D _enemyView = Physics2D.Raycast(origin, direction, distance, layerMask);

        Debug.DrawRay(origin, direction * distance, Color.yellow);

        if (_enemyView.collider != null)
        {
            if (_enemyView.collider.CompareTag(GameTags.PLAYER))
            {
                Debug.DrawRay(origin, direction * distance, Color.red);
                _onEnemyViewDetected?.Invoke(GameTags.PLAYER);
            }
        }
        else
        {
            Debug.DrawRay(origin, direction * distance, Color.yellow);
            _onEnemyViewDetected?.Invoke(NotGameTags.NONE);
        }

    }
}
