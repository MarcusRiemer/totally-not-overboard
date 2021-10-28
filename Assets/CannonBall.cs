using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float speed = 3;
    
    private float spawnTime;

    private static float maxAge = 20;

    private void Start()
    {
        spawnTime = Time.time;
    }

    private void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);

        if (Time.time > spawnTime + maxAge)
        {
            Debug.LogWarning($"Had to destroy cannon ball because of max age");
            Destroy(this);
        }
    }
}
