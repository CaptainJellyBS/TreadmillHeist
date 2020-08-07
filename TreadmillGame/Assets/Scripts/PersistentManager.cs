using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    public int maxUnlockedLevel;
    public float sfxVolume, musicVolume;

    public static PersistentManager Instance { get; private set; }
    private void Awake()
    {   
        if (GameObject.FindGameObjectsWithTag("PersistentManager").Length > 1)
        {
            if(this != Instance) { Destroy(gameObject); } //Kermit if multiple persistent managers have been made and I'm not the first one. 
        }

        if(maxUnlockedLevel < 1) { maxUnlockedLevel = 1; }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SetVolumes();
    }

    void SetVolumes()
    {
        if(PlayerPrefs.HasKey("masterVolume"))
        {
            SetMasterVolume(PlayerPrefs.GetFloat("masterVolume"));
        }
        else
        {
            SetMasterVolume(0.5f);
        }

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            SetMusicVolume(PlayerPrefs.GetFloat("musicVolume"));
        }
        else
        {
            SetMusicVolume(0.5f);
        }

        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            SetSFXVolume(PlayerPrefs.GetFloat("sfxVolume"));
        }
        else
        {
            SetSFXVolume(0.5f);
        }
    }

    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        PlayerPrefs.SetFloat("musicVolume", volume);
        GetComponentInChildren<AudioSource>().volume = musicVolume;
    }
}
