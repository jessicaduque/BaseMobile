using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameControlador : MonoBehaviour
{
    [SerializeField] GameObject UIPanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject StartPanel;
    [SerializeField] GameObject CreditsPanel;

    [SerializeField] Image planeta_Image;
    [SerializeField] Sprite[] planetas_Sprites;
    [SerializeField] GameObject[][] inimigos_possiveis;

    enum EstadoJogo {Inicial, CriarFase, Lutar, EscolherPoder, Terra};
    EstadoJogo estadoAtual;

    private int estrelas = 0;

    void Start()
    {
        UIPanel.SetActive(false);
        estadoAtual = EstadoJogo.Inicial;
    }

    void Update()
    {
    }

    void ControleEstados()
    {
        switch (estadoAtual)
        {
            case EstadoJogo.Inicial:
                break;
            case EstadoJogo.CriarFase:
                AleatorizarFase();
                estadoAtual = EstadoJogo.Lutar;
                break;
            case EstadoJogo.Lutar:
                // C�digo
                break;
            case EstadoJogo.EscolherPoder:
                // C�digo
                break;
            case EstadoJogo.Terra:
                // C�digo
                break;
        }
    }

    void AleatorizarFase()
    {
        // C�digo para escolher fase e determinar dificuldades
    }

    public void GanharEstrela()
    {
        estrelas++;
    }

    public float MostrarPontos()
    {
        return estrelas;
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
        StartPanel.SetActive(false);
        UIPanel.SetActive(true);
        estadoAtual = EstadoJogo.CriarFase;
    }
    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        // Script para o que ocorre ao perder o jogo
        Time.timeScale = 0;
    }

}
