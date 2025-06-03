using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public PlayerInfo player;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        SavePlayerData();
        LoadPlayerData();
    }
    public void SavePlayerData()
    {
        SaveSystem.SaveData(player);
    }

    public void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Debug.Log("LOADING");
        player.SetGoldAmount(data.goldAmount);
        //player.SetGemAmount(data.gemAmount);

        player.strengthLevel = data.strengthLevel;
        player.accuracyLevel = data.accuracyLevel;
        player.shieldLevel = data.shieldLevel;

        player.levelsCompleted = data.levelsCompleted;

        player.SetLevelsCompleted();


        
    }
}
