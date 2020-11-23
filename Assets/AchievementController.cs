using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementController : MonoBehaviour
{
    public GameObject contentAchievement;
    public GameObject achievementItem;

    private ChallengeManager challengeManager;

    // Start is called before the first frame update
    void Start()
    {
        ShowAllAchievement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowAllAchievement()
    {
        challengeManager = GetComponent<ChallengeManager>();

        int id = SaveLoadData.instance.playerData.challengeID - 1;
        for (int i = 0; i < id; i++)
        {
            GameObject go = Instantiate(achievementItem, Vector3.one, Quaternion.identity);
            go.transform.SetParent(contentAchievement.transform);
            go.GetComponent<RectTransform>().localScale = Vector3.one;

            AchievementItem ci = go.GetComponent<AchievementItem>();
            ci.achievement = challengeManager.gameChallenge[i].challenge;
            ci.ShowAchievement();
        }
    }
}
