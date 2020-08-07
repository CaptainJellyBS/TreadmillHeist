using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    public GameObject toToggle;
    public GameObject[] turnOff;
    public bool isActive;

    private void Update()
    {
        isActive = toToggle.activeSelf;
    }
    public void OnClick()
    {
        toToggle.SetActive(!isActive);

        foreach(GameObject go in turnOff)
        {
            go.SetActive(false);            
        }
    }

}
