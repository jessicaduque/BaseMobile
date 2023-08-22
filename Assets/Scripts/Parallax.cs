using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float comprimentoX;
    private float PosAtualX;
    private Transform cam;
    [SerializeField] private float tempoParalaxe;
    private float auxTempoParalaxe = 0f;
    [SerializeField] private bool parallaxRodando = false;

    // Start is called before the first frame update
    void Start()
    {
        PosAtualX = transform.position.x;
        comprimentoX = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (parallaxRodando)
        {
            if(auxTempoParalaxe >= tempoParalaxe)
            {
                MovimentoParalaxe(tempoParalaxe);
            }
            else
            {
                auxTempoParalaxe += Time.deltaTime;
                MovimentoParalaxe(auxTempoParalaxe);
            }
            
        }
        else
        {
            if(auxTempoParalaxe > 0)
            {
                MovimentoParalaxe(auxTempoParalaxe);
                auxTempoParalaxe -= Time.deltaTime;
            }
        }
    }

    void MovimentoParalaxe(float tp)
    {
        PosAtualX -= tp * Time.deltaTime;
        float rePos = cam.transform.position.x * (1 - tp);
        float distancia = cam.transform.position.x * tp;

        transform.position = new Vector3(PosAtualX + distancia, transform.position.y, transform.position.z);

        if (rePos > PosAtualX + comprimentoX)
        {
            PosAtualX += comprimentoX;
        }
        else if (rePos < PosAtualX - comprimentoX)
        {
            PosAtualX -= comprimentoX;
        }
    }

    public void MudarEstadoParallax()
    {
        parallaxRodando = !parallaxRodando;
    }
}
