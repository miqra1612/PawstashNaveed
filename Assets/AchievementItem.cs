using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : MonoBehaviour
{
    public string achievement;
    public Text achievementDisplay;

    // Start is called before the first frame update
    public void ShowAchievement()
    {
        achievementDisplay.text = achievement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
