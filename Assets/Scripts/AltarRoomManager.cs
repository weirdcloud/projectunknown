using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarRoomManager : MonoBehaviour
{
    AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        StartCoroutine(audioManager.FadeIn("AltarMusic", 15f));
    }

    public void FadeOutMusic()
    {
        audioManager.StartFadeOut("AltarMusic");
    }

    public void FadeInMusic()
    {
        audioManager.StartFadeIn("GameMusic");
    }
}
