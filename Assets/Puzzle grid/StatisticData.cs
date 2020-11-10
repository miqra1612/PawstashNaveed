using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatisticData : MonoBehaviour
{
    [Header("This part for Eassy panel UI")]
    public Text eassyScoreValue;
    public Text eassyGamePlayedValue;
    public Text eassyGameWonValue;
    public Text eassyWinRateValue;
    public Text eassyBestTimeValue;
    public Text eassyAverageTimeValue;
    public Text eassyCurrentStreakValue;
    public Text eassyBestWinStreakValue;

    [Header("This part for Medium panel UI")]
    public Text mediumScoreValue;
    public Text mediumGamePlayedValue;
    public Text mediumGameWonValue;
    public Text mediumWinRateValue;
    public Text mediumBestTimeValue;
    public Text mediumAverageTimeValue;
    public Text mediumCurrentStreakValue;
    public Text mediumBestWinStreakValue;

    [Header("This part for Hard panel UI")]
    public Text hardScoreValue;
    public Text hardGamePlayedValue;
    public Text hardGameWonValue;
    public Text hardWinRateValue;
    public Text hardBestTimeValue;
    public Text hardAverageTimeValue;
    public Text hardCurrentStreakValue;
    public Text hardBestWinStreakValue;

    [Header("This part for Expert panel UI")]
    public Text expertScoreValue;
    public Text expertGamePlayedValue;
    public Text expertGameWonValue;
    public Text expertWinRateValue;
    public Text expertBestTimeValue;
    public Text expertAverageTimeValue;
    public Text expertCurrentStreakValue;
    public Text expertBestWinStreakValue;

    [Header("This part for Giant panel UI")]
    public Text giantScoreValue;
    public Text giantGamePlayedValue;
    public Text giantGameWonValue;
    public Text giantWinRateValue;
    public Text giantBestTimeValue;
    public Text giantAverageTimeValue;
    public Text giantCurrentStreakValue;
    public Text giantBestWinStreakValue;

    // Start is called before the first frame update
    void Start()
    {
        ShowEassyData();
        ShowMediumData();
        ShowHardData();
        ShowExpertData();
        ShowGiantData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowEassyData()
    {
        eassyScoreValue.text = SaveLoadData.instance.playerData.eassyScore.ToString();
        eassyGamePlayedValue.text = SaveLoadData.instance.playerData.eassyGamePlayed.ToString();
        eassyGameWonValue.text = SaveLoadData.instance.playerData.eassyGameWon.ToString();
        eassyWinRateValue.text = SaveLoadData.instance.playerData.eassyWinRate.ToString() + "%";
        eassyBestTimeValue.text = SaveLoadData.instance.playerData.eassyBestTime.ToString();
        eassyAverageTimeValue.text = SaveLoadData.instance.playerData.eassyAverageTime.ToString();
        eassyCurrentStreakValue.text = SaveLoadData.instance.playerData.eassyCurrentStreak.ToString();
        eassyBestWinStreakValue.text = SaveLoadData.instance.playerData.eassyBestWinStreak.ToString();
    }

    void ShowMediumData()
    {
        mediumScoreValue.text = SaveLoadData.instance.playerData.mediumScore.ToString();
        mediumGamePlayedValue.text = SaveLoadData.instance.playerData.mediumGamePlayed.ToString();
        mediumGameWonValue.text = SaveLoadData.instance.playerData.mediumGameWon.ToString();
        mediumWinRateValue.text = SaveLoadData.instance.playerData.mediumWinRate.ToString() + "%";
        mediumBestTimeValue.text = SaveLoadData.instance.playerData.mediumBestTime.ToString();
        mediumAverageTimeValue.text = SaveLoadData.instance.playerData.mediumAverageTime.ToString();
        mediumCurrentStreakValue.text = SaveLoadData.instance.playerData.mediumCurrentStreak.ToString();
        mediumBestWinStreakValue.text = SaveLoadData.instance.playerData.mediumBestWinStreak.ToString();
    }

    void ShowHardData()
    {
        hardScoreValue.text = SaveLoadData.instance.playerData.hardScore.ToString();
        hardGamePlayedValue.text = SaveLoadData.instance.playerData.hardGamePlayed.ToString();
        hardGameWonValue.text = SaveLoadData.instance.playerData.hardGameWon.ToString();
        hardWinRateValue.text = SaveLoadData.instance.playerData.hardWinRate.ToString() + "%";
        hardBestTimeValue.text = SaveLoadData.instance.playerData.hardBestTime.ToString();
        hardAverageTimeValue.text = SaveLoadData.instance.playerData.hardAverageTime.ToString();
        hardCurrentStreakValue.text = SaveLoadData.instance.playerData.hardCurrentStreak.ToString();
        hardBestWinStreakValue.text = SaveLoadData.instance.playerData.hardBestWinStreak.ToString();
    }

    void ShowExpertData()
    {
        expertScoreValue.text = SaveLoadData.instance.playerData.expertScore.ToString();
        expertGamePlayedValue.text = SaveLoadData.instance.playerData.expertGamePlayed.ToString();
        expertGameWonValue.text = SaveLoadData.instance.playerData.expertGameWon.ToString(); 
        expertWinRateValue.text = SaveLoadData.instance.playerData.expertWinRate.ToString() + "%";
        expertBestTimeValue.text = SaveLoadData.instance.playerData.expertBestTime.ToString();
        expertAverageTimeValue.text = SaveLoadData.instance.playerData.expertAverageTime.ToString();
        expertCurrentStreakValue.text = SaveLoadData.instance.playerData.expertCurrentStreak.ToString();
        expertBestWinStreakValue.text = SaveLoadData.instance.playerData.expertBestWinStreak.ToString();
    }

    void ShowGiantData()
    {
        giantScoreValue.text = SaveLoadData.instance.playerData.giantScore.ToString();
        giantGamePlayedValue.text = SaveLoadData.instance.playerData.giantGamePlayed.ToString();
        giantGameWonValue.text = SaveLoadData.instance.playerData.giantGameWon.ToString();
        giantWinRateValue.text = SaveLoadData.instance.playerData.giantWinRate.ToString() + "%";
        giantBestTimeValue.text = SaveLoadData.instance.playerData.giantBestTime.ToString();
        giantAverageTimeValue.text = SaveLoadData.instance.playerData.giantAverageTime.ToString();
        giantCurrentStreakValue.text = SaveLoadData.instance.playerData.giantCurrentStreak.ToString();
        giantBestWinStreakValue.text = SaveLoadData.instance.playerData.giantBestWinStreak.ToString();
    }
}
