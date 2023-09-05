using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Rb2D;
    [SerializeField] private float velocidade = 30f;

    [Header("Shot Variables")]
    [SerializeField] private GameObject PlayerShotPrefab;
    [SerializeField] private Transform FirePointMiddle;
    [SerializeField] private Transform FirePointRight;
    [SerializeField] private Transform FirePointLeft;
    [SerializeField] private bool isPowerUp;

    [SerializeField] private int health;

    private float tempoDelay;
    private float shotTime = 0f;

    void Start()
    {
        isPowerUp = false;
        Rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movimento();
        shotTime += Time.deltaTime;
        if (Input.GetAxis("Fire1") != 0 && shotTime >= 0.2f)
        {
            if (isPowerUp)
            {
                Atirar(FirePointMiddle);
                Atirar(FirePointRight);
                Atirar(FirePointLeft);
            }
            else
            {
                Atirar(FirePointMiddle);
            }
            shotTime = 0f;
        }
    }

    void Movimento()
    {
        // Pegando os inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 shipVel = new Vector2(horizontal, vertical);

        shipVel.Normalize();

        Rb2D.velocity = shipVel * velocidade;
    }

    void Atirar(Transform PontoSaida)
    {
        GameObject tiro = Instantiate(PlayerShotPrefab, PontoSaida.position, PontoSaida.rotation);
        Destroy(tiro, 2f);
    }

    public void PlayerDamage(int damage)
    {
        health -= damage;
    }

}
