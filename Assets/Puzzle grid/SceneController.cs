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
        AdsManager.instance.HideBanner();
        SaveLoadData.instance.playerData.patternID = 0;
        SaveLoadData.instance.SavingData();
        SceneManager.LoadScene(sceneName);
        
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
}
