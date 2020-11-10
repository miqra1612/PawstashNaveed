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
    private AdsManager adsView;
    private PuzzleGenerator puzzleGenerator;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GamesManager>();
        puzzleGenerator = GameObject.FindGameObjectWithTag("manager").GetComponent<PuzzleGenerator>();
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

        adsView = GameObject.FindGameObjectWithTag("addManager").GetComponent<AdsManager>();

        if (adsView != null)
        {
            adsView.HideBanner();
            Debug.Log("hiding banner");
        }

        if(Level.text == "Easy")
        {
            SaveLoadData.instance.playerData.eassyScore += score;
            SaveLoadData.instance.playerData.eassyTotalScore += finalScore;
            SaveLoadData.instance.playerData.eassyGameLeft--;
            SaveLoadData.instance.playerData.eassyGameWon++;
            SaveLoadData.instance.playerData.eassyGamePlayed++;
            SaveLoadData.instance.playerData.eassyWinRate = ((float)SaveLoadData.instance.playerData.eassyGameWon / (float)SaveLoadData.instance.playerData.eassyGamePlayed) * 100;
            SaveLoadData.instance.playerData.eassyBestTime = time;
        }
        else if (Level.text == "Medium")
        {
            SaveLoadData.instance.playerData.mediumScore += score;
            SaveLoadData.instance.playerData.mediumTotalScore += finalScore;
            SaveLoadData.instance.playerData.mediumGameLeft--;
            SaveLoadData.instance.playerData.mediumGameWon++;
            SaveLoadData.instance.playerData.mediumGamePlayed++;
            SaveLoadData.instance.playerData.mediumWinRate = ((float)SaveLoadData.instance.playerData.mediumGameWon / (float)SaveLoadData.instance.playerData.mediumGamePlayed) * 100;
            SaveLoadData.instance.playerData.mediumBestTime = time;
        }
        else if (Level.text == "Hard")
        {
            SaveLoadData.instance.playerData.hardScore += score;
            SaveLoadData.instance.playerData.hardTotalScore += finalScore;
            SaveLoadData.instance.playerData.hardGameLeft--;
            SaveLoadData.instance.playerData.hardGameWon++;
            SaveLoadData.instance.playerData.hardGamePlayed++;
            SaveLoadData.instance.playerData.hardWinRate = ((float)SaveLoadData.instance.playerData.hardGameWon / (float)SaveLoadData.instance.playerData.hardGamePlayed) * 100;
            SaveLoadData.instance.playerData.hardBestTime = time;
        }
        else if (Level.text == "Expert")
        {
            SaveLoadData.instance.playerData.expertScore += score;
            SaveLoadData.instance.playerData.expertTotalScore += finalScore;
            SaveLoadData.instance.playerData.expertGameLeft--;
            SaveLoadData.instance.playerData.expertGameWon++;
            SaveLoadData.instance.playerData.expertGamePlayed++;
            SaveLoadData.instance.playerData.expertWinRate = ((float)SaveLoadData.instance.playerData.expertGameWon / (float)SaveLoadData.instance.playerData.expertGamePlayed) * 100;
            SaveLoadData.instance.playerData.expertBestTime = time;
        }
        else if (Level.text == "Giant")
        {
            SaveLoadData.instance.playerData.giantScore += score;
            SaveLoadData.instance.playerData.giantTotalScore += finalScore;
            SaveLoadData.instance.playerData.giantGameLeft--;
            SaveLoadData.instance.playerData.giantGameWon++;
            SaveLoadData.instance.playerData.giantGamePlayed++;
            SaveLoadData.instance.playerData.giantWinRate = ((float)SaveLoadData.instance.playerData.giantGameWon / (float)SaveLoadData.instance.playerData.giantGamePlayed) * 100;
            SaveLoadData.instance.playerData.giantBestTime = time;
        }

        SaveLoadData.instance.playerData.continueGame = "false";

        SaveLoadData.instance.SavingData();
    }

    public void PauseGame()
    {
        SaveLoadData.instance.playerData.tilesColor.Clear();

        for (int i = 0; i < puzzleGenerator.generatedPuzzle.Count; i++)
        {
            SaveLoadData.instance.playerData.tilesColor.Add(puzzleGenerator.generatedPuzzle[i].GetComponent<TilesColor>().colorID);
        }

        SaveLoadData.instance.playerData.continueGame = "true";
        SaveLoadData.instance.SavingData();


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
        string difficulty = gameManager.difficulty.text;

        if (difficulty == "Easy")
        {
            
            if (SaveLoadData.instance.playerData.eassyGameLeft > 0)
            {
                SaveLoadData.instance.playerData.eassyGameLeft--;
                SaveLoadData.instance.playerData.eassyGamePlayed++;
                SaveLoadData.instance.playerData.eassyWinRate = ((float)SaveLoadData.instance.playerData.eassyGameWon / (float)SaveLoadData.instance.playerData.eassyGamePlayed) * 100;

            }
            gameRemaining = SaveLoadData.instance.playerData.eassyGameLeft;

        }
        else if (difficulty == "Medium")
        {
            if (SaveLoadData.instance.playerData.mediumGameLeft > 0)
            {
                SaveLoadData.instance.playerData.mediumGameLeft--;
                SaveLoadData.instance.playerData.mediumGamePlayed++;
                SaveLoadData.instance.playerData.mediumWinRate = ((float)SaveLoadData.instance.playerData.eassyGameWon / (float)SaveLoadData.instance.playerData.eassyGamePlayed) * 100;

            }
            gameRemaining = SaveLoadData.instance.playerData.mediumGameLeft;

        }
        else if (difficulty == "Hard")
        {
            if (SaveLoadData.instance.playerData.hardGameLeft > 0)
            {
                SaveLoadData.instance.playerData.hardGameLeft--;
                SaveLoadData.instance.playerData.hardGamePlayed++;
                SaveLoadData.instance.playerData.hardWinRate = ((float)SaveLoadData.instance.playerData.eassyGameWon / (float)SaveLoadData.instance.playerData.eassyGamePlayed) * 100;

            }
            gameRemaining = SaveLoadData.instance.playerData.hardGameLeft;

        }
        else if (difficulty == "Expert")
        {
            if (SaveLoadData.instance.playerData.expertGameLeft > 0)
            {
                SaveLoadData.instance.playerData.expertGameLeft--;
                SaveLoadData.instance.playerData.expertGamePlayed++;
                SaveLoadData.instance.playerData.expertWinRate = ((float)SaveLoadData.instance.playerData.eassyGameWon / (float)SaveLoadData.instance.playerData.eassyGamePlayed) * 100;

            }
            gameRemaining = SaveLoadData.instance.playerData.expertGameLeft;

        }
        else if (difficulty == "Giant")
        {
            if(SaveLoadData.instance.playerData.giantGameLeft > 0)
            {
                SaveLoadData.instance.playerData.giantGameLeft--;
                SaveLoadData.instance.playerData.giantGamePlayed++;
                SaveLoadData.instance.playerData.giantWinRate = ((float)SaveLoadData.instance.playerData.eassyGameWon / (float)SaveLoadData.instance.playerData.eassyGamePlayed) * 100;

            }
            gameRemaining = SaveLoadData.instance.playerData.giantGameLeft;
            
        }
        
        levelDisplay.text = "Level " + difficulty + " you have " + gameRemaining + " for today.";
        SaveLoadData.instance.SavingData();
        SaveLoadData.instance.OpenData();
    }


}
