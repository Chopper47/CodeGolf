using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInfo))]
public class UpgradeStats : MonoBehaviour
{
    PlayerInfo playerInfo;

    private void Awake()
    {
        playerInfo = gameObject.GetComponent<PlayerInfo>();
    }


    public void UpgradeForce(float amountToUpgrade)
    {
        PlayerPrefs.SetFloat("strengthLevel", PlayerPrefs.GetFloat("strengthLevel") + amountToUpgrade);
    }

    public void CostToUpgrade(int cost)
    {
        playerInfo.ChangeGoldAmount(cost);
    }
}
