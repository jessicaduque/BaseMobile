using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fase
{
    private RuntimeAnimatorController animator;
    private GameObject[] inimigos_Possiveis;
    private int max_inimigos;

    public Fase(FaseDetails fase, int max)
    {
        animator = fase.faseAnimControl;
        inimigos_Possiveis = fase.faseInimiPossiveis;
        max_inimigos = max;
    }

    // Se fase for gerada sem receber número máximo de inimigos, significa que está sendo gerado o tutorial
    public Fase(FaseDetails fase)
    {
        animator = fase.faseAnimControl;
        inimigos_Possiveis = fase.faseInimiPossiveis;
        max_inimigos = 5;
    }
    public bool ChecarSeMaximoInimigos(GameObject[] Inimigos_Criados)
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
