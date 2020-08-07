using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    private int unlockedLevel;
    public int maxUnlockedLevel
    {
        get { return unlockedLevel; } 
        set
        {
            unlockedLevel = value;
            SaveGame();
        }

    }
    public float sfxVolume, musicVolume;

    public static PersistentManager Instance { get; private set; }
    private void Awake()
    {   
        if (GameObject.FindGameObjectsWithTag("PersistentManager").Length > 1)
        {
            if(this != Instance) { Destroy(gameObject); } //Kermit if multiple persistent managers have been made and I'm not the first one. 
        }

        LoadGame();
        if(maxUnlockedLevel < 1) { maxUnlockedLevel = 1; }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SetVolumes();
    }

    #region volumes

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

    #endregion

    #region Saving/Loading
    
    //Saving data code stolen from: https://www.raywenderlich.com/418-how-to-save-and-load-a-game-in-unity#toc-anchor-001
    public void SaveGame()
    {
        SaveData saveData = new SaveData();
        saveData.levelUnlocked = maxUnlockedLevel;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, saveData);
        file.Close();
    }

    //Loading data code stolen from: https://www.raywenderlich.com/418-how-to-save-and-load-a-game-in-unity#toc-anchor-001
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            SaveData save = (SaveData)bf.Deserialize(file);
            file.Close();

            maxUnlockedLevel = save.levelUnlocked;
        }
        else
        {
            Debug.Log("No game saved!");
            maxUnlockedLevel = 1;
        }
    }


    #endregion
}
