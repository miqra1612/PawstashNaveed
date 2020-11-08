using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    private float time = 999;
    public int turn = 999;
    public int score = 0;
    public int todaysTurn = 20;
    public int winningToday = 0;

    [Header("This part for winning panel UI")]
    public Text finnishTimeDisplay;
    public Text bestTimeDisplay;
    public Text scoreDisplay;
    public Text bestScoreDisplay;
    public Text Level;
    public Text Result;

    [Header("This part for pause panel UI")]
    public Text timeLeftDisplay;
    public Text turnLeftDisplay;
    public Text toolTipDisplay;
    public Image toolTipImage;
    public Text difficultyDisplay;
    public Sprite[] toolTipSprite;

    [Header("This part for game over panel UI")]
    public Text levelDisplay;
    private int gameRemaining = 4;

    private GamesManager gameManager;
    private IklanManager adsView;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GamesManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowWinningResult(int finalScore,int todayWin)
    {
        time = gameManager.finnishTime;
        score += finalScore;
        winningToday += todayWin;

        scoreDisplay.text = score.ToString();
        bestScoreDisplay.text = score.ToString();

        finnishTimeDisplay.text = time.ToString("00:00");
        bestTimeDisplay.text = time.ToString("00:00");

        Level.text = gameManager.difficulty.text;
        Result.text = winningToday.ToString() + " wins today! it's " + winningToday.ToString() + " more than yesterday!";

        adsView = GameObject.FindGameObjectWithTag("addManager").GetComponent<IklanManager>();

        if (adsView != null)
        {
            adsView.HideBanner();
        }
    }

    public void PauseGame()
    {
        gameManager.UIpanels[2].SetActive(true);
        PauseInfo();
        Time.timeScale = 0;

    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        gameManager.CloseAllPanel();
    }

    void PauseInfo()
    {
        timeLeftDisplay.text = gameManager.timeDisplay.text;
        difficultyDisplay.text = gameManager.difficulty.text;
        turnLeftDisplay.text = gameManager.turn.ToString();

        int a = Random.Range(0, 5);

        if(a == 0)
        {
            toolTipDisplay.text = "Use undo button to go back 1 step";
        }
        else if (a == 1)
        {
            toolTipDisplay.text = "Finish challenges can give you usefull bonus";
        }
        else if (a == 2)
        {
            toolTipDisplay.text = "Use flip button to flip the puzzle color";
        }
        else if (a == 3)
        {
            toolTipDisplay.text = "Pay attention to your time";
        }
        else if (a == 4)
        {
            toolTipDisplay.text = "Infinity timer can give you infinite time";
        }
    }

    public void GameOverInfo()
    {
        levelDisplay.text = "Level " + gameManager.difficulty.text + " you have " + gameRemaining + " for today.";
    }


}
