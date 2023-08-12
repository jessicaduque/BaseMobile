using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlador : MonoBehaviour
{
    private int pontos;

    void Start()
    {
        
    }

    void Update()
    {
    }

    public void DarPontos(int valorX)
    {
        pontos += valorX;
    }

    public float MostrarPontos()
    {
        return pontos;
    }

}
