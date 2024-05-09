using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Camera Eyes;
    public Rigidbody RB;
    public float MouseSensitivity = 3;
    public float WalkSpeed = 10;
    public ProjectileScript ProjectilePrefab;
    public ProjectileRedScript ProjectileRedPrefab;
    public ProjectileYellowScript ProjectileYellowPrefab;
    public ProjectileBlueScript ProjectileBluePrefab;
    public int Health;
    public float Cooldown;

    public void Awake()
    {
        God.PS = this;
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (God.GM.Gameover)
        {
            RB.velocity = Vector3.zero;
        }
        
        
        if (God.GM.ColorMenu == false)
        {
            float xRot = Input.GetAxis("Mouse X") * MouseSensitivity;
            float yRot = -Input.GetAxis("Mouse Y") * MouseSensitivity;
            transform.Rotate(0,xRot,0);

            Vector3 eRot = Eyes.transform.localRotation.eulerAngles;
            eRot.x += yRot;

            if (eRot.x < -180)
            {
                eRot.x += 360;
            }

            if (eRot.x > 180)
            {
                eRot.x -= 360;
            }

            eRot = new Vector3(Mathf.Clamp(eRot.x,-90,90),0,0);
            Eyes.transform.localRotation = Quaternion.Euler(eRot);

            if (WalkSpeed > 0)
            {
                Vector3 move = Vector3.zero;
                if (Input.GetKey(KeyCode.W))
                    move += transform.forward;
                if (Input.GetKey(KeyCode.S))
                    move -= transform.forward;
                if (Input.GetKey(KeyCode.A))
                    move -= transform.right;
                if (Input.GetKey(KeyCode.D))
                    move += transform.right;
                move = move.normalized * WalkSpeed;
            
                RB.velocity = move;
            }

            if (Cooldown > 0)
            {
                Cooldown -= Time.deltaTime;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                if (God.GM.ColorMagic == 1)
                {
                    Instantiate(ProjectilePrefab, Eyes.transform.position + Eyes.transform.forward,
                        Eyes.transform.rotation);
                    Cooldown = .25f;
                }
                if (God.GM.ColorMagic == 2)
                {
                    Health += 2;
                }
                if (God.GM.ColorMagic == 3)
                {
                    Instantiate(ProjectileRedPrefab, Eyes.transform.position + Eyes.transform.forward,
                        Eyes.transform.rotation);
                    Cooldown = .25f;
                }
                if (God.GM.ColorMagic == 4)
                {
                    Instantiate(ProjectileYellowPrefab, Eyes.transform.position + Eyes.transform.forward,
                        Eyes.transform.rotation);
                    Cooldown = .25f;
                }
                if (God.GM.ColorMagic == 5)
                {
                    Instantiate(ProjectileBluePrefab, Eyes.transform.position + Eyes.transform.forward,
                        Eyes.transform.rotation);
                    Cooldown = .25f;
                }
            }
        }
        else
        {
            RB.velocity = Vector3.zero;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        ProjectileEnemyScript EnemyProj = other.gameObject.GetComponent<ProjectileEnemyScript>();

        if (EnemyProj != null)
        {
            Health--;
            God.GM.UpdateHealth();
        }
    }
}
