using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    public int ColorType;
    public GameObject RedHat;
    public GameObject YellowHat;
    public GameObject BlueHat;
    public float Health;
    void Start()
    {
        Health = 20;
        
        ColorType = Random.Range(0, 3);
        
        if (ColorType == 0)
        {
            RedHat.SetActive(true);
        }
        else if (ColorType == 1)
        {
            YellowHat.SetActive(true);
        }
        else if (ColorType == 2)
        {
            BlueHat.SetActive(true);
        }
        else
        {
            Debug.Log("Hat error");
        }
    }

    public void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        ProjectileScript Projectile = other.gameObject.GetComponent<ProjectileScript>();
        ProjectileRedScript ProjectileRed = other.gameObject.GetComponent<ProjectileRedScript>();
        ProjectileYellowScript ProjectileYellow = other.gameObject.GetComponent<ProjectileYellowScript>();
        ProjectileBlueScript ProjectileBlue = other.gameObject.GetComponent<ProjectileBlueScript>();

        if (Projectile != null)
        {
            Health -= 5;
            Destroy(other.gameObject);
        }
        if (ProjectileRed != null)
        {
            if (ColorType == 0)
            {
                Health -= 10;
            }
            else
            {
                Health -= 5;
            }
            Destroy(other.gameObject);
        }
        if (ProjectileYellow != null)
        {
            if (ColorType == 1)
            {
                Health -= 10;
            }
            else
            {
                Health -= 5;
            }
            Destroy(other.gameObject);
        }
        if (ProjectileBlue != null)
        {
            if (ColorType == 2)
            {
                Health -= 10;
            }
            else
            {
                Health -= 5;
            }
            Destroy(other.gameObject);
        }
    }
}
