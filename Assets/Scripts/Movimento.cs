using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimento : Button
{
    private Vector2 posInicial = new Vector2(-8f, 0);
    private float tempo;

    void Start()
    {
        transform.position = posInicial;
    }

    void Update()
    {
        /*
        tempo += Time.deltaTime;
        if(tempo > 0.001f && IsPressed())
        {
            Mover();
        }*/
    }

    public void Mover()
    {
        // Captura a Posição do Mouse
        Vector3 destino = Input.mousePosition;

        // Corrigir posição
        Vector3 desCorri = Camera.main.ScreenToWorldPoint(destino);

        // Destino final corrigido
        Vector3 dFinal = new Vector3(-8, Mathf.Clamp(desCorri.y, -3.8f, 3.8f), 0);

        // Mover objeto
        transform.position = Vector3.MoveTowards(transform.position, dFinal, 0.01f);

        
    }

    public void MoverD()
    {
        Debug.Log("NYANNN");
    }
}
