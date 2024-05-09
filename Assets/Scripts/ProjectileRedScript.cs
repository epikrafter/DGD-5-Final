using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRedScript : MonoBehaviour
{
    public Rigidbody RB;
    public float Speed = 15;
    void Start()
    {
        RB.velocity = transform.forward * Speed;
    }
    public void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
