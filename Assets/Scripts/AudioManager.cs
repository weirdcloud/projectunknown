using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioMixerGroup mixerGroup;
    public Sound[] sounds;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = mixerGroup;
        }
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.Play();
    }
    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
    public void StopAll()
    {
        AudioSource[] sources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource s in sources)
        {
            s.Stop();
        }
    }
    public IEnumerator FadeOut(string sound, float timeToFade)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        AudioSource source = Array.Find(FindObjectsOfType<AudioSource>(), source => s.source.clip.name == source.clip.name);
        if (source != null)
        {
            float timeElapsed = 0f;
            float initialVolume = source.volume;
            while (timeElapsed < timeToFade)
            {
                source.volume = Mathf.Lerp(initialVolume, 0, timeElapsed / timeToFade);
                timeElapsed += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            source.Stop();
        }
        yield return null;
    }
    public IEnumerator FadeIn(string sound, float timeToFade)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        AudioSource source = Array.Find(FindObjectsOfType<AudioSource>(), source => s.source.clip.name == source.clip.name);
        
        if (source != null)
        {
            float timeElapsed = 0f;
            float maxVolume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
            source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
            source.Play();
            while (timeElapsed < timeToFade)
            {
                source.volume = Mathf.Lerp(0, maxVolume, timeElapsed / timeToFade);
                timeElapsed += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
        }
        yield return null;
    }

    public IEnumerator Pause(float time)
    {
        yield return new WaitForSeconds(time);
    }

    public void StartFadeOut(string sound)
    {
        StartCoroutine(FadeOut(sound, 2f));
    }
    public void StartFadeIn(string sound)
    {
        StartCoroutine(Pause(2f));
        StartCoroutine(FadeIn(sound, 15f));
    }
}