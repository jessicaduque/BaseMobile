using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo poder", menuName = "Criar poder")]
public class PoderDetails : ScriptableObject
{
    public int poderID;
    public string poderNome;
    public PoderDetails poderFraqueza;
    public GameObject poderPrefab;
    public RuntimeAnimatorController protAnimControl;
    public Tiro tiroScript;
}