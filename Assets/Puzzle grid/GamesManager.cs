using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamesManager : MonoBehaviour
{
    private float time = 999;
    public int turn = 999;
    public int score = 0;
    private float beginTime;
    public float finnishTime;
    public int undoAmount;

    private PuzzleGenerator puzzle;
    private GameUIController gameUIcontroler;
    public Text difficulty;
    public Text scoreDisplay;
    public Text timeDisplay;
    public Text turnDisplay;
    public bool isPlaying = false;
    public bool exploder = false;
    public Text exploderValue;
    public bool infiniteTurn = false;
    public Text infiniteTurnValue;
    public GameObject infiniteIconTurn;
    public bool infiniteTimer = false;
    public Text infiniteTimeValue;
    public GameObject infiniteIconTimer;
    private string vibration;

    public GameObject[] UIpanels;
    
    public static GamesManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        puzzle = GameObject.FindGameObjectWithTag("manager").GetComponent<PuzzleGenerator>();
        gameUIcontroler = GameObject.FindGameObjectWithTag("manager").GetComponent<GameUIController>();
        scoreDisplay.text = "0";

        exploderValue.text = SaveLoadData.instance.playerData.exploder.ToString();
        infiniteTimeValue.text = SaveLoadData.instance.playerData.infinityTimer.ToString();
        infiniteTurnValue.text = SaveLoadData.instance.playerData.infinityTurn.ToString();

        checkDifficulty();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkDifficulty()
    {
        int mode = puzzle.puzzleSize;

        if (mode == 4)
        {
            time = 60;
            turn = 100;
            difficulty.text = "Easy";
            timeDisplay.text = time.ToString("00:00");
            turnDisplay.text = "Turn: " + turn.ToString("0");
        }
        else if (mode == 5)
        {
            time = 50;
            turn = 90;
            difficulty.text = "Medium";
            timeDisplay.text = time.ToString("00:00");
            turnDisplay.text = "Turn: " + turn.ToString("0");
        }
        else if (mode == 6)
        {
            time = 40;
            turn = 80;
            difficulty.text = "Hard";
            timeDisplay.text = time.ToString("00:00");
            turnDisplay.text = "Turn: " + turn.ToString("0");
        }
        else if (mode == 7)
        {
            time = 30;
            turn = 70;
            difficulty.text = "Expert";
            timeDisplay.text = time.ToString("00:00");
            turnDisplay.text = "Turn: " + turn.ToString("0");
        }
        else if (mode == 8)
        {
            time = 20;
            turn = 60;
            difficulty.text = "Giant";
            timeDisplay.text = time.ToString("00:00");
            turnDisplay.text = "Turn: " + turn.ToString("0");
        }
        beginTime = time;


    }

    IEnumerator runTimer()
    {
        int a = (int)time;

        for(int i = 0; i < a; i++)
        {
            if(infiniteTimer == true)
            {
                time = 9999;
                timeDisplay.text = " ";
                infiniteIconTimer.SetActive(true);
            }
            else
            {
                time--;
                timeDisplay.text = time.ToString("00:00");
            }
           
            yield return new WaitForSeconds(1);
        }

        if(time < 1)
        {
            isPlaying = false;
            gameUIcontroler.GameOverInfo();
            CloseAllPanel();
            OpenPanel(0);
        }
    }

    public void StartGame()
    {
        puzzle.StartChangeColor();
        AdsManager.instance.ShowBannerAgain();
    }

    public void StartTimer()
    {
        StartCoroutine(runTimer());
    }

    public void TakeOutTurn(int t)
    {
        if(infiniteTurn == true)
        {
            turn = 999;
        }
        else
        {
            turn -= t;
        }
       
        turnDisplay.text = "Turn: " + turn.ToString("0");
       

        if (turn < 1)
        {
            isPlaying = false;
            gameUIcontroler.GameOverInfo();
            CloseAllPanel();
            OpenPanel(0);
        }
        else
        {
            puzzle.CheckingColor();
        }
    }

    public void OpenPanel(int panelElement)
    {
        CloseAllPanel();
        UIpanels[panelElement].SetActive(true);
    }

    public void CloseAllPanel()
    {
        for(int i = 0; i < UIpanels.Length; i++)
        {
            UIpanels[i].SetActive(false);
        }
    }

    public void EndGame()
    {
        isPlaying = false;
        StopAllCoroutines();

        finnishTime = beginTime - time;
        SaveLoadData.instance.SavingData();
    }

    public void Solution()
    {
        AdsManager.instance.UserChoseToWatchAd();
    }

    public void UseExploder(Text value)
    {
        int a = SaveLoadData.instance.playerData.exploder;

        if(a > 0)
        {
            exploder = true;
            SaveLoadData.instance.playerData.exploder--;
            value.text = SaveLoadData.instance.playerData.exploder.ToString();
        }
    }

    public void UseInfiniteTimer(Text value)
    {
        int a = SaveLoadData.instance.playerData.infinityTimer;

        if (a > 0)
        {
            infiniteTimer = true;
            SaveLoadData.instance.playerData.infinityTimer--;
            value.text = SaveLoadData.instance.playerData.infinityTimer.ToString();
        }
    }

    public void UseInfiniteTurn(Text value)
    {
        int a = SaveLoadData.instance.playerData.infinityTurn;

        if (a > 0)
        {
            turnDisplay.text = "Turn: ";
            infiniteIconTurn.SetActive(true);
            infiniteTurn = true;
            SaveLoadData.instance.playerData.infinityTurn--;
            value.text = SaveLoadData.instance.playerData.infinityTurn.ToString();
        }
    }
}
