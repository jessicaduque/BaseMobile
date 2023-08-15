using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxVel;
    private float comprimentoX;
    private float PosAtualX;
    private Transform cam;
    [SerializeField] private float tempoParalaxe;

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
        MovimentoParalaxe();
    }

    void MovimentoParalaxe()
    {
        PosAtualX -= tempoParalaxe * Time.deltaTime;
        float rePos = cam.transform.position.x * (1 - parallaxVel);
        float distancia = cam.transform.position.x * parallaxVel;

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
}
