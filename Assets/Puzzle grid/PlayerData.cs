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

    // this part for next puzzle
    [Header("This part for next puzzle")]
    public int patternID;

    //this part for item
    [Header("This part for game item")]
    public int exploder;
    public int infinityTimer;
    public int infinityTurn;
    public string addFree;
    public int infinitePuzzle;
    public int solutions;

    //this part for continue game
    [Header("This part for Continue Game")]
    public float timeLeft;
    public int turnLeft;
    public int puzzleSize;
    public string continueGame;
    public string date;
    public List<string> tilesColor;


}
