using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIController : MonoBehaviour
{
    public GameObject buttonContinue;
    public RectTransform allButtons;

    public GameObject[] panels;

    public GameObject[] statisticPanels;

    // Start is called before the first frame update
    void Start()
    {
        string a = SaveLoadData.instance.playerData.continueGame;

        string dates = SaveLoadData.instance.playerData.date;
        string currentDates = System.DateTime.Now.ToString("dd/MM/yyyy");

        if(dates != currentDates)
        {
            SaveLoadData.instance.playerData.date = currentDates;
            SaveLoadData.instance.playerData.eassyGameLeft = 20;
            SaveLoadData.instance.playerData.mediumGameLeft = 15;
            SaveLoadData.instance.playerData.hardGameLeft = 10;
            SaveLoadData.instance.playerData.expertGameLeft = 5;
            SaveLoadData.instance.playerData.giantGameLeft = 1;
            SaveLoadData.instance.OpenData();
        }
       
        if(a == "true")
        {
            ShowContinueButton();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowContinueButton()
    {
        buttonContinue.SetActive(true);
        allButtons.anchoredPosition = new Vector3(0, -300, 0);
        allButtons.sizeDelta = new Vector2(1280, 900);
        allButtons.localScale = Vector3.one;
    }

    void CloseAllPanels()
    {
        for(int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }

    }

    void CloseAllStatisticPanels()
    {
        for (int i = 0; i < statisticPanels.Length; i++)
        {
            statisticPanels[i].SetActive(false);
        }

    }

    public void OpenPanel(int i)
    {
        CloseAllPanels();

        panels[i].SetActive(true);
    }

    public void OpenStatisticPanel(int i)
    {
        CloseAllStatisticPanels();

        statisticPanels[i].SetActive(true);
    }

    public void GameContinue(string condition)
    {
        SaveLoadData.instance.playerData.continueGame = condition;
    }
}
