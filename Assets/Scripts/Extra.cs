using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extra : MonoBehaviour
{
    [SerializeField] int valor;
    private GameControlador GC;
    private float tempo;

    void Start()
    {
        GC = GameControlador.I;
    }

    void Update()
    {
        tempo += Time.deltaTime;
        transform.position = new Vector2(transform.position.x - 4f * Time.deltaTime, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Personagem_Principal")
        {
            Destroy(this.gameObject);
            if (valor == 1)
            {
                GC.GanharEstrela();
            }
            else
            {
                GC.Morrer();
            }
        }
    }
}
