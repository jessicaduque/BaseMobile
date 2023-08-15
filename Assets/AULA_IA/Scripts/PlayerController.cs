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
    private float tempoDelay;
    private float shotTime = 0.2f;

    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movimento();
        shotTime -= Time.deltaTime;
        if (Input.GetAxis("Fire1") != 0 && shotTime <= 0)
        {
            Atirar();
            shotTime = 0.2f;
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

    void Atirar()
    {
        GameObject tiro = Instantiate(PlayerShotPrefab, FirePointMiddle.position, Quaternion.identity);
        Destroy(tiro, 2f);
    }

}
