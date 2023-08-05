using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeObjetos : MonoBehaviour
{
    public GameObject Bola;

    void Update()
    {
        GameObject Bol = Instantiate(Bola, transform.position, Quaternion.identity);
        Destroy(Bol, 2f);
    }

}
