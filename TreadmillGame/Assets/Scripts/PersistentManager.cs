using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("PersistentManager").Length > 1)
        {
            throw new MultiplePersistentObjectsOfSameTypeException("Cannot have more than one Persistent Manager in a scene");
        }
        DontDestroyOnLoad(gameObject);
    }
}
