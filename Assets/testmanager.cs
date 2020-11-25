using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmanager : MonoBehaviour
{
    public int minutes = 1;
    public int time = 00;
    public int finnishTime = 0;
    public int finnishMinute = 0;

    private void Start()
    {
        //StartCoroutine(CekTimer());
        CekValue();
    }

    void CekValue()
    {
        int end = 4 * 1;
       int generatedpuzzle = 16;
        for(int i = 0; i < 4; i++)
        {
            int a = ((generatedpuzzle) - (end - i));
            Debug.Log("generated puzzle id: " + a);
        }
    }


    public void OpenAds()
    {
        AdsManager.instance.RequestBanner();
    }

    public void HiddingAds()
    {
        AdsManager.instance.HideBanner();
    }

    IEnumerator CekTimer()
    {
        int a = time;

        while (minutes >= 0 && a >= 0)
        {
            /*
            if (infiniteTimer == true)
            {
                time = 9999;
                timeDisplay.text = " ";
                infiniteIconTimer.SetActive(true);
            }
            else
            {*/
            time--;

                if (time < 0)
                {
                    minutes--;
                    time = 59;
                }

                if(minutes >= 0)
            {
                Debug.Log(minutes.ToString("00") + ":" + time.ToString("00"));
            }
               

                finnishTime++;

                if (finnishTime > 59)
                {
                    finnishTime = 0;
                    finnishMinute++;
                }
            //}

            yield return new WaitForSeconds(1);
        }

        if(minutes< 1)
        {
            Debug.Log("game over");
        }
    }
}
