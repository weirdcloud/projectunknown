using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    CurrencyCount currencyCount;
    [SerializeField]
    PowerUps activePowerUps;

    public UnityEvent LvlFail;
    public UnityEvent LvlWin;

    AudioManager audioManager;

    private void Awake()
    {
        PlayerHealthController player = FindObjectOfType<PlayerHealthController>();
        player.playerDeath.AddListener(OnPlayerDeath);
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnPlayerDeath()
    {
        DeleteHeldSouls();
        DeletePowerUps();
        LvlFail.Invoke();
    }

    public void OnEnterPortal()
    {
        SaveHeldSouls();
        GameObject player = FindObjectOfType<PlayerHealthController>().gameObject;
        Destroy(player);
        LvlWin.Invoke();
    }

    public void DeleteHeldSouls()
    {
        currencyCount.HeldSoulsAmount = 0;
    }

    public void SaveHeldSouls()
    {
        currencyCount.SoulsAmount += currencyCount.HeldSoulsAmount;
        currencyCount.HeldSoulsAmount = 0;
    }

    public void DeletePowerUps()
    {
        activePowerUps.DisableAll();
    }

    public void FadeOutMusic()
    {
        audioManager.StartFadeOut("GameMusic");
    }
}
