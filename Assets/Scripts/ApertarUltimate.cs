using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApertarUltimate : Button
{
    private GameObject Personagem;

    void Start()
    {
        Personagem = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Pressionar();
    }

    void Pressionar()
    {
        if (IsPressed())
        {
            Personagem.GetComponent<Movimento>().Ultimate();
        }
    }
}
