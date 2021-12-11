using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void PlayDoubleJump()
    {
        audioManager.Play("DoubleJump");
    }
    public void PlayJump()
    {
        audioManager.Play("Jump");
    }
    public void PlayTakeDamage()
    {
        audioManager.Play("PlayerDamage");
    }
}
