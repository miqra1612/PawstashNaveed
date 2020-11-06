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

    public Text finnishTimeDisplay;
    public Text bestTimeDisplay;
    public Text scoreDisplay;
    public Text bestScoreDisplay;
    public Text Level;
    public Text Result;

    private GamesManager gameManager;

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
        Result.text = winningToday.ToString() + " wins today! it's" + winningToday.ToString() + " more than yesterday!";
    }
}
