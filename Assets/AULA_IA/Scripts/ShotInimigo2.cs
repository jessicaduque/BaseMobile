using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotInimigo2 : ShotController
{
    private Transform PlayerPos;

    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        Rb2D = GetComponent<Rigidbody2D>();
        Vector2 vel = PlayerPos.position;
        vel.Normalize();
        Rb2D.velocity = vel * 3f;
    }
}
