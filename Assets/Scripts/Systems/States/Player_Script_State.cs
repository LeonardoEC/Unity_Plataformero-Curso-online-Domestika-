using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script_State
{
    // se encarga de gestionar los componetes de cada entiedad y cada entindad ti su propio gestor
    // se debe incluir suscriptores y señales.
    // Todas las conecciones y comunicaciones de los componentes pasan por este gestor
    public Rigidbody2D rb = null;
    public Player_Main_Detector detector = null;
    public Player_Data data = null;


    public void ComponentsSubscription()
    {
        // suscripciones entre componentes del jugador
    }
}
