using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        InvokeRepeating("Growl", 0.001f, 20f);
        InvokeRepeating("Metal", 0.9f, 10f);
        InvokeRepeating("Foot", 1f, 10f);
        InvokeRepeating("Metal", 2.9f, 10f);
        InvokeRepeating("Foot", 3f, 10f);
        InvokeRepeating("Impact", 0.05f, 30f);
        Play("Theme01");
        Play("Theme02");
        Play("Theme03");
        Play("Theme04");
    }
    void Impact()
    {
        Play("Impact");
    }
    void Growl()
    {
        Play("Monster");
    }
    void Foot()
    {
        Play("Feet");
    }
    void Metal()
    {
        Play("Chains");
    }

    public void Play (string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

}
