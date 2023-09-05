using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch_Para_Movimento : Button
{
    Movimento Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimento>();
    }

    void Update()
    {
        if (IsPressed())
        {
            Player.Mover();
        }
    }
}
