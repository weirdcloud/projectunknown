using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEyeSoundController : MonoBehaviour
{
    AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void PlayDamage()
    {
        audioManager.Play("EnemyDamage");
    }
}
