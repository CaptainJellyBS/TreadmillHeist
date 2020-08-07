using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
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
        realSpeed = moveSpeed * GameManager.Instance.treadmillSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        CheckPatrolPoint();
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

    float GetPlanarAngle(Vector3 one, Vector3 two)
    {
        Vector3 tone = new Vector3(one.x, 0, one.z);
        Vector3 ttwo = new Vector3(two.x, 0, two.z);
        Debug.Log(Vector3.SignedAngle(tone, ttwo, Vector3.up));
        return Vector3.SignedAngle(tone, ttwo, Vector3.up);
    }

}
