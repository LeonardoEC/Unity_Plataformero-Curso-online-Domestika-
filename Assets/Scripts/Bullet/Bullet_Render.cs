using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Render : MonoBehaviour
{
    Color _inicialColor = Color.white;
    Color _FinalColor = Color.black;

    public void BulletColor(SpriteRenderer sprite, float startTime, float livinTime)
    {
        float diferenciaDeTiempo = Time.time - startTime;
        float porcentajeDeTiempo = diferenciaDeTiempo / livinTime;

        sprite.color = Color.Lerp(_inicialColor, _FinalColor, porcentajeDeTiempo);
    }
}
