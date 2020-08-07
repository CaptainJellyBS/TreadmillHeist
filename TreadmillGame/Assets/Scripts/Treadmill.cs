using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treadmill : MonoBehaviour
{
    [Range(-1,1)]
    public int speed;


    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetTreadVector()
    {
        return direction * speed;
    }
}
