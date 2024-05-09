using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRedScript : MonoBehaviour
{
    public Rigidbody RB;
    public float Speed = 15;
    public float DeleteTimer = 5;
    void Start()
    {
        RB.velocity = transform.forward * Speed;
    }
    public void Update()
    {
        if (God.GM.Gameover)
        {
            Destroy(gameObject);
        }
        
        if (DeleteTimer > 0)
        {
            DeleteTimer -= Time.deltaTime;
        }
        else if (DeleteTimer <= 0)
        {
            Destroy(gameObject); 
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
