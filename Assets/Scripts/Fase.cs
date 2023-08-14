using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase
{
    public Sprite Planeta_Sprite;
    public GameObject[] Inimigos_Possiveis;
    public GameObject[] Inimigos_Criados;
    public int max_inimigos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool ChecarSeMaximoInimigos()
    {
        if(Inimigos_Criados.Length == max_inimigos)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
