using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void ChangeScene(string sceneName)
    {
        
        if(SceneManager.GetActiveScene().name != "Menu")
        {
            StartCoroutine(ChangeTheScene(sceneName));
        }
        else
        {
            StartCoroutine(CheckingMove(sceneName));
        }

    }

    public void ReloadLevel()
    {
        AdsManager.instance.HideBanner();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenAddsBeforePlayGameAgain()
    {
        SaveLoadData.instance.SavingData();
        AdsManager.instance.HideBanner();
        AdsManager.instance.ShowInterstitialAds();
    }

    IEnumerator CheckingMove(string sceneName)
    {
        yield return new WaitForSeconds(0.2f);

        int size = PlayerPrefs.GetInt("size");
        int puzzle = 0;

        if( size == 4)
        {
            puzzle = SaveLoadData.instance.playerData.eassyGameLeft;
        }
        else if (size == 5)
        {
            puzzle = SaveLoadData.instance.playerData.mediumGameLeft;
        }
        else if (size == 6)
        {
            puzzle = SaveLoadData.instance.playerData.hardGameLeft;
        }
        else if (size == 7)
        {
            puzzle = SaveLoadData.instance.playerData.expertGameLeft;
        }
        else if (size == 8)
        {
            puzzle = SaveLoadData.instance.playerData.giantGameLeft;
        }

        string a = SaveLoadData.instance.playerData.infinitePuzzle;

        if(puzzle < 1  && a == "false")
        {
            MenuUIController.instance.OpenPanel(7);
        }
        else
        {
            AdsManager.instance.HideBanner();
            SaveLoadData.instance.playerData.patternID = 0;
            SaveLoadData.instance.SavingData();
            SceneManager.LoadScene(sceneName);
        }
    }

    IEnumerator ChangeTheScene(string sceneName)
    {
        yield return new WaitForSeconds(0.2f);
        AdsManager.instance.HideBanner();
        SaveLoadData.instance.playerData.patternID = 0;
        SaveLoadData.instance.SavingData();
        SceneManager.LoadScene(sceneName);

    }
}
