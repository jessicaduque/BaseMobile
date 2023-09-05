using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch_Para_Movimento : Button
{
    Personagem Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();
    }

    void Update()
    {
        if (IsPressed())
        {
            Player.Mover();
        }
    }
}
