using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova fase", menuName = "Criar fase")]
public class FaseDetails : ScriptableObject
{
    public int faseID;
    public string faseNome;
    public RuntimeAnimatorController faseAnimControl;
    public PoderDetails fasePoder;
    public GameObject[] faseInimiPossiveis;
}