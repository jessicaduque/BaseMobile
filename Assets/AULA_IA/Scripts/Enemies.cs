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

    protected void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    public void ReceberDano(int dano)
    {
        enemyHealth -= dano;
        if(enemyHealth <= 0)
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        Instantiate(efeitoExplosao, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public virtual void Atirar(Transform PontoSaida)
    {
        waitTimeShot += Time.deltaTime;

        if (waitTimeShot > waitLimitShot)
        {
            if (Vector2.Distance(Player.transform.position, transform.position) < 6f)
            {
                GameObject tiro = Instantiate(ShotPrefab, PontoSaida.position, PontoSaida.rotation);
                Destroy(tiro, 2f);

                waitTimeShot = 0f;
            }
        }

    }
}
