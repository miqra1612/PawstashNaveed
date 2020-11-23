using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class LogInManager : MonoBehaviour
{

    private int attemp = 0;
    public static LogInManager instance;

    // Start is called before the first frame update

    private void Awake()
    {
        PlayerPrefs.SetString("Login", "no");
        AuthenticateUser();
        instance = this;

    }

    void Start()
    {
        string status = PlayerPrefs.GetString("Login");
        if ( status != "yes")
        {
            GetSignIn();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RestartConnection()
    {

        //SignText.text = "Mencoba Kembali...";

        LogOut();
        //Dialogs[2].SetActive(true);
        yield return new WaitForSeconds(2);
        LogInUser();
    }

    /*
    IEnumerator GetStart()
    {
        yield return new WaitForSeconds(3);
        yield return null;
        Startgame.interactable = true;
        SignText.text = "Tap Untuk Memulai Permainan...";
        Dialogs[2].SetActive(false);
        Dialogs[0].SetActive(true);
        SoundManager.sm.PlayIntro();
        yield return new WaitForSeconds(1);
        Dialogs[0].SetActive(false);
        yield return new WaitForSeconds(1);
        Dialogs[1].SetActive(true);


    }
    */

    public void AuthenticateUser()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

    }

    public void GetSignIn()
    {
        if (attemp < 1)
        {

            LogInUser();
            attemp++;
        }
        else
        {
            LogOut();
            LogInUser();
            attemp++;
        }


    }

    public void LogInUser()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success == true)
            {
                PlayerPrefs.SetString("Login", "yes");
                //Dialogs[0].SetActive(false);
                //Dialogs[1].SetActive(true);
                //Dialogs[2].SetActive(false);
                
                //StartCoroutine(GetStart());
            }
            else
            {
                //Dialogs[0].SetActive(false);
                //Dialogs[1].SetActive(false);
                //Dialogs[2].SetActive(false);
                //SignText.text = "Gagal Terhubung Ke Google Play Service... \nTap untuk memulai Permainan...";
                //Startgame.interactable = true;
                PlayerPrefs.SetString("Login", "no");
                //ButtonReConnect.SetActive(true);
            }
        });
    }

    public static void LogOut()
    {
        if (PlayerPrefs.GetString("Login") == "yes")
        {
            PlayGamesPlatform.Instance.SignOut();
        }

    }

    public void Reconnect()
    {
        StopAllCoroutines();
        StartCoroutine(RestartConnection());
    }

    public static void PostToLeaderBoard(int NewScore)
    {
        /*
        Social.ReportScore(NewScore, GPGSIds.leaderboard_score_terbaik, (bool success) => {
            if (success)
            {
                Debug.Log("Sukses posting score");
                //Level1Manager.lv.debugMessage.text = "Sukses posting score";
            }
            else
            {
                Debug.Log("gagal posting score");
                //Level1Manager.lv.debugMessage.text = "gagal posting score";
            }
        });
        */
    }

    public static void ShowLeaderBoardUI()
    {
        //PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_score_terbaik);
    }

    // this part for achievement

    public void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100, success => { });
    }
    
}
