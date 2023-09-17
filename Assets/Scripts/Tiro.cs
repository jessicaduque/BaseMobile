using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    protected Rigidbody2D Rb2D;
    [SerializeField] public float shotSpeed;
    [SerializeField] protected int dano;
    [SerializeField] protected GameObject efeitoExplosao;
    [SerializeField] public float waitLimitShot;
    [SerializeField] public Vector2[] PontosSaida;

    protected void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        Rb2D.velocity = new Vector2(shotSpeed, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().PlayerDamage(dano);
        }
        else if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemies>().ReceberDano(dano);
        }
        GameObject explosao = Instantiate(efeitoExplosao, transform.position, Quaternion.identity);
        Destroy(this.gameObject);

    }

}
