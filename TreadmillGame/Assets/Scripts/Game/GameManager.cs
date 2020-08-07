using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float treadmillSpeed;
    public GameObject winPanel, diePanel, pausePanel;
    public Slider masterSlider, musicSlider, sfxSlider;
    bool paused, finished;

    private void Awake()
    {
        Instance = this;
        paused = false;
        finished = false;
        NormalTime();
    }

    private void Start()
    {
        UpdateSliders();
    }

    private void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !finished)
        {
            TogglePause();
        }
    }

    #region state switching
    public void Win()
    {
        PersistentManager.Instance.maxUnlockedLevel = SceneManager.GetActiveScene().buildIndex + 1;
        finished = true;
        winPanel.SetActive(true);
        PauseTime();
    }

    public void Die()
    {
        finished = true;
        diePanel.SetActive(true);
        PauseTime();
    }

    public void TogglePause()
    {
        paused = !paused;
        pausePanel.SetActive(paused);
        if (paused) { PauseTime(); return; }
        NormalTime();
    }
    #endregion

    #region time management
    public void NormalTime()
    {
        Time.timeScale = 1.0f;
    }

    public void PauseTime()
    {
        Time.timeScale = 0.0f;
    }
    #endregion

    #region UI
    #region buttons
    public void NextLevel()
    {
        NormalTime();
        
        //Return to the main menu if there is no active scenes
        if(SceneManager.GetActiveScene().buildIndex +1 >= SceneManager.sceneCountInBuildSettings)
        {
            ToMainMenu(); return;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void RestartLevel()
    {
        NormalTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(int buildIndex)
    {
        NormalTime();
        SceneManager.LoadScene(buildIndex);
    }

    public void ToMainMenu()
    {
        NormalTime();
        SceneManager.LoadScene(0);
    }
    #endregion buttons

    #region Sliders
    public void UpdateSliders()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    public void SetMasterVolume(float volume)
    {
        PersistentManager.Instance.SetMasterVolume(volume);
    }

    public void SetSFXVolume(float volume)
    {
        PersistentManager.Instance.SetSFXVolume(volume);
    }
    public void SetMusicVolume(float volume)
    {
        PersistentManager.Instance.SetMusicVolume(volume);
    }
    #endregion

    #endregion
}
