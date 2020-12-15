using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadData : MonoBehaviour
{
    public PlayerData playerData;
    private string datapath;

    public static SaveLoadData instance;

    private void Awake()
    {
        instance = this;

        /*GameObject[] objs = GameObject.FindGameObjectsWithTag("playerData");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);*/

        if (Application.platform == RuntimePlatform.Android)
        {
            datapath = "\\playerData.json";
        }
        else if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            datapath = "/playerData.json";
        }

        int a = PlayerPrefs.GetInt("justInstal");
        if (a > 0)
        {
            OpenData();
        }
    }

    private void Start()
    {
       
    }

    public void SavingData()
    {
        string datas = JsonUtility.ToJson(playerData,true);

        File.WriteAllText(Application.persistentDataPath + datapath, datas);
    }

    public void OpenData()
    {
        if(File.Exists(Application.persistentDataPath + datapath))
        {
            string datas = File.ReadAllText(Application.persistentDataPath + datapath);

            playerData = JsonUtility.FromJson<PlayerData>(datas);
        }
    }
}
