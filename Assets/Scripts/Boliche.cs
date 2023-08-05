using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boliche : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Pinos")
        {
            Destroy(this.gameObject);
        }
    }
}
