using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Utils.Singleton;

public class UIController : Singleton<UIController>
{
    [Header("Fundo Parallax")]
    [SerializeField] private GameObject[] fundos;

    [Header("Panels")]
    [SerializeField] GameObject UIPanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject ChancePanel;
    [SerializeField] GameObject StartPanel;
    [SerializeField] GameObject CreditsPanel;

    [Header("Inicio jogo")]
    [SerializeField] Button b_iniciarJogo;
    [SerializeField] Button b_creditos;
    [SerializeField] Button b_pause;

    private GameControlador GC;
    private Fade fade;

    private void Start()
    {
        fade = Fade.I;
        GC = GameControlador.I;

        UIPanel.SetActive(false);

        b_iniciarJogo.onClick.AddListener(IniciarJogo);
        b_creditos?.onClick.AddListener(AbrirCreditos);
        b_pause.onClick.AddListener(AbrirMenuPause);
    }

    private new void Awake()
    {

    }

    private void IniciarJogo()
    {
        StartCoroutine(FadeOutInicio());
    }

    #region Fade

    IEnumerator FadeOutInicio(float timeToFade = 2f)
    {
        CanvasGroup cg = StartPanel.GetComponent<CanvasGroup>();

        while (cg.alpha > 1)
        {
            cg.alpha -= timeToFade * Time.deltaTime;
            yield return false;
        }
        StartPanel.SetActive(false);

        StartCoroutine(fade.FadeIn(UIPanel.GetComponent<CanvasGroup>()));
        MudarEstadoParallax();
        GC.SetEstadoJogo(EstadoJogo.Inicial);
    }

    #endregion

    #region Panels

    private void AbrirCreditos()
    {
        CreditsPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void FecharCreditos()
    {
        CreditsPanel.SetActive(false);
        Time.timeScale = 0;
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

    public void AbrirChanceExtra()
    {
        ChancePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void FecharChanceExtra()
    {
        ChancePanel.SetActive(false);
        Time.timeScale = 0;
    }

    #endregion 

    public void MudarEstadoParallax()
    {
        for (int i = 0; i < fundos.Length; i++)
        {
            fundos[i]?.GetComponent<Parallax>().MudarEstadoParallax();
        }
    }
}
