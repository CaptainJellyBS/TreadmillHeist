using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject PlayPanel, SettingsPanel;
    public GameObject Level1Button;

    public Slider masterSlider, musicSlider, sfxSlider;

    List<Button> playButtons;
    // Start is called before the first frame update
    void Start()
    {
        playButtons = new List<Button>();
        CreatePlayButtons();
        UpdateSliders();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePlayButtons()
    {
        for (int i = 1, y = 0; i < SceneManager.sceneCountInBuildSettings && y<5; y++)
        {
            for (int x = 0; x < 4 && i<SceneManager.sceneCountInBuildSettings; x++, i++)
            {
                GameObject newBut = Instantiate(Level1Button, Level1Button.transform.parent);
                LevelButton button = newBut.GetComponent<LevelButton>();
                button.buildIndex = i;
                newBut.transform.position += new Vector3(x * 275 * transform.localScale.x, -y * 165,0 * transform.localScale.y);
                newBut.GetComponentInChildren<Text>().text = "Level " + i;
                playButtons.Add(newBut.GetComponent<Button>());
            }
        }

        Destroy(Level1Button);
    }

    public void UpdatePlayButtons()
    {
        for (int i = 0; i < playButtons.Count; i++)
        {
            playButtons[i].interactable = i < FindObjectOfType<PersistentManager>().maxUnlockedLevel;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void UpdateSliders()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }
}
