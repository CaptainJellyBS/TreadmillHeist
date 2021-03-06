﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MovableObject
{
    public GameObject[] patrolPoints;
    public float moveSpeed;
    float realSpeed;
    public float arriveDistance;
    Rigidbody rb;
    int currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPoint = 0;
        CalcRotation();
        if (GameManager.Instance != null)
        { realSpeed = moveSpeed * GameManager.Instance.treadmillSpeed; }
        else
        { realSpeed = moveSpeed*2; }
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        CheckPatrolPoint();
        Movement();

        if(transform.position.y < -5)
        {
            GameManager.Instance.Die();
        }
    }

    protected override void Movement()
    {
        if(curMill == null) { return; }
        if(curMill is RotatorPlate) { return; } //Guards ignore rotator plates
        base.Movement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Guard") || collision.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
        }
    }

    void Walk()
    {
        Vector3 direction = (patrolPoints[currentPoint].transform.position - transform.position).normalized;
        //rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));    
        transform.position += (direction * realSpeed * Time.deltaTime);
    }

    void CheckPatrolPoint()
    {
        if(Vector3.Distance(patrolPoints[currentPoint].transform.position, transform.position) < arriveDistance)
        {
            currentPoint++;
            currentPoint %= patrolPoints.Length;
            CalcRotation();
        }
    }

    void CalcRotation()
    {
        Vector3 dir = (patrolPoints[currentPoint].transform.position - transform.position).normalized;
        transform.rotation = Quaternion.AngleAxis(GetPlanarAngle(Vector3.forward, dir), Vector3.up);
    }

    /// <summary>
    /// Calculate the signed angle of two vectors, on the horizontal plane only
    /// </summary>
    /// <param name="one"></param>
    /// <param name="two"></param>
    /// <returns></returns>
    float GetPlanarAngle(Vector3 one, Vector3 two)
    {
        Vector3 tone = new Vector3(one.x, 0, one.z);
        Vector3 ttwo = new Vector3(two.x, 0, two.z);
        return Vector3.SignedAngle(tone, ttwo, Vector3.up);
    }

}
