using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmanager : MonoBehaviour
{
    
    public void OpenAds()
    {
        AdsManager.instance.RequestBanner();
    }

    public void HiddingAds()
    {
        AdsManager.instance.HideBanner();
    }
}
