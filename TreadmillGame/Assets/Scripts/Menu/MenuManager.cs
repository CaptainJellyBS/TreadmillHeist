using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject PlayPanel, SettingsPanel;
    public GameObject Level1Button;
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePlayButtons()
    {
        for (int i = 1, y = 0; i < SceneManager.sceneCountInBuildSettings && y<5; y++)
        {
            for (int x = 0; x < 4; x++, i++)
            {
                GameObject newBut = Instantiate(Level1Button, Level1Button.transform.parent);
                LevelButton button = newBut.GetComponent<LevelButton>();
                button.buildIndex = i;
                newBut.transform.position += new Vector3(x * 150, -y * 85,0);
                newBut.GetComponentInChildren<Text>().text = "Level " + i;
            }
        }

        Destroy(Level1Button);
    }
}
