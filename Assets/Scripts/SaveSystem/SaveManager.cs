using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public PlayerInfo player;
    public void SavePlayerData()
    {
        SaveSystem.SaveData(player);
    }

    public void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        player.SetGoldAmount(data.goldAmount);
        player.SetGemAmount(data.gemAmount);

        player.strengthLevel = data.strengthLevel;
        player.accuracyLevel = data.accuracyLevel;
        player.shieldLevel = data.shieldLevel;

        player.levelsCompleted = data.levelsCompleted;


        
    }
}
