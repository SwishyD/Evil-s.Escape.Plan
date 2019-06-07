using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    public static AudioManager instance;

    private bool isLoading = false;
    private bool pauseMenu = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

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
        Play("Game Over");
        Monster(0);
        Background(false, false);
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
    void Theme()
    {
        Play("Theme01");
        Play("Theme02");
        Play("Theme03");
        Play("Theme04");
    }

    public void Play(string name)
    {
        if (isLoading)
        {
            foreach (Sounds ts in sounds)
            {
                ts.source.volume = ts.volume - .02f;
            }

            isLoading = false;
        }
        if (pauseMenu)
        {
            foreach (Sounds ts in sounds)
            {
                ts.source.volume = ts.volume + .02f;
            }

            pauseMenu = false;
        }

        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    public void Monster(int loading)
    {
        if (loading == 1)
        {
            InvokeRepeating("Growl", 0.701f, 20f);
            InvokeRepeating("Metal", 1.6f, 10f);
            InvokeRepeating("Foot", 1.7f, 10f);
            InvokeRepeating("Metal", 3.6f, 10f);
            InvokeRepeating("Foot", 3.7f, 10f);
            
            loading = 0;
        }
        else
        {
            InvokeRepeating("Growl", 0.001f, 20f);
            InvokeRepeating("Metal", 0.9f, 10f);
            InvokeRepeating("Foot", 1f, 10f);
            InvokeRepeating("Metal", 2.9f, 10f);
            InvokeRepeating("Foot", 3f, 10f);
        }
    }
    public void CancelMonster()
    {
        CancelInvoke("Growl");
        CancelInvoke("Metal");
        CancelInvoke("Foot");
        CancelInvoke("Metal");
        CancelInvoke("Foot");

        Stop("Monster");
        Stop("Chains");
        Stop("Feet");
    }

    public void Background(bool firstStage, bool lastStage)
    {
        isLoading = firstStage;
        pauseMenu = lastStage;
        InvokeRepeating("Impact", 0.05f, 30f);
        Invoke("Theme", 0.001f);
    }
    public void CancelBackground()
    {
        CancelInvoke("Impact");

        Stop("Impact");
        Stop("Theme01");
        Stop("Theme02");
        Stop("Theme03");
        Stop("Theme04");
    }
}
