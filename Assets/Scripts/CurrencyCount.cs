using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CurrencyCount : ScriptableObject
{
    private int soulsAmount = 0;
    private int levelSoulsAmount = 0;

    public int SoulsAmount { get => soulsAmount; set => soulsAmount = value; }
    public int LevelSoulsAmount { get => levelSoulsAmount; set => levelSoulsAmount = value; }
}
