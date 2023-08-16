using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fase
{
    private Sprite planeta_Sprite;
    private GameObject[] inimigos_Possiveis;
    private int max_inimigos;

    public Fase(Sprite planeta_Sprite, GameObject[] inimigos_Possiveis, int max_inimigos)
    {
        this.planeta_Sprite = planeta_Sprite;
        this.inimigos_Possiveis = inimigos_Possiveis;
        this.max_inimigos = max_inimigos;
    }

    // Se fase for gerada sem receber número máximo de inimigos, significa que está sendo gerado o tutorial
    public Fase(Sprite planeta_Sprite, GameObject[] inimigos_Possiveis)
    {
        this.planeta_Sprite = planeta_Sprite;
        this.inimigos_Possiveis = inimigos_Possiveis;
        this.max_inimigos = 6;
    }

    // Se fase for gerada sem receber número máximo de inimigos nem inimigos possíveis, significa que é a fase da terra
    public Fase(Sprite planeta_Sprite)
    {
        this.planeta_Sprite = planeta_Sprite;
        this.max_inimigos = 0;
    }

    public bool MoverPlaneta(Image planeta_Image, Vector3 pontoFinal)
    {
        if(planeta_Image.sprite != planeta_Sprite)
        {
            planeta_Image.sprite = this.planeta_Sprite;
        }
        if (planeta_Image.transform.position != pontoFinal)
        {
            Vector3.MoveTowards(planeta_Image.transform.position, pontoFinal, 5f * Time.deltaTime);
            return false;
        }
        else
        {
            return true;
        }
        
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
