using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlador : MonoBehaviour
{
    public GameObject PausePanel;

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

    public void AbrirMenuPause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void FecharMenuPause()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

}
