using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    CurrencyCount currencyCount;
    private void Awake()
    {
        PlayerHealthController player = GameObject.FindObjectOfType<PlayerHealthController>();
        player.playerDeath.AddListener(OnPlayerDeath);
        currencyCount.LevelSoulsAmount = 0;
    }

    public void OnPlayerDeath()
    {
        currencyCount.LevelSoulsAmount = 0;
    }

    public void OnEnterPortal()
    {
        currencyCount.SoulsAmount += currencyCount.LevelSoulsAmount;
        currencyCount.LevelSoulsAmount = 0;
    }
}
