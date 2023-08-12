using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boliche : MonoBehaviour
{
    public int valor = 0;
    private GameControlador GC;
    private float tempo;

    void Start()
    {
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControlador>();
    }

    void Update()
    {
        tempo += Time.deltaTime;
        if (tempo > 0.0001f)
        {
            transform.position = new Vector2(transform.position.x - 0.004f, transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Pinos")
        {
            GC.DarPontos(valor);
            Destroy(this.gameObject);
        }
    }
}
