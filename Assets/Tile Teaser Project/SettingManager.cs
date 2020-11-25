﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class SettingManager : MonoBehaviour
{
    public Text Debugtext;

    public Toggle[] shapes;
    public Toggle[] lightTiles;
    public Toggle[] darkTiles;

    [Header("other setting here")]
    public Toggle vibration;
    public Toggle sound;
    private PuzzleGenerator pg;

    private string appID = "ca-app-pub-3850042963742973~2621600816";

    public static SettingManager sg;

    private void Awake()
    {
        sg = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(appID);

        SaveLoadData.instance.OpenData();
        int a = PlayerPrefs.GetInt("justInstal");
        Debug.Log("nilai a: " + a);

        if(a < 1)
        {
            PlayerPrefs.SetInt("justInstal",1);
            PlayerPrefs.SetString("LightColor", "white");
            PlayerPrefs.SetString("DarkColor", "black");
            PlayerPrefs.SetString("vibrate", "true");
            PlayerPrefs.SetString("sound", "true");
            PlayerPrefs.SetString("shape", "rounded");
            SaveLoadData.instance.playerData.exploder = 3;
            SaveLoadData.instance.playerData.infinityTimer = 3;
            SaveLoadData.instance.playerData.infinityTurn = 3;
            SaveLoadData.instance.playerData.solutions = 10;
            SaveLoadData.instance.playerData.challengeID = 1;
            SaveLoadData.instance.playerData.addFree = "false";
            SaveLoadData.instance.playerData.infinitePuzzle = "false";
        }
       

        AdjustSetting();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CloseAllShape()
    {
        for(int i = 0; i < shapes.Length; i++)
        {
            shapes[i].isOn = false;
        }
    }

    void CloseAllLightTile()
    {
        for (int i = 0; i < lightTiles.Length; i++)
        {
            lightTiles[i].isOn = false;
        }
    }

    void CloseAllDarkTile()
    {
        for (int i = 0; i < darkTiles.Length; i++)
        {
            darkTiles[i].isOn = false;
        }
    }

    void AdjustSetting()
    {
        CloseAllShape();
        CloseAllLightTile();
        CloseAllDarkTile();

        string a = PlayerPrefs.GetString("shape");
        string b = PlayerPrefs.GetString("LightColor");
        string c = PlayerPrefs.GetString("DarkColor");
        string d = PlayerPrefs.GetString("vibrate");

        if (a == "rounded")
        {
            shapes[0].isOn = true;

        }
        else if (a == "square")
        {
            shapes[1].isOn = true;

        }
        else if( a == "circle")
        {
            shapes[2].isOn = true;

        }

        if (b == "white")
        {
            lightTiles[0].isOn = true;

        }
        else if (b == "redL")
        {
            lightTiles[1].isOn = true;

        }

        if (c == "black")
        {
            darkTiles[0].isOn = true;

        }
        else if (c == "redD")
        {
            darkTiles[1].isOn = true;

        }

        if (d == "true")
        {
            vibration.isOn = true;

        }
        else if (d == "false")
        {
            vibration.isOn = false;

        }

    }

    public void TilesShape(int i)
    {
        CloseAllShape();
        string shape = "a";
        shapes[i].isOn = true;

        if (shapes[0].isOn == true)
        {
            shape = "rounded";
        }
        else if (shapes[1].isOn == true)
        {
            shape = "square";
        }
        else if (shapes[2].isOn == true)
        {
            shape = "circle";
        }

        PlayerPrefs.SetString("shape", shape);
    }

    public void LightTilesColor(int i)
    {
        CloseAllLightTile();

        string colorL = "a";
        string colorD = "a";

        lightTiles[i].isOn = true;

        if (lightTiles[0].isOn == true)
        {
            colorL = "white";
            colorD = "black";
        }
        else if (lightTiles[1].isOn == true)
        {
            colorL = "white";
            colorD = "redD";
        }
        else if (lightTiles[2].isOn == true)
        {
            colorL = "redL";
            colorD = "black";
        }

        PlayerPrefs.SetString("LightColor", colorL);
        PlayerPrefs.SetString("DarkColor", colorD);

    }

    /*
    public void DarkTilesColor(int i)
    {
        CloseAllDarkTile();

        string color = "a";
        darkTiles[i].isOn = true;

        if (darkTiles[0].isOn == true)
        {
            color = "black";
        }
        else if (darkTiles[1].isOn == true)
        {
            color = "redD";
        }

        PlayerPrefs.SetString("DarkColor", color);
    }*/

    public void VibrationSetting()
    {
        string a = PlayerPrefs.GetString("vibrate");

        if(a == "true")
        {
            PlayerPrefs.SetString("vibrate", "false");
        }
        else
        {
            PlayerPrefs.SetString("vibrate", "true");
            Handheld.Vibrate();
        }
    }

    public void SoundSetting()
    {
        string a = PlayerPrefs.GetString("sound");

        if (a == "true")
        {
            PlayerPrefs.SetString("sound", "false");
        }
        else
        {
            PlayerPrefs.SetString("sound", "true");
           
        }
    }

    public void PauseWhenOpenSetting()
    {
        pg = GameObject.FindGameObjectWithTag("manager").GetComponent<PuzzleGenerator>();

        GamesManager.instance.isPlaying = false;
        Time.timeScale = 0;
    }

    public void ContinueAndApplySettingWhenPlay()
    {
       
        pg.ApplyNewSettings();
        GamesManager.instance.isPlaying = true;
        Time.timeScale = 1;

    }

    public void DebugText(string textTes)
    {
        Debugtext.text = textTes;
    }
}
