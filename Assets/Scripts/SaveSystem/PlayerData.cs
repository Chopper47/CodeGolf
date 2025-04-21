using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int goldAmount;
    public int gemAmount;

    public int strengthLevel;
    public int accuracyLevel;
    public int shieldLevel;

    public int levelsCompleted;

    public PlayerData(PlayerInfo player)
    {
        goldAmount = player.goldAmount;
        gemAmount = player.gemAmount;

        strengthLevel = player.strengthLevel;
        accuracyLevel = player.accuracyLevel;
        shieldLevel = player.shieldLevel;

        levelsCompleted = player.levelsCompleted;
    }
}
