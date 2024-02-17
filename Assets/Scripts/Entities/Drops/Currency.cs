using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Currency",menuName = "Currencies/Currency", order = 2)]
public class Currency : ScriptableObject
{
    [Range(0f, 1f)] public float SpawnChance;
}