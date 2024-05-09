using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningScript : MonoBehaviour
{
    public float Rotation;
    public float DeathTimer;

    private void Start()
    {
        DeathTimer = 2;
    }

    void Update()
    {
        if (DeathTimer > 0)
        {
            DeathTimer -= Time.deltaTime;
        }
        else if (DeathTimer <= 0)
        {
            Destroy(gameObject);
        }
        
        Rotation += .25f;
        transform.rotation = Quaternion.Euler(0,Rotation,0);
    }
}
