using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSoundController : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void PlayPortal()
    {
        audioManager.Play("Portal");
    }
}
