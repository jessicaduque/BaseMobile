using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lengthImage, lengthCam, startpos;
    public Camera cam;
    public float parallaxEffect;

    
    void Start()
    {
        startpos = transform.position.x;
        lengthCam = cam.orthographicSize * cam.aspect;
        lengthImage = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z), parallaxEffect * 10 * Time.deltaTime);
    }

    void FixedUpdate()
    {
        //Debug.Log(Mathf.Abs(startpos - lengthImage / 2) + lengthCam);
        if(transform.position.x <= -startpos)
        {
            transform.position = new Vector3(startpos, transform.position.y, transform.position.z);
        }
    }
}
