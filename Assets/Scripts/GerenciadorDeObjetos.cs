using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeObjetos : MonoBehaviour
{
    public List<GameObject> MinhasEsferas;
    public float meuTempo;
    public float tempoCriacaoEsfera = 3f;

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
            float posY = Random.Range(-4.2f, 4.3f);
            Vector2 novaPos = new Vector3(8f, posY);
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
            float posY = Random.Range(-4.2f, 4.3f);
            Vector2 novaPos = new Vector2(8, posY);
            int esferaEscolhida = 0;
            int tipoEsfera = Random.Range(0, 101);
            if(tipoEsfera < 80)
            {
                esferaEscolhida = 0;
            }
            else
            {
                esferaEscolhida = 1;
            }
            GameObject Bol = Instantiate(MinhasEsferas[esferaEscolhida], novaPos, Quaternion.identity);
            Destroy(Bol, 10f);
            meuTempo = 0;
        }
    }
}
