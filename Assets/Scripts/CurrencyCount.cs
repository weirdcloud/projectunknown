using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class CurrencyCount : ScriptableObject
{
    [SerializeField]
    private int soulsAmount = 0;
    [SerializeField]
    private int heldSoulsAmount = 0;

    public IntEvent changeSoulsAmount;
    public IntEvent changeHeldSoulsAmount;

    public int SoulsAmount 
    { 
        get => soulsAmount; 
        set 
        {
            soulsAmount = value;
            changeSoulsAmount.Invoke(soulsAmount);
        }
    }
    public int HeldSoulsAmount 
    { 
        get => heldSoulsAmount;
        set
        {
            heldSoulsAmount = value;
            changeHeldSoulsAmount.Invoke(heldSoulsAmount);
        }
    }

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}
