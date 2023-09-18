using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    [Header("Fundo Parallax")]
    [SerializeField] private GameObject[] fundos;

    [Header("Panels")]
    [SerializeField] GameObject UIPanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject ChancePanel;
    [SerializeField] GameObject StartPanel;
    [SerializeField] GameObject CreditsPanel;

    private void Start()
    {
        UIPanel.SetActive(false);
    }

    void MudarEstadoParallax()
    {
        for (int i = 0; i < fundos.Length; i++)
        {
            fundos[i]?.GetComponent<Parallax>().MudarEstadoParallax();
        }
    }
}
