using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameControlador : MonoBehaviour
{
    public GameObject UIPanel;
    public GameObject PausePanel;
    public GameObject StartPanel;
    public GameObject CreditsPanel;

    private int pontos;
    void Start()
    {
        UIPanel.SetActive(false);
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

    public void IniciarJogo()
    {
        // Script para iniciar jogo
        UIPanel.SetActive(true);
        StartPanel.SetActive(false);
    }
    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(0);
    }

}
