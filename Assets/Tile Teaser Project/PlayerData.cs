using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    //this part for Eassy
    [Header("This part for Eassy")]
    public int eassyScore;
    public int eassyTotalScore;
    public int eassyGamePlayed;
    public int eassyGameWon;
    public float eassyWinRate;
    public float eassyBestTime;
    public float eassyAverageTime;
    public int eassyCurrentStreak;
    public int eassyBestWinStreak;
    public int eassyGameLeft;
    public int eassyBestMinute;

    //this part for medium
    [Header("This part for medium")]
    public int mediumScore;
    public int mediumTotalScore;
    public int mediumGamePlayed;
    public int mediumGameWon;
    public float mediumWinRate;
    public float mediumBestTime;
    public float mediumAverageTime;
    public int mediumCurrentStreak;
    public int mediumBestWinStreak;
    public int mediumGameLeft;
    public int mediumBestMinute;

    //this part for hard
    [Header("This part for hard")]
    public int hardScore;
    public int hardTotalScore;
    public int hardGamePlayed;
    public int hardGameWon;
    public float hardWinRate;
    public float hardBestTime;
    public float hardAverageTime;
    public int hardCurrentStreak;
    public int hardBestWinStreak;
    public int hardGameLeft;
    public int hardBestMinute;

    //this part for expert
    [Header("This part for expert")]
    public int expertScore;
    public int expertTotalScore;
    public int expertGamePlayed;
    public int expertGameWon;
    public float expertWinRate;
    public float expertBestTime;
    public float expertAverageTime;
    public int expertCurrentStreak;
    public int expertBestWinStreak;
    public int expertGameLeft;
    public int expertBestMinute;

    //this part for giant
    [Header("This part for giant")]
    public int giantScore;
    public int giantTotalScore;
    public int giantGamePlayed;
    public int giantGameWon;
    public float giantWinRate;
    public float giantBestTime;
    public float giantAverageTime;
    public int giantCurrentStreak;
    public int giantBestWinStreak;
    public int giantGameLeft;
    public int giantBestMinute;

    // this part for next puzzle
    [Header("This part for next puzzle")]
    public int patternID;
    public int challengeID;

    //this part for item
    [Header("This part for game item")]
    public int exploder;
    public int infinityTimer;
    public int infinityTurn;
    public string addFree;
    public string infinitePuzzle;
    public int solutions;

    [Header("This part for game item statistic")]
    public int flipColor;
    public int flipVertical;
    public int flipHorizontal;
    public int exploderUsed;
    public int infiniteTimerUsed;
    public int infiniteTurnUsed;
    public string gameStatus;
    

    //this part for continue game
    [Header("This part for Continue Game")]
    public float timeLeft;
    public int turnLeft;
    public int puzzleSize;
    public string continueGame;
    public string date;
    public float seconds;
    public int minutes;
    public int turn;
    public string useInfiniteTimer = "false";
    public string useInfiniteTurn = "false";
    public List<string> tilesColor;
    public List<int> preclicksID;
    public List<string> tilesBeginingColor;

    [Header("This part for Purchase Data")]
    public string infinitePuzzlePurchaseID;
    public string infinitePuzzlePurchaseDate;
    public string adsFreePurchaseID;
    public string adsFreePurchaseDate;

}
