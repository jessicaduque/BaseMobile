using System.Collections;
using UnityEngine;
using Utils.Singleton;

public class Fade : Singleton<Fade>
{
    public IEnumerator FadeIn(CanvasGroup cg, float timeToFade = 2f)
    {
        cg.gameObject.SetActive(true);
        while (cg.alpha < 1)
        {
            cg.alpha += timeToFade * Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator FadeOut(CanvasGroup cg, float timeToFade = 2f)
    {
        while (cg.alpha > 1)
        {
            cg.alpha -= timeToFade * Time.deltaTime;
            yield return false;
        }
        cg.gameObject.SetActive(false);
    }
}
