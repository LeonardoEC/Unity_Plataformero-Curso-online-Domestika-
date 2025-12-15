using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Render : MonoBehaviour
{
    public SpriteRenderer _weaponRenderSprite;

    private void Awake()
    {
        _weaponRenderSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetSpriteWeapon(Sprite sprite)
    {
        _weaponRenderSprite.sprite = sprite;
    }
}
