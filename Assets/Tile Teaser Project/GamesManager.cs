using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamesManager : MonoBehaviour
{
    private float time = 999;
    private int minutes = 60;
    public int turn = 999;
    public int score = 0;
    private float beginTime;
    public float finnishTime;
    public int finnishMinute;
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
            time = 00;
            minutes = 60;
            turn = 100;
            difficulty.text = "Easy";
            timeDisplay.text = minutes.ToString("00") + ":" + time.ToString("00");
            turnDisplay.text = "Turn: " + turn.ToString("0");
        }
        else if (mode == 5)
        {
            time = 00;
            minutes = 50;
            turn = 90;
            difficulty.text = "Medium";
            timeDisplay.text = minutes.ToString("00") + ":" + time.ToString("00");
            turnDisplay.text = "Turn: " + turn.ToString("0");
        }
        else if (mode == 6)
        {
            time = 00;
            minutes = 40;
            turn = 80;
            difficulty.text = "Hard";
            timeDisplay.text = minutes.ToString("00") + ":" + time.ToString("00");
            turnDisplay.text = "Turn: " + turn.ToString("0");
        }
        else if (mode == 7)
        {
            time = 00;
            minutes = 30;
            turn = 70;
            difficulty.text = "Expert";
            timeDisplay.text = minutes.ToString("00") + ":" + time.ToString("00");
            turnDisplay.text = "Turn: " + turn.ToString("0");
        }
        else if (mode == 8)
        {
            time = 00;
            minutes = 20;
            turn = 60;
            difficulty.text = "Giant";
            timeDisplay.text = minutes.ToString("00") + ":" + time.ToString("00");
            turnDisplay.text = "Turn: " + turn.ToString("0");
        }
        beginTime = time;


    }

    IEnumerator runTimer()
    {
        int a = (int)time;

        while(minutes >= 0 && a >= 0)
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

                if(time < 0)
                {
                    minutes--;
                    time = 59;
                }

                if (minutes >= 0)
                {
                    timeDisplay.text = minutes.ToString("00") + ":" + time.ToString("00");
                }
                
            }
            
            finnishTime++;

            if (finnishTime > 59)
            {
                finnishTime = 0;
                finnishMinute++;
            }

            yield return new WaitForSeconds(1);
        }

        //game over part in here
        if(minutes < 1)
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
            turnDisplay.text = "Turn: ";
        }
        else
        {
            turn -= t;
            turnDisplay.text = "Turn: " + turn.ToString("0");
        }
       
        
       

        if (turn < 1)
        {
            isPlaying = false;
            StopAllCoroutines();
            gameUIcontroler.GameOverInfo();
            CloseAllPanel();
            OpenPanel(0);
           
        }
        else if(turn > 0 && isPlaying == true)
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

        //finnishTime = beginTime - time;
        SaveLoadData.instance.SavingData();
    }

    public void Solution()
    {
        AdsManager.instance.UserChoseToWatchAd();
    }

    public void UseExploder(Text value)
    {
        int a = SaveLoadData.instance.playerData.exploder;

        
        if(exploder == true)
        {
            exploder = false;
            gameUIcontroler.exploderButton.image.color = Color.black;
            value.text = SaveLoadData.instance.playerData.exploder.ToString();
        }
        else
        {
            if (a > 0)
            {
                exploder = true;
                gameUIcontroler.exploderButton.image.color = Color.blue;
                value.text = SaveLoadData.instance.playerData.exploder.ToString();
            }

        }
    }

    public void UseInfiniteTimer(Text value)
    {
        int a = SaveLoadData.instance.playerData.infinityTimer;

        if (a > 0)
        {
            infiniteTimer = true;
            gameUIcontroler.infiniteTimeButton.interactable = false;
            SaveLoadData.instance.playerData.infinityTimer--;
            value.text = SaveLoadData.instance.playerData.infinityTimer.ToString();
            SaveLoadData.instance.playerData.infiniteTimerUsed++;

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
            gameUIcontroler.infiniteTurnButton.interactable = false;
            SaveLoadData.instance.playerData.infinityTurn--;
            value.text = SaveLoadData.instance.playerData.infinityTurn.ToString();
            SaveLoadData.instance.playerData.infiniteTurnUsed++;
        }
    }
}
