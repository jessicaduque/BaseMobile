using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2_Controller : Enemies
{
    private Rigidbody2D rb2d;

    void Start()
    {
        base.Start();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0f, -speed);
    }

    void Update()
    {
        base.Atirar(this.FirePointMiddle);
    }

}
