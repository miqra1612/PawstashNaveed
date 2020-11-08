using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIController : MonoBehaviour
{
    public GameObject[] panels;

    public GameObject[] statisticPanels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CloseAllPanels()
    {
        for(int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }

    }

    void CloseAllStatisticPanels()
    {
        for (int i = 0; i < statisticPanels.Length; i++)
        {
            statisticPanels[i].SetActive(false);
        }

    }

    public void OpenPanel(int i)
    {
        CloseAllPanels();

        panels[i].SetActive(true);
    }

    public void OpenStatisticPanel(int i)
    {
        CloseAllStatisticPanels();

        statisticPanels[i].SetActive(true);
    }
}
