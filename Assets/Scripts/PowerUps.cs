using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PowerUps : ScriptableObject
{
    public bool doubleDamage;
    public bool quickRecharge;
    public bool tripleJump;

    public void DisableAll()
    {
        doubleDamage = false;
        quickRecharge = false;
        tripleJump = false;
    }

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}