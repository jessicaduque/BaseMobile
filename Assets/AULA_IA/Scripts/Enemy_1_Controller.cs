using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Controller : Enemies
{
    private Rigidbody2D rb2d;

    [Header("Limites")]
    [SerializeField] private float limiteEsquerdaX;
    [SerializeField] private float limiteDireitaX;

    private float waitTimeMove = 0f;
    private float waitLimitMove = 0f;


    void Start()
    {
        base.Start();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed, 0f);
    }


    private void Update()
    {
        base.Update();
        TrocarLado();
    }

    public override void Atirar(Transform PontoSaida)
   {
        base.Atirar(PontoSaida);
        if (waitTimeShot == 0)
        {
            waitLimitShot = Random.Range(0.2f, 0.8f);
        }
   }
    
    void TrocarLado()
    {
        waitTimeMove += Time.deltaTime;

        if (waitTimeMove > waitLimitMove)
        {
            rb2d.velocity = new Vector2(-rb2d.velocity.x, 0f);
            if (transform.position.x <= limiteEsquerdaX || transform.position.x >= limiteDireitaX)
            {
                waitLimitMove = Random.Range(1.6f, 2.2f);
            }
            else
            {
                waitLimitMove = Random.Range(0.8f, 1.6f);
            }
            waitTimeMove = 0f;
        }
    }
}
