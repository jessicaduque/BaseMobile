using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] float timeToFade = 2f;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private CanvasGroup cg;
    private GameControlador GC;

    private void Start()
    {
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControlador>();
        cg = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (fadeOut)
        {
            FadeOut();
        }
        else if (fadeIn)
        {
            FadeIn();
        }

    }
    void FadeIn()
    {
        if (cg.alpha < 1)
        {
            cg.alpha += timeToFade * Time.deltaTime;
        }
        else
        {
            FadeTerminado();
            fadeIn = false;
        }
    }

    void FadeOut()
    {
        if (cg.alpha > 0)
        {
            cg.alpha -= timeToFade * Time.deltaTime;
        }
        else
        {
            FadeTerminado();
        }
    }

    public void FazerFadeOut()
    {
        fadeIn = false;
        fadeOut = true;
    }
    public void FazerFadeIn()
    {
        fadeIn = true;
        fadeOut = false;
    }

    void FadeTerminado()
    {
        GC.ContinuarProcesso();
    }
}
