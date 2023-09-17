using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected int enemyHealth;
    [SerializeField] protected GameObject efeitoExplosao;
    [SerializeField] protected float waitLimitShot;
    [SerializeField] protected GameObject ShotPrefab;
    protected float waitTimeShot = 0f;
    [SerializeField] protected GameObject Player;

    [Header("Shot Variables")]
    [SerializeField] protected Transform FirePointMiddle;

    bool visible;

    protected void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    protected void Update()
    {
        visible = GetComponentInChildren<SpriteRenderer>().isVisible;
        Atirar(FirePointMiddle);
    }

    public void ReceberDano(int dano)
    {
        if (visible)
        {
            enemyHealth -= dano;
            if (enemyHealth <= 0)
            {
                Morrer();
            }
        }
    }

    public void Morrer()
    {
        Instantiate(efeitoExplosao, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public virtual void Atirar(Transform PontoSaida)
    {
        

        if (visible)
        {
            waitTimeShot += Time.deltaTime;

            if (waitTimeShot > waitLimitShot)
            {
                GameObject tiro = Instantiate(ShotPrefab, PontoSaida.position, PontoSaida.rotation);

                waitTimeShot = 0f;
                
            }
        }
    }
}
