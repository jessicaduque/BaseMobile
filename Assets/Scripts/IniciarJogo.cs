using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IniciarJogo : Button
{
    private GameControlador GC;
    private bool apertado = false;

    void Start()
    {
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControlador>();
    }

    void Update()
    {
        if (apertado)
        {
            GC.IniciarJogo();
        }
        else
        {
            Pressionar();
        }
    }

    void Pressionar()
    {
        if (IsPressed())
        {
            apertado = true;
        }
    }
}
