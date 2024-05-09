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
    public bool ColorMenu;
    public int ColorMagic;
    public List<Sprite> SelectorSprite;
    public List<Sprite> CornerSprite;
    public EnemyScript Enemy;
    public void Awake()
    {
        God.GM = this;
    }

    public void Start()
    {
        ColorMagic = 0;
        ColorMenu = false;
        ColorSelector();
        
    }

    public void Update()
    {
        //Temp
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(Enemy);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ColorMenu)
            {
                ColorMenu = false;
                ColorSelector();
            }
            else
            {
                ColorMenu = true;
                ColorSelector();
            }
        }

        if (ColorMenu)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                switch (ColorMagic)
                {
                    case 0:
                        Selector.sprite = SelectorSprite[3];
                        Corner.sprite = CornerSprite[3];
                        ColorMagic = 3;
                        break;
                    case 1:
                        Selector.sprite = SelectorSprite[2];
                        Corner.sprite = CornerSprite[2];
                        ColorMagic = 2;
                        break;
                    case 2:
                        Selector.sprite = SelectorSprite[3];
                        Corner.sprite = CornerSprite[3];
                        ColorMagic = 3;
                        break;
                    case 3:
                        break;
                    case 4:
                        Selector.sprite = SelectorSprite[2];
                        Corner.sprite = CornerSprite[2];
                        ColorMagic = 2;
                        break;
                    case 5:
                        Selector.sprite = SelectorSprite[1];
                        Corner.sprite = CornerSprite[1];
                        ColorMagic = 1;
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                switch (ColorMagic)
                {
                    case 0:
                        Selector.sprite = SelectorSprite[1];
                        Corner.sprite = CornerSprite[1];
                        ColorMagic = 1;
                        break;
                    case 1:
                        Selector.sprite = SelectorSprite[5];
                        Corner.sprite = CornerSprite[5];
                        ColorMagic = 5;
                        break;
                    case 2:
                        Selector.sprite = SelectorSprite[1];
                        Corner.sprite = CornerSprite[1];
                        ColorMagic = 1;
                        break;
                    case 3:
                        Selector.sprite = SelectorSprite[2];
                        Corner.sprite = CornerSprite[2];
                        ColorMagic = 2;
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                switch (ColorMagic)
                {
                    case 0:
                        Selector.sprite = SelectorSprite[5];
                        Corner.sprite = CornerSprite[5];
                        ColorMagic = 5;
                        break;
                    case 1:
                        Selector.sprite = SelectorSprite[5];
                        Corner.sprite = CornerSprite[5];
                        ColorMagic = 5;
                        break;
                    case 2:
                        Selector.sprite = SelectorSprite[1];
                        Corner.sprite = CornerSprite[1];
                        ColorMagic = 1;
                        break;
                    case 3:
                        Selector.sprite = SelectorSprite[5];
                        Corner.sprite = CornerSprite[5];
                        ColorMagic = 5;
                        break;
                    case 4:
                        Selector.sprite = SelectorSprite[2];
                        Corner.sprite = CornerSprite[2];
                        ColorMagic = 2;
                        break;
                    case 5:
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                switch (ColorMagic)
                {
                    case 0:
                        Selector.sprite = SelectorSprite[4];
                        Corner.sprite = CornerSprite[3];
                        ColorMagic = 4;
                        break;
                    case 1:
                        Selector.sprite = SelectorSprite[2];
                        Corner.sprite = CornerSprite[2];
                        ColorMagic = 2;
                        break;
                    case 2:
                        Selector.sprite = SelectorSprite[4];
                        Corner.sprite = CornerSprite[4];
                        ColorMagic = 4;
                        break;
                    case 3:
                        Selector.sprite = SelectorSprite[4];
                        Corner.sprite = CornerSprite[4];
                        ColorMagic = 4;
                        break;
                    case 4:
                        break;
                    case 5:
                        Selector.sprite = SelectorSprite[1];
                        Corner.sprite = CornerSprite[1];
                        ColorMagic = 1;
                        break;
                }
            }
        }
    }

    public void ColorSelector()
    {
        if (ColorMenu)
        {
            Selector.color = Color.white;
            Corner.color = Color.clear;
        }
        else
        {
            Selector.color = Color.clear;
            Corner.color = Color.white;
        }
    }
}
