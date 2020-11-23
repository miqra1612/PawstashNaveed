using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeItem : MonoBehaviour
{

    public string challenge;
    public string rewards;
    public string status;
    public bool isCompleted = false;

    public Text challengeDisplay;
    public Text rewardsDisplay;
    public Text statusDisplay;

    // Start is called before the first frame update
    public void ShowInfo()
    {
        challengeDisplay.text = challenge;
        rewardsDisplay.text = rewards;
        statusDisplay.text = status;
        
        if(statusDisplay.text == "Completed")
        {
            statusDisplay.color = Color.green;
        }
        else
        {
            statusDisplay.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
