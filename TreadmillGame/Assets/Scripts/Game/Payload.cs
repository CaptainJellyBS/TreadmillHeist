using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Payload : MonoBehaviour
{
    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5.0f) { Die();}
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Finish": Win(); break;
            case "Death": Die(); break;
        }
    }

    void Win()
    {
        Debug.Log("You win!");
        GameManager.Instance.Win();
    }

    void Die()
    {
        if (dead) { return; }
        dead = true;
        Debug.Log("You die!");
        GameManager.Instance.Die();
    }
}
