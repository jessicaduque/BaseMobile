using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Singleton;

public class Banco : Singleton<Banco>
{
    [Header("Dinheiro")]
    private int dinheiro = 0;

    [Header("Compras possíveis")]
    private float danoAMaisPorcNormal = 0f;
    private float danoAMaisPorcUlt = 0f;
    private float chanceAtaqueSeguir = 0f;

    private bool podeReviver = false;
    private bool barreiraContraMeteoros = false;
    private bool maiorChanceAsEstre = false;

    private bool Comprar(int valor)
    {
        if (dinheiro >= valor)
        {
            dinheiro -= valor;
            return true;
        }
        else
        {
            return false;
        }

    }

    #region Public Comprar

    public bool ComprarMelhorAtaqueNormal(int valor)
    {
        if (Comprar(valor)) {
            danoAMaisPorcNormal += 20;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ComprarMelhorUltimate(int valor)
    {
        if (Comprar(valor))
        {
            danoAMaisPorcUlt += 20;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ComprarChancesAtaqueSeguir(int valor)
    {
        if (Comprar(valor))
        {
            chanceAtaqueSeguir += 10;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ComprarReviver(int valor)
    {
        if (Comprar(valor))
        {
            podeReviver = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ComprarBarreiraMeteoros(int valor)
    {
        if (Comprar(valor))
        {
            barreiraContraMeteoros = true;
            return true;
        }
        else
        {
            return false;
        }
    }


    #endregion

    #region SET
    public void AtualizarDinheiro(int estrelas)
    {
        dinheiro = estrelas;
    }

    public void ResetarReviver()
    {
        podeReviver = false;
    }

    public void ResetarMeteoros()
    {
        barreiraContraMeteoros = false;
    }

    public void ResetarChancesAsEst()
    {
        maiorChanceAsEstre = false;
    }

    #endregion

    #region GET

    private float InformarDanoNormalAMais()
    {
        return danoAMaisPorcNormal;
    }

    private float InformarDanoUltAMais()
    {
        return danoAMaisPorcUlt;
    }

    private float ChanceAtaqueSeguir()
    {
        return chanceAtaqueSeguir;
    }

    #endregion
}
