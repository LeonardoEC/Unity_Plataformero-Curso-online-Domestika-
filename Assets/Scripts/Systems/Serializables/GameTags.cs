using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GameTags
{
    // Entorno
    public const string GROUND = "Ground";
    // Entidades
    public const string PLAYER = "Player";
    public const string ENEMY = "Enemy";
    public const string NPC = "NPC";
    public const string WEAPON = "Weapon";
    public const string BULLET = "Bullet";
}

public static class NotGameTags
{
    // Entorno
    public const string NONE = "Untagged";
    public const string AIR = "Air";
}

public static class GameLayers
{
    public const string GROUND = "Ground";
    public const string PLAYER = "Player";
    public const string ENEMY = "Enemy";
}

public static class NotGameLayers
{
    public const string DEFAULT = "Default";
}
/*
static void AssignTagsAndLayers(GameObject gameObject)
{
    if(gameObject == null) return;
    if(gameObject.tag == Untagged)
    {
        switch gameObject.name
        {
            case "Player":
                gameObject.tag = GameTags.PLAYER;
                if (gameObject.CompareTag(GameTags.PLAYER))
                {
                    gameObject.layer = LayerMask.NameToLayer(GameLayers.PLAYER);
                }
                break;
            case "Ground":
                gameObject.tag = GameTags.GROUND;
                if (gameObject.CompareTag(GameTags.GROUND))
                {
                    gameObject.layer = LayerMask.NameToLayer(GameLayers.GROUND);
                }
                break;
            default:
                gameObject.tag = NotGameTags.NONE;
                if(gameObject.CompareTag(NotGameTags.NONE))
                {
                    gameObject.layer = LayerMask.NameToLayer(NotGameLayers.DEFAULT);
                }
                break;
        }
    }
}
*/
