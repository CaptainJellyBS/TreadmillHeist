using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    // Start is called before the first frame update
    protected Vector3 treadVector;
    protected Treadmill curMill;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
    }

    protected virtual void Movement()
    {
        if (curMill == null) { treadVector = Vector3.zero; }
        else { treadVector = curMill.GetTreadVector(); }
        transform.position += treadVector * Time.deltaTime;
    }

    protected void OnCollisionStay(Collision col)
    {
        if(curMill != null) { return; }
        if(col.collider.tag == "Treadmill")
        {
            curMill = col.collider.GetComponent<Treadmill>();
        }
    }

    protected void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "Treadmill")
        {
            curMill = null;
        }
    }
}
