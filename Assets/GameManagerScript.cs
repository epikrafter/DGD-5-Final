using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class GameManagerScript : MonoBehaviour
{
    public Image Corner;
    public Image Selector;
    public Sprite Red;
    public void Awake()
    {
        God.GM = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Selector.sprite = Red;
        }
    }
}
