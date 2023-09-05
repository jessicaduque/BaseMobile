using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personagem : Button
{
    private Vector2 posInicial = new Vector2(-8f, 0);
    private float tempoMover;
    [SerializeField] PoderDetails poderAtual;
    private float waitTimeShot = 0.0f;
    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        transform.position = posInicial;
    }

    private void Update()
    {
        Atacar();
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

    void Atacar()
    {
        waitTimeShot += Time.deltaTime;

        if (waitTimeShot > poderAtual.tiroScript.waitLimitShot)
        {
            if (Vector2.Distance(Player.transform.position, transform.position) < 6f)
            {
                foreach(Transform saida in poderAtual.tiroScript.PontosSaida)
                {
                    GameObject tiro = Instantiate(poderAtual.poderPrefab, saida.position, saida.rotation);
                    Destroy(tiro, 2f);
                }

                waitTimeShot = 0f;
            }
        }
    }

    public void Ultimate()
    {
        Debug.Log("Ultimate!!!");
    }
}
