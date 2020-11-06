using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public Dropdown shapes;
    public Dropdown lightTiles;
    public Dropdown darkTiles;
    public Toggle vibration;
    public Toggle sound;

    // Start is called before the first frame update
    void Start()
    {
        int a = PlayerPrefs.GetInt("justInstal");

        if(a < 1)
        {
            PlayerPrefs.SetInt("justInstal",1);
            PlayerPrefs.SetString("LightColor", "white");
            PlayerPrefs.SetString("DarkColor", "black");
            PlayerPrefs.SetString("vibrate", "true");
            PlayerPrefs.SetString("sound", "true");
            PlayerPrefs.SetString("shape", "rounded");
        }

        AdjustSetting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AdjustSetting()
    {
        string a = PlayerPrefs.GetString("shape");
        string b = PlayerPrefs.GetString("LightColor");
        string c = PlayerPrefs.GetString("DarkColor");
        string d = PlayerPrefs.GetString("vibrate");

        if (a == "rounded")
        {
            shapes.value = 0;

        }
        else if (a == "square")
        {
            shapes.value = 1;

        }
        else if( a == "circle")
        {
            shapes.value = 2;
           
        }

        if (b == "white")
        {
            lightTiles.value = 0;

        }
        else if (b == "red")
        {
            lightTiles.value = 1;

        }

        if (c == "black")
        {
            darkTiles.value = 0;

        }
        else if (c == "red")
        {
            darkTiles.value = 1;

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

    public void TilesShape()
    {
        string shape = "a";

        if (shapes.value == 0)
        {
            shape = "rounded";
        }
        else if (shapes.value == 1)
        {
            shape = "square";
        }
        else
        {
            shape = "circle";
        }

        PlayerPrefs.SetString("shape", shape);
    }

    public void LightTilesColor()
    {
        string color = "a";

        if (lightTiles.value == 0)
        {
            color = "white";
        }
        else
        {
            color = "red";
        }

        PlayerPrefs.SetString("LightColor", color);
    }

    public void DarkTilesColor()
    {
        string color = "a";

        if (darkTiles.value == 0)
        {
            color = "black";
        }
        else
        {
            color = "red";
        }

        PlayerPrefs.SetString("DarkColor", color);
    }

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


}
