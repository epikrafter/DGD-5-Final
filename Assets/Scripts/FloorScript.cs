using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public MeshRenderer Mesh;
    public Material Black;
    public Material Red;
    public Material Yellow;
    public Material Blue;
    public Material White;

    public void Update()
    {
        if (God.GM.Gameover)
        {
            Mesh.material = White;
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
            Mesh.material = Black;
        }
        if (ProjectileRed != null)
        {
            Mesh.material = Red;
        }
        if (ProjectileYellow != null)
        {
            Mesh.material = Yellow;
        }
        if (ProjectileBlue != null)
        {
            Mesh.material = Blue;
        }
    }
}
