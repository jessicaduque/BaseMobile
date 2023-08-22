using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameControlador : MonoBehaviour
{
    [Header("Fundo Parallax")]
    [SerializeField] private GameObject[] fundos;

    [Header("Panels")]
    [SerializeField] GameObject UIPanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject ChancePanel;
    [SerializeField] GameObject StartPanel;
    [SerializeField] GameObject CreditsPanel;

    [Header("Elementos de uma fase")]
    [SerializeField] GameObject planeta;
    [SerializeField] RuntimeAnimatorController[] planetas_Animadores;
    [SerializeField] GameObject[][] inimigos_possiveis;

    enum EstadoJogo { Inicial, CriarFase, Lutar, EscolherPoder, Terra, Morte };
    EstadoJogo estadoAtual;
    
    private int estrelas = 0;
    private int vidas = 1;
    private bool chanceExtra = true;
    private bool fadeTerminado = false;

    // Para mover o planeta
    private Vector2 limiteXPlaneta = new Vector2(15.5f, 0);
    private Vector2 paradaXPlaneta = new Vector2(7.1f, 0);
    private bool movendoPlaneta = false;
    private float moverPlanetaSpeed = 0f;

    void Start()
    {
        UIPanel.SetActive(false);
        estadoAtual = EstadoJogo.Inicial;
    }

    void Update()
    {
        MovendoPlaneta();
    }

    void ControleEstados()
    {
        switch (estadoAtual)
        {
            case EstadoJogo.Inicial:
                break;
            case EstadoJogo.CriarFase:
                fadeTerminado = false;
                //AleatorizarFase();
                GetComponent<GerenciadorDeExtras>().enabled = true;
                break;
            case EstadoJogo.Lutar:
                movendoPlaneta = false;
                Debug.Log("aqui");
                // Código
                break;
            case EstadoJogo.EscolherPoder:
                GetComponent<GerenciadorDeExtras>().enabled = false;
                // Código
                break;
            case EstadoJogo.Terra:
                // Código
                break;
            case EstadoJogo.Morte:
                GetComponent<GerenciadorDeExtras>().enabled = false;
                // Código
                break;
        }
    }

    void MudancaEstado()
    {
        ControleEstados();
    }

    void AleatorizarFase()
    {
        // Não inclui o 0 por este ser a Terra
        int fase = Random.Range(1, 4);
        planeta.GetComponent<Animator>().runtimeAnimatorController = planetas_Animadores[fase];
    }

    void MovendoPlaneta()
    {
        if (estadoAtual == EstadoJogo.Inicial)
        {
            
            if (movendoPlaneta)
            {
                if (planeta.transform.position.x <= -limiteXPlaneta.x)
                {
                    planeta.transform.position = limiteXPlaneta;
                    estadoAtual = EstadoJogo.CriarFase;
                    MudancaEstado();
                }
                if (moverPlanetaSpeed >= 2f)
                {
                    planeta.transform.position = Vector2.MoveTowards(planeta.transform.position, -limiteXPlaneta, 2 * Time.deltaTime);
                }
                else
                {
                    planeta.transform.position = Vector2.MoveTowards(planeta.transform.position, -limiteXPlaneta, moverPlanetaSpeed * Time.deltaTime);
                    moverPlanetaSpeed += Time.deltaTime;
                }
            }
        }
        else
        {
            if (movendoPlaneta)
            {
                if (planeta.transform.position.x <= paradaXPlaneta.x)
                {
                    moverPlanetaSpeed = 0;
                    estadoAtual = EstadoJogo.Lutar;
                    MudancaEstado();
                }
                if (Vector2.Distance(planeta.transform.position, paradaXPlaneta) < 2)
                {
                    moverPlanetaSpeed -= Time.deltaTime;
                    if(moverPlanetaSpeed <= 0)
                    {
                        moverPlanetaSpeed = 0.0001f;
                    }
                    planeta.transform.position = Vector2.MoveTowards(planeta.transform.position, paradaXPlaneta, moverPlanetaSpeed * Time.deltaTime);
                }
                else
                {
                    planeta.transform.position = Vector2.MoveTowards(planeta.transform.position, paradaXPlaneta, 2 * Time.deltaTime);
                }
            }
        }

        
    }

    public void GanharEstrela()
    {
        estrelas++;
    }

    public float MostrarEstrelas()
    {
        return estrelas;
    }

    public void Morrer()
    {
        vidas--;
        Time.timeScale = 0;
        if (vidas < 1)
        {
            if (chanceExtra)
            {
                ChancePanel.SetActive(true);
                chanceExtra = false;
                // Código para rodar vídeo da chance extra
            }
            else
            {
                GameOver();
            }
        }
    }
    public void MaisUmaChance()
    {
        vidas = 1;
        Time.timeScale = 1;
        estadoAtual = EstadoJogo.Lutar;
        MudancaEstado();
    }


    public void GameOver()
    {
        // Script para o que ocorre ao perder o jogo
        estadoAtual = EstadoJogo.Morte;
        MudancaEstado();
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
        StartPanel.GetComponent<Fade>().FazerFadeOut();
        if (fadeTerminado)
        {
            UIPanel.SetActive(true);
            UIPanel.GetComponent<Fade>().FazerFadeIn();
            movendoPlaneta = true;
            for (int i = 0; i < fundos.Length; i++)
            {
                fundos[i].GetComponent<Parallax>().MudarEstadoParallax();
            }
            StartPanel.SetActive(false);
        }
    }
    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(0);
    }
    
    public void ContinuarProcesso()
    {
        fadeTerminado = true;
    }

}
