using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    private float waitTimeShot = 0.0f;
    private RuntimeAnimatorController animController;

    [Header("Específicos poder")]
    [SerializeField] PoderDetails poderAtual;
    private GameObject poderPrefab;
    private float waitLimitShot;
    private Vector2[] PontosSaida;
    
    [Header("Ultimate")]
    private float ultimatePoints = 0;
    private float ultimateMaxPoints = 50;
    private bool ultimateLiberado = false;

    private bool podeAtacar;

    void Start()
    {
        animController = GetComponent<RuntimeAnimatorController>();
        SetarPoder();
        podeAtacar = false;
    }

    private void Update()
    {
        if (podeAtacar)
        {
            Atacar();
        }
    }

    void Atacar()
    {
        waitTimeShot += Time.deltaTime;

        if (waitTimeShot > waitLimitShot)
        {
            foreach (Vector2 saida in PontosSaida)
            {
                GameObject tiro = Instantiate(poderPrefab, new Vector2(transform.position.x, transform.position.y) + saida, Quaternion.identity);
            }

            waitTimeShot = 0f;
        }
    }

    void SetarPoder()
    {
        poderPrefab = poderAtual.poderPrefab;
        waitLimitShot = poderPrefab.GetComponent<Tiro>().waitLimitShot;
        PontosSaida = poderPrefab.GetComponent<Tiro>().PontosSaida;
        animController = poderAtual.protAnimControl;
    }

    public void AumentarUltimate(float pontos)
    {
        ultimatePoints += pontos;

        // Atualizar UI ultimate

        if (ultimatePoints > ultimateMaxPoints)
        {
            ultimatePoints = ultimateMaxPoints;
            ultimateLiberado = true;
        }
    }

    public void PermitirAtacar()
    {
        podeAtacar = true;
    }

    public void Ultimate()
    {
        if (ultimateLiberado)
        {
            Debug.Log("Ultimate!!!");
            ultimatePoints = 0;
            // Atualizar UI ultimate
            ultimateLiberado = false;
        }
    }

}
