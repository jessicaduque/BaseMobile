using System.Collections.Generic;
using UnityEngine;
using Utils.Singleton;

[CreateAssetMenu(fileName = "Nova fase", menuName = "Lista das fases")]
public class FaseList :  ScriptableSingleton<FaseList>
{
    [SerializeField] FaseDetails[] fases;

    public FaseDetails GetFaseTerra()
    {
        foreach(FaseDetails f in fases)
        {
            if(f.faseNome == NomePlaneta.Terra)
            {
                return f;
            }
        }
        return null;
    }

    public List<FaseDetails> GetFasesSemTerra()
    {
        List<FaseDetails> fasesSemTerra = new List<FaseDetails>();

        foreach (FaseDetails f in fases)
        {
            if (f.faseNome != NomePlaneta.Terra)
            {
                fasesSemTerra.Add(f);
            }
        }

        return fasesSemTerra;
    }
}
