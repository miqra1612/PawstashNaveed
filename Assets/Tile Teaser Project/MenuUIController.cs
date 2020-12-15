using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    public GameObject buttonContinue;
    public RectTransform allButtons;
    private int eassyLeft;
    private int mediumLeft;
    private int hardLeft;
    private int expertLeft;
    private int giantLeft;


    public Text[] levelText;

    public GameObject[] panels;

    public GameObject[] statisticPanels;

    public static MenuUIController instance;

    private void Awake()
    {

        instance = this;
        SaveLoadData.instance.playerData.addFree = "false";
    }

    // Start is called before the first frame update
    void Start()
    {
        string a = SaveLoadData.instance.playerData.continueGame;

        string dates = SaveLoadData.instance.playerData.date;
        string currentDates = System.DateTime.Now.ToString("dd/MM/yyyy");

        if(dates != currentDates)
        {
            SaveLoadData.instance.OpenData();
            SaveLoadData.instance.playerData.date = currentDates;
            SaveLoadData.instance.playerData.eassyGameLeft = 20;
            SaveLoadData.instance.playerData.mediumGameLeft = 15;
            SaveLoadData.instance.playerData.hardGameLeft = 10;
            SaveLoadData.instance.playerData.expertGameLeft = 5;
            SaveLoadData.instance.playerData.giantGameLeft = 1;
        }
       
        if(a == "true")
        {
            ShowContinueButton();
        }

        GameLeftToday();

        AdsManager.instance.HideBanner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameLeftToday()
    {
        string a = SaveLoadData.instance.playerData.infinitePuzzle;

        if(a != "true")
        {
            eassyLeft = SaveLoadData.instance.playerData.eassyGameLeft;
            mediumLeft = SaveLoadData.instance.playerData.mediumGameLeft;
            hardLeft = SaveLoadData.instance.playerData.hardGameLeft;
            expertLeft = SaveLoadData.instance.playerData.expertGameLeft;
            giantLeft = SaveLoadData.instance.playerData.giantGameLeft;

            levelText[0].text = "Easy (" + eassyLeft + ")";
            levelText[1].text = "Medium (" + mediumLeft + ")";
            levelText[2].text = "Hard (" + hardLeft + ")";
            levelText[3].text = "Expert (" + expertLeft + ")";
            levelText[4].text = "Giant (" + giantLeft + ")";
        }
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

    public void BuyInfinitePuzzle()
    {
        Purchaser.instance.BuyInfinitePuzzle();
    }

    public void BuyAdsFree()
    {
        Purchaser.instance.BuyGoFreeAds();
    }

    public void BuyInfiniteTurn()
    {
        Purchaser.instance.BuyInfiniteTurn();
    }

    public void BuyInfiniteTime()
    {
        Purchaser.instance.BuyInfiniteTime();
    }

    public void BuySolution()
    {
        Purchaser.instance.BuySolution();
    }

    public void BuyExploder()
    {
        Purchaser.instance.BuyExploder();
        //SaveLoadData.instance.playerData.exploder += 10;
        //SaveLoadData.instance.SavingData();
    }
}
