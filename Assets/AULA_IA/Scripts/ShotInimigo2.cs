using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotInimigo2 : ShotController
{
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Rb2D = GetComponent<Rigidbody2D>();
        if (Player != null)
        {
            Vector2 vel = (Player.transform.position - transform.position).normalized;
            
            float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            Rb2D.velocity = vel * shotSpeed;
        }
        else
        {
            Rb2D.velocity = new Vector2(0, -1);
        }
    }
}
