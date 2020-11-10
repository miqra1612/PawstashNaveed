using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;

public class AdsManager : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;
    public static AdsManager instance;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("addManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        instance = this;
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
            string bannerTestUnitId = "ca-app-pub-3940256099942544/6300978111";
            string yourAndroidBannerAdID = "put your true add ID here ( don't use your add id for test, only for rellease)";


        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
            string yourIphoneBannerAdID = "put your true add ID here ( don't use your add id for test, only for rellease)";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(bannerTestUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    public void RequestInterstitial()
    {
    #if UNITY_ANDROID
        string adTestUnitId = "ca-app-pub-3940256099942544/1033173712";
        string yourAndroidInsterstitialAdID = "put your true add ID here ( don't use your add id for test, only for rellease)";
    #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        string yourIphoneBannerAdID = "put your true add ID here ( don't use your add id for test, only for rellease)";
    #else
         string adUnitId = "unexpected_platform";
    #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adTestUnitId);
        
        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    private void HandleOnAdLeavingApplication(object sender, EventArgs e)
    {
        SettingManager.sg.DebugText("leaving apps");
    }

    private void HandleOnAdClosed(object sender, EventArgs e)
    {
        SettingManager.sg.DebugText("close ads");
        interstitial.Destroy();
        SceneController.instance.ReloadLevel();
    }

    private void HandleOnAdOpened(object sender, EventArgs e)
    {
        SettingManager.sg.DebugText("open ads");
    }

    private void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        SettingManager.sg.DebugText("fail to load");
    }

    private void HandleOnAdLoaded(object sender, EventArgs e)
    {
        SettingManager.sg.DebugText("ads loaded");
    }


    public void RequestRewardAds()
    {
        string rewardedUnitID = "ca-app-pub-3940256099942544/5224354917";

        this.rewardedAd = new RewardedAd(rewardedUnitID);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    private void HandleRewardedAdClosed(object sender, EventArgs e)
    {
        SettingManager.sg.DebugText("close ads");
    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {
        SettingManager.sg.DebugText("get reward");
    }

    private void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs e)
    {
        SettingManager.sg.DebugText("fail to show");
    }

    private void HandleRewardedAdOpening(object sender, EventArgs e)
    {
        SettingManager.sg.DebugText("open ads");
    }

    private void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs e)
    {
        SettingManager.sg.DebugText("fail to load");
    }

    private void HandleRewardedAdLoaded(object sender, EventArgs e)
    {
        SettingManager.sg.DebugText("ads loaded");
    }

    // Start is called before the first frame update


    void Start()
    {
        DontDestroyOnLoad(gameObject);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideBanner()
    {
        
        bannerView.Hide();
    }

    public void ShowBannerAgain()
    {
        RequestBanner();
        bannerView.Show();
        RequestInterstitial();
        RequestRewardAds();
    }

    public void ShowInterstitialAds()
    {
        
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    public void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }
}
