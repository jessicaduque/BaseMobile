using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimento : Button
{
    private Vector2 posInicial = new Vector2(-8f, 0);
    private float tempoMover;
    private GameObject Player;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        transform.position = posInicial;
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
        transform.position = Vector3.MoveTowards(transform.position, dFinal, 5f * Time.deltaTime);
        
    }
    
}
