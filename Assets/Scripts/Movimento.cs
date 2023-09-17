using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimento : Button
{
    private Vector2 posInicial = new Vector2(3.7f, 0);
    private float tempoMover;
    private GameObject Player;
    private Animator anim;
    private bool podeMover = false;

    void Start()
    {
        transform.position = posInicial;
        anim = GetComponent<Animator>();
        anim.SetBool("Idle", true);
    }

    public void Mover()
    {
        if (podeMover)
        {
            // Captura a Posição do Mouse
            Vector3 destino = Input.mousePosition;

            // Corrigir posição
            Vector3 desCorri = Camera.main.ScreenToWorldPoint(destino);

            // Destino final corrigido
            Vector3 dFinal = new Vector3(-8, Mathf.Clamp(desCorri.y, -3.8f, 3.8f), 0);

            // Mover objeto
            transform.position = Vector3.MoveTowards(transform.position, dFinal, 5f * Time.deltaTime);
        }

    }

    public void AnimatateMoveSideways()
    {
        anim.SetBool("Idle", false);
    }

    public void AnimatateIdle()
    {
        anim.SetBool("Idle", true);
    }

    public void AnimatateAttack()
    {
        anim.SetBool("Attack", true);
    }
    public void AnimatateStopAttack()
    {
        anim.SetBool("Attack", false);
    }

    public void PermitirMovimento()
    {
        podeMover = true;
    }

    public IEnumerator MoverParaX()
    {
        yield return new WaitForSeconds(2);
        Vector3 posFinal = new Vector3(-8, 0, 0);
        while (transform.position != posFinal)
        {
            transform.position = Vector3.MoveTowards(transform.position, posFinal, 1.2f * Time.deltaTime);
            yield return null;
        }
        podeMover = true;
    }

}
