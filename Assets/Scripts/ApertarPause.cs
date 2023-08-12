using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApertarPause : Button
{
    private GameControlador GC;

    void Start()
    {
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControlador>();
    }

    void Update()
    {
        Pressionar();
    }

    void Pressionar()
    {
        if (IsPressed())
        {
            GC.AbrirMenuPause();
        }
    }
}
