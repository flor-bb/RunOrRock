using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    [SerializeField] public Sound[] sounds;
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;

            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    private void Start()
    {
        Play("Theme");
    }



    public void Play(string name)
    {
        //will find the sound with name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + s.name + " was not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        //will find the sound with name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + s.name + " was not found!");
            return;
        }
        s.source.Stop();
    }


}
