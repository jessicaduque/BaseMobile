using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ValorPonto : MonoBehaviour
{
    private GameControlador GC;
    private TMP_Text texto;

    void Start()
    {
        texto = GetComponent<TMP_Text>();
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControlador>();
    }

    void Update()
    {
        texto.text = "PONTOS: " + GC.MostrarPontos().ToString(); 
    }
}
