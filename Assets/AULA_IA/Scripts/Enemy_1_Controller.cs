using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float speed = 3f;

    [Header("Shot Variables")]
    [SerializeField] private GameObject Enemy1ShotPrefab;
    [SerializeField] private Transform FirePointMiddle;

    [SerializeField] private float limiteEsquerdaX;
    [SerializeField] private float limiteDireitaX;

    private float waitTimeShot = 0f;
    private float waitLimitShot = 0.1f;
    private float waitTimeMove = 0f;
    private float waitLimitMove = 0f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed, 0f);
    }

    void Update()
    {
        Atirar(FirePointMiddle);
        TrocarLado();
    }
    
    void Atirar(Transform PontoSaida)
    {
        waitTimeShot += Time.deltaTime;

        if(waitTimeShot > waitLimitShot)
        {
            GameObject tiro = Instantiate(Enemy1ShotPrefab, PontoSaida.position, PontoSaida.rotation);
            Destroy(tiro, 2f);
            waitLimitShot = Random.Range(0.2f, 0.8f);
            waitTimeShot = 0f;
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
