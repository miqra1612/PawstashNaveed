using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeEffect : MonoBehaviour
{
    public Image challengeIcon;
    public GameObject particleEffect;
    public Sprite[] lockSprite;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EffectSequence());
    }

    IEnumerator EffectSequence()
    {
        yield return new WaitForSeconds(0.5f);
        challengeIcon.sprite = lockSprite[1];
        particleEffect.SetActive(true);
    }
}
