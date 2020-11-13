using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeManager : MonoBehaviour
{
    public Text challengeDisplay;
    public Text rewardDisplay;
    public Text statusDisplay;
    public GameObject challengeComplete;
    private int challengeID;
    private int ChallengeElementArrayID;
    public ChallengeData[] gameChallenge;

    public static ChallengeManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        challengeID = SaveLoadData.instance.playerData.challengeID;
        ChallengeElementArrayID = challengeID-1;
        Debug.Log("current challenge array: " + ChallengeElementArrayID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowChallenge()
    {
       
        challengeID = SaveLoadData.instance.playerData.challengeID;
        
        
        for (int i = 0; i < gameChallenge.Length; i++)
        {
            if(challengeID == gameChallenge[i].challengeID)
            {
                challengeDisplay.text = gameChallenge[i].challenge;
                rewardDisplay.text = gameChallenge[i].reward;
                if(challengeID < 42)
                {
                    statusDisplay.text = "Not Completed";
                    statusDisplay.color = Color.red;
                }
                
                break;
            }
        }

    }

    public void CheckChallange()
    {
        

        if (challengeID == 1)
        {
            Challenge1();
        }
        else if (challengeID == 2)
        {
            Challenge2();
        }
        else if (challengeID == 3)
        {
            Challenge3();
        }
        else if (challengeID == 4)
        {
            Challenge4();
        }
        else if (challengeID == 5)
        {
            Challenge5();
        }
        else if (challengeID == 6)
        {
            Challenge6();
        }
        else if (challengeID == 7)
        {
            Challenge7();
        }
        else if (challengeID == 8)
        {
            Challenge8();
        }
        else if (challengeID == 9)
        {
            Challenge9();
        }
        else if (challengeID == 10)
        {
            Challenge10();
        }
        else if (challengeID == 11)
        {
            Challenge11();
        }
        else if (challengeID == 12)
        {
            Challenge12();
        }
        else if (challengeID == 13)
        {
            Challenge13();
        }
        else if (challengeID == 14)
        {
            Challenge14();
        }
        else if (challengeID == 15)
        {
            Challenge15();
        }
        else if (challengeID == 16)
        {
            Challenge16();
        }
        else if (challengeID == 17)
        {
            Challenge17();
        }
        else if (challengeID == 18)
        {
            Challenge18();
        }
        else if (challengeID == 19)
        {
            Challenge19();
        }
        else if (challengeID == 20)
        {
            Challenge20();
        }
        else if (challengeID == 21)
        {
            Challenge21();
        }
        else if (challengeID == 22)
        {
            Challenge22();
        }
        else if (challengeID == 23)
        {
            Challenge23();
        }
        else if (challengeID == 24)
        {
            Challenge24();
        }
        else if (challengeID == 25)
        {
            Challenge25();
        }
        else if (challengeID == 26)
        {
            Challenge26();
        }
        else if (challengeID == 27)
        {
            Challenge27();
        }
        else if (challengeID == 28)
        {
            Challenge28();
        }
        else if (challengeID == 29)
        {
            Challenge29();
        }
        else if (challengeID == 30)
        {
            Challenge30();
        }
        else if (challengeID == 31)
        {
            Challenge31();
        }
        else if (challengeID == 32)
        {
            Challenge32();
        }
        else if (challengeID == 33)
        {
            Challenge33();
        }
        else if (challengeID == 34)
        {
            Challenge34();
        }
        else if (challengeID == 35)
        {
            Challenge35();
        }
        else if (challengeID == 36)
        {
            Challenge36();
        }
        else if (challengeID == 37)
        {
            Challenge37();
        }
        else if (challengeID == 38)
        {
            Challenge38();
        }
        else if (challengeID == 39)
        {
            Challenge39();
        }
        else if (challengeID == 40)
        {
            Challenge40();
        }
        else if (challengeID == 41)
        {
            Challenge41();
        }
       
    }

    void Challenge1()
    {
        int a = SaveLoadData.instance.playerData.eassyGamePlayed;

        if( a >= 3)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;
            
        }
    }

    void Challenge2()
    {
        int a = SaveLoadData.instance.playerData.mediumGamePlayed;

        if (a >= 3)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTurn++;

        }
    }

    void Challenge3()
    {
        int a = SaveLoadData.instance.playerData.flipHorizontal;

        if (a >= 1)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.exploder++;

        }
    }

    void Challenge4()
    {
        int a = SaveLoadData.instance.playerData.flipVertical;

        if (a >= 1)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;

        }
    }

    void Challenge5()
    {
        int a = SaveLoadData.instance.playerData.flipColor;

        if (a >= 1)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTurn++;

        }
    }


    void Challenge6()
    {
        int a = SaveLoadData.instance.playerData.infiniteTimerUsed;

        if (a >= 1)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;

        }
    }

    void Challenge7()
    {
        int a = SaveLoadData.instance.playerData.infinityTurn;

        if (a >= 1)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTurn++;

        }
    }

    void Challenge8()
    {
        int a = SaveLoadData.instance.playerData.exploderUsed;

        if (a >= 1)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.exploder++;

        }
    }

    void Challenge9()
    {
        int a = SaveLoadData.instance.playerData.hardCurrentStreak;

        if (a >= 5)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;

        }
    }

    void Challenge10()
    {
        int a = SaveLoadData.instance.playerData.expertCurrentStreak;

        if (a >= 5)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTurn++;

        }
    }

    void Challenge11()
    {
        string shape = PlayerPrefs.GetString("shape");

        if (shape == "circle")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.exploder++;

        }
    }

    void Challenge12()
    {
        string shape = PlayerPrefs.GetString("shape");

        if (shape == "square")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;

        }
    }

    void Challenge13()
    {
        string b = PlayerPrefs.GetString("LightColor");
        string c = PlayerPrefs.GetString("DarkColor");

        if (b == "white" && c == "redD")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTurn++;

        }
    }

    void Challenge14()
    {
        string b = PlayerPrefs.GetString("LightColor");
        string c = PlayerPrefs.GetString("DarkColor");

        if (b == "redL" && c == "black")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;

        }
    }

    void Challenge15()
    {
        float a = GamesManager.instance.finnishTime;
        string difficulty = GamesManager.instance.difficulty.text;

        if (a <= 30 && difficulty == "Easy")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTurn++;

        }
    }

    void Challenge16()
    {
        float a = GamesManager.instance.finnishTime;
        string difficulty = GamesManager.instance.difficulty.text;

        if (a <= 30 && difficulty == "Medium")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.exploder++;

        }
    }

    void Challenge17()
    {
        
        string difficulty = GamesManager.instance.difficulty.text;

        if (difficulty == "Hard")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;

        }
    }

    void Challenge18()
    {
        string difficulty = GamesManager.instance.difficulty.text;

        if (difficulty == "Expert")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTurn++;

        }
    }

    void Challenge19()
    {
        string difficulty = GamesManager.instance.difficulty.text;

        if (difficulty == "Giant")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.exploder++;

        }
    }

    void Challenge20()
    {
        string difficulty = GamesManager.instance.difficulty.text;
        int a = GamesManager.instance.undoAmount;

        if (a == 0 && difficulty == "Hard")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;

        }
    }

    void Challenge21()
    {
        string difficulty = GamesManager.instance.difficulty.text;
        int a = GamesManager.instance.undoAmount;

        if (a == 0 && difficulty == "Expert")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTurn++;

        }
    }

    void Challenge22()
    {
        
        int a = SaveLoadData.instance.playerData.hardGamePlayed;

        if (a >= 10)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;

        }
    }

    void Challenge23()
    {
        int a = SaveLoadData.instance.playerData.expertGamePlayed;

        if (a >= 10)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTurn++;

        }
    }

    void Challenge24()
    {
        int a = SaveLoadData.instance.playerData.giantGamePlayed;

        if (a >= 5)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.exploder++;

        }
    }

    void Challenge25()
    {
        int a = SaveLoadData.instance.playerData.hardCurrentStreak;

        if (a >= 5)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;

        }
    }

    void Challenge26()
    {
        int a = SaveLoadData.instance.playerData.expertCurrentStreak;

        if (a >= 5)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTurn++;

        }
    }

    void Challenge27()
    {
        int a = SaveLoadData.instance.playerData.giantCurrentStreak;

        if (a >= 5)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.exploder++;

        }
    }

    void Challenge28()
    {
        int a = SaveLoadData.instance.playerData.eassyGamePlayed;

        if (a >= 30)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;

        }
    }

    void Challenge29()
    {
        int a = SaveLoadData.instance.playerData.mediumGamePlayed;

        if (a >= 30)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTurn++;

        }
    }

    void Challenge30()
    {
        int a = SaveLoadData.instance.playerData.hardGamePlayed;

        if (a >= 30)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;

        }
    }

    void Challenge31()
    {
        int a = SaveLoadData.instance.playerData.expertGamePlayed;

        if (a >= 30)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTurn++;

        }
    }

    void Challenge32()
    {
        int a = SaveLoadData.instance.playerData.giantGamePlayed;

        if (a >= 30)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.exploder++;

        }
    }

    void Challenge33()
    {
        int a = SaveLoadData.instance.playerData.hardCurrentStreak;

        if (a >= 10)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;

        }
    }

    void Challenge34()
    {
        int a = SaveLoadData.instance.playerData.expertCurrentStreak;

        if (a >= 10)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTurn++;

        }
    }

    void Challenge35()
    {
        int a = SaveLoadData.instance.playerData.giantCurrentStreak;

        if (a >= 10)
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.exploder++;

        }
    }

    void Challenge36()
    {
        float a = GamesManager.instance.finnishTime;
        string difficulty = GamesManager.instance.difficulty.text;

        if (a <= 30 && difficulty == "Hard")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;

        }
    }

    void Challenge37()
    {
        float a = GamesManager.instance.finnishTime;
        string difficulty = GamesManager.instance.difficulty.text;

        if (a <= 30 && difficulty == "Expert")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTurn++;

        }
    }

    void Challenge38()
    {
        float a = GamesManager.instance.finnishTime;
        string difficulty = GamesManager.instance.difficulty.text;

        if (a <= 30 && difficulty == "Giant")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;

        }
    }

    void Challenge39()
    {
        float a = GamesManager.instance.finnishTime;
        string difficulty = GamesManager.instance.difficulty.text;

        if (a <= 20 && difficulty == "Hard")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTurn++;

        }
    }

    void Challenge40()
    {
        float a = GamesManager.instance.finnishTime;
        string difficulty = GamesManager.instance.difficulty.text;

        if (a <= 20 && difficulty == "Expert")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.exploder++;

        }
    }

    void Challenge41()
    {
        float a = GamesManager.instance.finnishTime;
        string difficulty = GamesManager.instance.difficulty.text;

        if (a <= 20 && difficulty == "Giant")
        {
            challengeComplete.SetActive(true);
            challengeDisplay.text = gameChallenge[ChallengeElementArrayID].challenge;
            SaveLoadData.instance.playerData.challengeID++;
            SaveLoadData.instance.playerData.infinityTimer++;

        }
    }
}
