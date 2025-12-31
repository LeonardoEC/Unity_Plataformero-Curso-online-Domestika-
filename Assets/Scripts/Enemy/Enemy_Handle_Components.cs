using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Handle_Components
{
    // Componentes basicos
    public Rigidbody2D enemyRigidBody;
    public Collider2D enemyCollider;
    // Componentes de gestion
    public Enemy_IA enemyIAController;
    public Enemy_Render enemyRender;
    public Enemy_Equipment_Detector enemyEquipmentDetector;
    public Enemy_View_Manager enemyViewManager;
    // Datos del elemento
    public Enemy_Data enemyData;
    /*
    public EnemyData(EnemeySchema enemeyScheme)
    {
        if(enemyData == null)
        {
            enemyData = new Enemy_Data(enemeyScheme);
        }
    }
    */

    public void EnemyConponentSuscription()
    {
        enemyIAController.OnAnimationWalking = (walkin) =>
        {
            enemyRender.EnemyWalkinState(!walkin);
        };
        enemyIAController.OnAttack = () =>
        {
            enemyRender.FrameShoot();
        };
        // Suscripcion externa
        // debe de pasar por el detector para saber como usar el equipo
        // mejorar nombre
        // volver esto mas generico
        enemyRender.OnShootFrame = () =>
        {
            // esto sera el disparador de animacion por la funcion de animacion
            // debemos de mejorar esto para que sea mas generico y no dependa de un arma
            // debe de saber que equipo usar y como usarlo
            enemyEquipmentDetector.EnemyUseWeapon(1, 0.1f);
        };
    }
}
