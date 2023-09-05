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

    void Start()
    {
        animController = GetComponent<RuntimeAnimatorController>();
        SetarPoder();
    }

    private void Update()
    {
        Atacar();
    }

    void Atacar()
    {
        waitTimeShot += Time.deltaTime;

        if (waitTimeShot > waitLimitShot)
        {
            foreach (Vector2 saida in PontosSaida)
            {
                GameObject tiro = Instantiate(poderPrefab, new Vector2(transform.position.x, transform.position.y) + saida, Quaternion.identity);
                Destroy(tiro, 2f);
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

    public void Ultimate()
    {
        Debug.Log("Ultimate!!!");
    }

}
