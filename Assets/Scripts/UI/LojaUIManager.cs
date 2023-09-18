using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LojaUIManager : MonoBehaviour
{
    private Banco _bankManager;

    [SerializeField] private TextMeshProUGUI t_quantEstrelas;

    [Header("Nomes de compras possíveis")]
    [SerializeField] private TextMeshProUGUI t_nomeAtaqueNormal;
    [SerializeField] private TextMeshProUGUI t_nomeUltimate;
    [SerializeField] private TextMeshProUGUI t_chancesAtaqueSeguir;
    [SerializeField] private TextMeshProUGUI t_reviver;
    [SerializeField] private TextMeshProUGUI t_barreiraMeteoros;
    [SerializeField] private TextMeshProUGUI t_maisAsEst;

    private void Start()
    {
        _bankManager = Banco.I;
    }

    private void OnEnable()
    {
        SetTextNames();
    }

    private void SetTextNames()
    {
        //t_nomeAtaqueNormal.text = "Aumento de " + _bankManager.Ataq
    }
}
