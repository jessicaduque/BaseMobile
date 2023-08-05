using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeObjetos : MonoBehaviour
{
    public List<GameObject> MinhasEsferas;
    public float meuTempo;
    public float tempoCriacaoEsfera = 1f;

    void Update()
    {
        //CriarBola();
        CriarBolaDificil();
    }

    void CriarBola()
    {
        meuTempo += Time.deltaTime;

        // Cria uma esfera a cada tempo determinado
        if (meuTempo > tempoCriacaoEsfera)
        {
            float posX = Random.Range(-2, 2.1f);
            Vector2 novaPos = new Vector3(posX, 3.4f);
            int tipoEsfera = Random.Range(0, MinhasEsferas.Count);
            GameObject Bol = Instantiate(MinhasEsferas[tipoEsfera], novaPos, Quaternion.identity);
            Destroy(Bol, 2f);
            meuTempo = 0;
        }
    }

    void CriarBolaDificil()
    {
        meuTempo += Time.deltaTime;

        // Cria uma esfera a cada tempo determinado
        if (meuTempo > tempoCriacaoEsfera)
        {
            float posX = Random.Range(-2, 2.1f);
            Vector2 novaPos = new Vector3(posX, 3.4f);
            int esferaEscolhida = 0;
            int tipoEsfera = Random.Range(0, 101);
            if(tipoEsfera < 80)
            {
                esferaEscolhida = 0;
            }
            else if(tipoEsfera < 90)
            {
                esferaEscolhida = 1;
            }
            else if (tipoEsfera < 98)
            {
                esferaEscolhida = 2;
            }
            else
            {
                esferaEscolhida = 3;
            }
            GameObject Bol = Instantiate(MinhasEsferas[esferaEscolhida], novaPos, Quaternion.identity);
            Destroy(Bol, 2f);
            meuTempo = 0;
        }
    }
}
