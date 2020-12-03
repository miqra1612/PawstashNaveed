using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    private float time = 999;
    private int minute = 60;
    public int turn = 999;
    public int score = 0;
    public int todaysTurn = 20;
    public int winningToday = 0;

    [Header("This part for Game panel UI")]
    public GameObject topPanel;
    public GameObject bottomPanel;
    public GameObject bottomReplayPanel;
    public Button infiniteTurnButton;
    public Button infiniteTimeButton;
    public Button exploderButton;


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
    public Text Solution;
    private int solutionNum = 0;
    private int gameRemaining = 4;

    private string vibration;
    private GamesManager gameManager;
    private AdsManager adsView;
    private PuzzleGenerator puzzleGenerator;

    public static GameUIController instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GamesManager>();
        puzzleGenerator = GameObject.FindGameObjectWithTag("manager").GetComponent<PuzzleGenerator>();
        solutionNum = SaveLoadData.instance.playerData.solutions;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowWinningResult(int finalScore,int todayWin)
    {
        time = gameManager.finnishTime;
        Debug.Log("time: " + time);
        
        minute = gameManager.finnishMinute;
        Debug.Log("minute: " + minute);

        score += finalScore;
        winningToday += todayWin;

        scoreDisplay.text = score.ToString();
        bestScoreDisplay.text = score.ToString();

        finnishTimeDisplay.text = minute.ToString("00") + ":" + time.ToString("00");
        bestTimeDisplay.text = minute.ToString("00") + ":" + time.ToString("00");

        Level.text = gameManager.difficulty.text;
        Result.text = winningToday.ToString() + " wins today! it's " + winningToday.ToString() + " more than yesterday!";

        
        AdsManager.instance.HideBanner();
        

        if(Level.text == "Easy")
        {
            SaveLoadData.instance.playerData.eassyScore += score;
            SaveLoadData.instance.playerData.eassyTotalScore += finalScore;
            SaveLoadData.instance.playerData.eassyGameLeft--;
            SaveLoadData.instance.playerData.eassyGameWon++;
            SaveLoadData.instance.playerData.eassyGamePlayed++;
            SaveLoadData.instance.playerData.eassyWinRate = ((float)SaveLoadData.instance.playerData.eassyGameWon / (float)SaveLoadData.instance.playerData.eassyGamePlayed) * 100;
            SaveLoadData.instance.playerData.eassyBestTime = time;
            SaveLoadData.instance.playerData.eassyBestMinute = minute;



            if (SaveLoadData.instance.playerData.gameStatus == "win")
            {
                SaveLoadData.instance.playerData.eassyCurrentStreak++;
            }

            if (SaveLoadData.instance.playerData.eassyCurrentStreak > SaveLoadData.instance.playerData.eassyBestWinStreak)
            {
                SaveLoadData.instance.playerData.eassyBestWinStreak = SaveLoadData.instance.playerData.eassyCurrentStreak;
            }
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
            SaveLoadData.instance.playerData.mediumBestMinute = minute;

            if (SaveLoadData.instance.playerData.gameStatus == "win")
            {
                SaveLoadData.instance.playerData.mediumCurrentStreak++;
            }

            if (SaveLoadData.instance.playerData.mediumCurrentStreak > SaveLoadData.instance.playerData.mediumBestWinStreak)
            {
                SaveLoadData.instance.playerData.mediumBestWinStreak = SaveLoadData.instance.playerData.mediumCurrentStreak;
            }
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
            SaveLoadData.instance.playerData.hardBestMinute = minute;

            if (SaveLoadData.instance.playerData.gameStatus == "win")
            {
                SaveLoadData.instance.playerData.hardCurrentStreak++;
            }

            if (SaveLoadData.instance.playerData.hardCurrentStreak > SaveLoadData.instance.playerData.hardBestWinStreak)
            {
                SaveLoadData.instance.playerData.hardBestWinStreak = SaveLoadData.instance.playerData.hardCurrentStreak;
            }
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
            SaveLoadData.instance.playerData.expertBestMinute = minute;

            if (SaveLoadData.instance.playerData.gameStatus == "win")
            {
                SaveLoadData.instance.playerData.expertCurrentStreak++;
            }

            if (SaveLoadData.instance.playerData.expertCurrentStreak > SaveLoadData.instance.playerData.expertBestWinStreak)
            {
                SaveLoadData.instance.playerData.expertBestWinStreak = SaveLoadData.instance.playerData.expertCurrentStreak;
            }
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
            SaveLoadData.instance.playerData.giantBestMinute = minute;

            if (SaveLoadData.instance.playerData.gameStatus == "win")
            {
                SaveLoadData.instance.playerData.giantCurrentStreak++;
            }

            if(SaveLoadData.instance.playerData.giantCurrentStreak > SaveLoadData.instance.playerData.giantBestWinStreak)
            {
                SaveLoadData.instance.playerData.giantBestWinStreak = SaveLoadData.instance.playerData.giantCurrentStreak;
            }
           
        }

        SaveLoadData.instance.playerData.continueGame = "false";
        SaveLoadData.instance.playerData.gameStatus = "win";

        ChallengeManager.instance.CheckChallange();
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

    public void ExitPuzzleWithoutFinishing()
    {
        if(gameManager.isPlaying == true)
        {
            SaveLoadData.instance.playerData.tilesColor.Clear();

            for (int i = 0; i < puzzleGenerator.generatedPuzzle.Count; i++)
            {
                SaveLoadData.instance.playerData.tilesColor.Add(puzzleGenerator.generatedPuzzle[i].GetComponent<TilesColor>().colorID);
            }

            SaveLoadData.instance.playerData.continueGame = "true";
            SaveLoadData.instance.SavingData();

        }

    }

    public void GameOverInfo()
    {
        string difficulty = gameManager.difficulty.text;
        vibration = PlayerPrefs.GetString("vibrate");
        SaveLoadData.instance.playerData.gameStatus = "fail";
        Solution.text = "Solution: " + solutionNum.ToString();

        if (vibration == "true")
        {
            Handheld.Vibrate();
        }

        if (difficulty == "Easy")
        {
            
            if (SaveLoadData.instance.playerData.eassyGameLeft > 0)
            {
                SaveLoadData.instance.playerData.eassyGameLeft--;
                SaveLoadData.instance.playerData.eassyGamePlayed++;
               
                if(SaveLoadData.instance.playerData.eassyGameWon < 1)
                {
                    SaveLoadData.instance.playerData.eassyWinRate = 0;
                }
                else
                {
                    SaveLoadData.instance.playerData.eassyWinRate = ((float)SaveLoadData.instance.playerData.eassyGameWon / (float)SaveLoadData.instance.playerData.eassyGamePlayed) * 100;

                }

            }
            gameRemaining = SaveLoadData.instance.playerData.eassyGameLeft;

        }
        else if (difficulty == "Medium")
        {
            if (SaveLoadData.instance.playerData.mediumGameLeft > 0)
            {
                SaveLoadData.instance.playerData.mediumGameLeft--;
                SaveLoadData.instance.playerData.mediumGamePlayed++;
                
                if (SaveLoadData.instance.playerData.mediumGameWon < 1)
                {
                    SaveLoadData.instance.playerData.mediumWinRate = 0;
                }
                else
                {
                    SaveLoadData.instance.playerData.mediumWinRate = ((float)SaveLoadData.instance.playerData.mediumGameWon / (float)SaveLoadData.instance.playerData.mediumGamePlayed) * 100;

                }
            }
            gameRemaining = SaveLoadData.instance.playerData.mediumGameLeft;

        }
        else if (difficulty == "Hard")
        {
            if (SaveLoadData.instance.playerData.hardGameLeft > 0)
            {
                SaveLoadData.instance.playerData.hardGameLeft--;
                SaveLoadData.instance.playerData.hardGamePlayed++;
               
                if (SaveLoadData.instance.playerData.hardGameWon < 1)
                {
                    SaveLoadData.instance.playerData.hardWinRate = 0;
                }
                else
                {
                    SaveLoadData.instance.playerData.hardWinRate = ((float)SaveLoadData.instance.playerData.hardGameWon / (float)SaveLoadData.instance.playerData.hardGamePlayed) * 100;

                }
            }
            gameRemaining = SaveLoadData.instance.playerData.hardGameLeft;

        }
        else if (difficulty == "Expert")
        {
            if (SaveLoadData.instance.playerData.expertGameLeft > 0)
            {
                SaveLoadData.instance.playerData.expertGameLeft--;
                SaveLoadData.instance.playerData.expertGamePlayed++;
               
                if (SaveLoadData.instance.playerData.expertGameWon < 1)
                {
                    SaveLoadData.instance.playerData.expertWinRate = 0;
                }
                else
                {
                    SaveLoadData.instance.playerData.expertWinRate = ((float)SaveLoadData.instance.playerData.expertWinRate / (float)SaveLoadData.instance.playerData.expertGamePlayed) * 100;

                }
            }
            gameRemaining = SaveLoadData.instance.playerData.expertGameLeft;

        }
        else if (difficulty == "Giant")
        {
            if(SaveLoadData.instance.playerData.giantGameLeft > 0)
            {
                SaveLoadData.instance.playerData.giantGameLeft--;
                SaveLoadData.instance.playerData.giantGamePlayed++;
                
                if (SaveLoadData.instance.playerData.giantGameWon < 1)
                {
                    SaveLoadData.instance.playerData.giantWinRate = 0;
                }
                else
                {
                    SaveLoadData.instance.playerData.giantWinRate = ((float)SaveLoadData.instance.playerData.giantGameWon / (float)SaveLoadData.instance.playerData.giantGameWon) * 100;

                }
            }
            gameRemaining = SaveLoadData.instance.playerData.giantGameLeft;
            
        }
        
        levelDisplay.text = "Level " + difficulty + " you have " + gameRemaining + " for today.";
        SaveLoadData.instance.SavingData();
        SaveLoadData.instance.OpenData();
        AdsManager.instance.HideBanner();
    }
    
    public void GetSolution()
    {
        SaveLoadData.instance.playerData.solutions--;
        solutionNum = SaveLoadData.instance.playerData.solutions;
        Solution.text = "Solution: " + solutionNum.ToString();

    }

}
