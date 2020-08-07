using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using UnityEngine;

public class RotatorPlate : Treadmill
{
    public float[] angles;
    int current;

    private void Start()
    {
        current = 0; direction = 1;
        transform.rotation = Quaternion.Euler(0, angles[current], 0);

        if (angles.Length < 1) { throw new ArgumentException("Cannot have 0 angles"); }
        foreach (SpriteRenderer s in GetComponentsInChildren<SpriteRenderer>())
        {
            s.transform.localScale = new Vector3((1 / transform.localScale.x) * s.transform.localScale.x, 1 / transform.localScale.z * s.transform.localScale.y, 1);
        }

        if (GameManager.Instance != null)
        { speed = GameManager.Instance.treadmillSpeed; }
        else
        { speed = 2; }
    }

    public override void OnMouseDown()
    {
        current++;
        current %= angles.Length;
        transform.rotation = Quaternion.Euler(0, angles[current], 0);
    }
}
