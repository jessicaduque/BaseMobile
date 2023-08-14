using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeObjetos : MonoBehaviour
{
    public List<GameObject> MinhasEsferas;
    public float meuTempo;
    public float tempoCriacao = 20f;

    void Update()
    {
        CriarExtra();
    }

    void CriarExtra()
    {
        meuTempo += Time.deltaTime;

        // Cria uma esfera a cada tempo determinado
        if (meuTempo > tempoCriacao)
        {
            float posY = Random.Range(-4.2f, 4.3f);
            Vector2 novaPos = new Vector2(8, posY);
            int esferaEscolhida = 0;
            int tipoEsfera = Random.Range(0, 101);
            if(tipoEsfera < 60)
            {
                esferaEscolhida = 0;
            }
            else
            {
                esferaEscolhida = 1;
            }
            GameObject Extra = Instantiate(MinhasEsferas[esferaEscolhida], novaPos, Quaternion.identity);
            Destroy(Extra, 10f);
            meuTempo = 0;
        }
    }
}
