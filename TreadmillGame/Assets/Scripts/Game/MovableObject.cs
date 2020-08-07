using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 treadVector;
    Treadmill curMill;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(curMill == null) { treadVector = Vector3.zero; }
        else { treadVector = curMill.GetTreadVector(); }
        transform.position += treadVector * Time.deltaTime;
        //rb.MovePosition(transform.position + (treadVector * Time.deltaTime));
    }

    void OnCollisionStay(Collision col)
    {
        if(curMill != null) { return; }
        if(col.collider.tag == "Treadmill")
        {
            curMill = col.collider.GetComponent<Treadmill>();
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "Treadmill")
        {
            curMill = null;
        }
    }
}
