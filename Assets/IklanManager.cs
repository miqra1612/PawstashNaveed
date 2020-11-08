using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class IklanManager : MonoBehaviour
{
    private BannerView bannerView;
   
    private void RequestBanner()
    {
#if UNITY_ANDROID
        string bannerTestUnitId = "ca-app-pub-3940256099942544/6300978111";
        string intersitialTestUnitId = "ca-app-pub-3940256099942544/1033173712";


        string yourAdID = "put your true add ID here ( don't use your add id for test, only for rellease)";
#elif UNITY_IPHONE
      string adUnitId = "ca-app-pub-3940256099942544/2934735716";
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

    // Start is called before the first frame update
   

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        RequestBanner();
        bannerView.Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideBanner()
    {
        bannerView.Hide();
    }
}
