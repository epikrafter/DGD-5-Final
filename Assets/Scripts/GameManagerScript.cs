using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class GameManagerScript : MonoBehaviour
{
    public Image Corner;
    public Image Selector;
    public bool ColorMenu;
    public int ColorMagic;
    public List<Sprite> SelectorSprite;
    public List<Sprite> CornerSprite;
    public EnemyScript Enemy;
    public Image GameoverImage;
    public bool Gameover;
    public int Wave;
    public int EnemyCount;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI WaveText;
    public void Awake()
    {
        God.GM = this;
    }

    public void Start()
    {
        ColorMagic = 0;
        Wave = 0;
        ColorMenu = false;
        ColorSelector();
        GameoverImage.color = Color.clear;
        
    }

    public void Update()
    {
        if (God.PS.Health <= 0)
        {
            Gameover = true;
            GameoverImage.color = Color.white;
            Selector.color = Color.clear;
            Corner.color = Color.clear;
        }

        if (Gameover)
        {
            if (Input.GetMouseButtonDown(0))
            {
                God.PS.Health = 5;
                Wave = 0;
                GameoverImage.color = Color.clear;
                ColorSelector();
                Gameover = false;
            }
        }

        if (EnemyCount <= 0)
        {
            Wave++;
            UpdateWave();
            StartCoroutine(EnemySpawn());
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

    public void UpdateWave()
    {
        WaveText.text = "Wave: " + Wave;
    }

    public void UpdateHealth()
    {
        HealthText.text = "Health: " + God.PS.Health;
    }
    public IEnumerator EnemySpawn()
    {
        for (int i = 0; i < 2*(Wave-1)+1; i++)
        {
            float RandomX = Random.Range(-10f, 8f);
            float RandomZ = Random.Range(-10f, 8f);
            
            Instantiate(Enemy,new Vector3(RandomX,25,RandomZ),Quaternion.identity);
            EnemyCount++;
            yield return new WaitForSeconds(Random.Range(.5f, 2f));
        }
    }
}
