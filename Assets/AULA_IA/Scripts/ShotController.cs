using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    private Rigidbody2D Rb2D;
    [SerializeField]
    private float shotSpeed;

    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        Rb2D.velocity = new Vector2(0, shotSpeed);
    }

    void Update()
    {
        
    }
}
