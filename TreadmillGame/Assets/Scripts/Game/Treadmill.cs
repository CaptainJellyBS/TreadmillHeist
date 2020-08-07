using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treadmill : MonoBehaviour
{
    [Range(-1,1)]
    public int direction;
    bool hoveredOver;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null)
        { speed = GameManager.Instance.treadmillSpeed; }
        else
        { speed = 2; }

        foreach(SpriteRenderer s in GetComponentsInChildren<SpriteRenderer>())
        {
            s.transform.localScale = new Vector3((1/transform.localScale.x) * s.transform.localScale.x, 1/transform.localScale.z * s.transform.localScale.y, 1);
        }

        SetSprites();
    }

    public Vector3 GetTreadVector()
    {
        return transform.forward * speed * direction;
    }

    public void OnMouseDown()
    {
        direction++;
        if (direction > 1) { direction = -1; }
        SetSprites();
    }

    void SetSprites()
    {
        switch(direction)
        {
            case -1:
                foreach (SpriteRenderer s in GetComponentsInChildren<SpriteRenderer>(true))
                {
                    s.gameObject.SetActive(true); s.transform.localRotation = Quaternion.Euler(90, 180, 0);
                }
                    break;
            case 0:
                foreach (SpriteRenderer s in GetComponentsInChildren<SpriteRenderer>(true))
                {
                    s.gameObject.SetActive(false);
                }
                break;
            case 1:
                foreach (SpriteRenderer s in GetComponentsInChildren<SpriteRenderer>(true))
                {
                    s.gameObject.SetActive(true); s.transform.localRotation = Quaternion.Euler(90, 0, 0);
                }
                break;
        }
    }
}
