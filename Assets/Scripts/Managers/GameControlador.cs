using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Singleton;


public class GameControlador : Singleton<GameControlador>
{
    [Header("Elementos de uma fase")]
    private List<FaseDetails> fases;
    private FaseDetails faseAtual;
    [SerializeField] GameObject planeta;
    private RuntimeAnimatorController planetaAnim;


    private bool chanceExtra = true;

    [Header("Player")]
    private Movimento PlayerMov;
    private Personagem PlayerContr;

    EstadoJogo estadoAtual;
    
    [Header("Banco")]
    private Banco meuBanco;
    private int estrelas = 0;
    private int vidas = 1;
    private bool podeReviver = true;
    private bool fadeTerminado = false;

    [Header("Controle UI")]
    private UIController controleUI;

    private int numeroFase = 0;

    // Para mover o planeta
    private Vector2 limiteXPlaneta = new Vector2(15.5f, 0);
    private Vector2 paradaXPlaneta = new Vector2(7.1f, 0);
    private bool movendoPlaneta = false;
    private float moverPlanetaSpeed = 0f;

    void Start()
    {
        meuBanco = Banco.I;
        controleUI = UIController.I;

        fases = FaseList.Instance.GetFasesSemTerra();
        planetaAnim = planeta.GetComponent<RuntimeAnimatorController>();
        estadoAtual = EstadoJogo.Inicial;
        PlayerMov = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimento>();
        PlayerContr = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();
    }

    private new void Awake()
    {
        
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
                movendoPlaneta = true;
                PlayerMov.AnimatateMoveSideways();
                StartCoroutine(PlayerMov.MoverParaX());
                break;
            case EstadoJogo.CriarFase:
                numeroFase++;
                fadeTerminado = false;
                AleatorizarFase();
                GetComponent<GerenciadorDeExtras>().enabled = true;
                break;
            case EstadoJogo.Lutar:
                movendoPlaneta = false;
                PlayerMov.AnimatateAttack();
                PlayerContr.PermitirAtacar();
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

    public void SetEstadoJogo(EstadoJogo estado)
    {
        estadoAtual = estado;
        ControleEstados();
    }

    void AleatorizarFase()
    {
        faseAtual = fases[Random.Range(0, fases.Count)];
        planetaAnim = faseAtual.faseAnimControl;
        GerarInimgigos();
    }

    void GerarInimgigos()
    {
        // Nada por enquanto
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
                    SetEstadoJogo(EstadoJogo.CriarFase);
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
                    controleUI.MudarEstadoParallax();
                    SetEstadoJogo(EstadoJogo.Lutar);
                }
                if (Vector2.Distance(planeta.transform.position, paradaXPlaneta) < 2)
                {
                    planeta.GetComponent<Animator>().speed -= Time.deltaTime * 0.4f;
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
                controleUI.AbrirChanceExtra();
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
        SetEstadoJogo(EstadoJogo.Lutar);
    }


    public void GameOver()
    {
        // Script para o que ocorre ao perder o jogo
        SetEstadoJogo(EstadoJogo.Morte);
    }

   
    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void ContinuarProcesso()
    {
        fadeTerminado = true;
    }

}
