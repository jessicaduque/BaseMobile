using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeExtras : MonoBehaviour
{
    [SerializeField] List<GameObject> Extras;
    public float meuTempo;
    public float tempoCriacao = 20f;
    private GameControlador GC;

    private void Start()
    {
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControlador>();
    }

    private void OnEnable()
    {
        meuTempo = 0.0f;
    }

    void Update()
    {
        CriarExtra();
    }

    void CriarExtra()
    {
        meuTempo += Time.deltaTime;

        // Cria um objeto extra a cada quantidade de tempo determinado
        if (meuTempo > tempoCriacao)
        {
            float posY = Random.Range(-4.2f, 4.3f);
            Vector2 novaPos = new Vector2(transform.position.x, posY);
            int extraEscolhido = 0;
            int tipoExtra = Random.Range(0, 101);
            if(tipoExtra < 60)
            {
                extraEscolhido = 0;
            }
            else
            {
                extraEscolhido = 1;
            }
            GameObject Extra = Instantiate(Extras[extraEscolhido], novaPos, Quaternion.identity);
            Destroy(Extra, 10f);
            meuTempo = 0;
        }
    }
}
