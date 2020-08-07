using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    public int maxUnlockedLevel;
    public float sfxVolume, musicVolume, masterVolume;

    public static PersistentManager Instance { get; private set; }
    private void Awake()
    {   
        if (GameObject.FindGameObjectsWithTag("PersistentManager").Length > 1)
        {
            if(this != Instance) { Destroy(this.gameObject); } //Kermit if multiple persistent managers have been made and I'm not the first one. 
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
