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
        speed = GameManager.Instance.treadmillSpeed;
    }

    public Vector3 GetTreadVector()
    {
        return transform.forward * speed * direction;
    }

    public void OnMouseDown()
    {
        direction++;
        if (direction > 1) { direction = -1; }
    }
}
