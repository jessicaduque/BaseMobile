using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banco : MonoBehaviour
{
    private float danoAMaisPorc = 1f;
    private int dinheiro = 5;

    public void Comprar(int valor)
    {
        if(dinheiro > (valor * (int)danoAMaisPorc))
        {
            dinheiro -= valor;
            danoAMaisPorc += 1.2f; 
            Debug.Log("comprou");
        }
        else
        {
            Debug.Log("sem dinheiro suficiente");
        }
    }

    private float InformarDanoAMais()
    {
        return danoAMaisPorc;
    }

    public void PegarDinheiro(int estrelas)
    {
        dinheiro = estrelas;
    }
}
