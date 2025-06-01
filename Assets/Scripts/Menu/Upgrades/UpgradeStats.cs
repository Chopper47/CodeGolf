using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UpgradeStats : MonoBehaviour
{
    [SerializeField]PlayerInfo playerInfo;

    [Header("Level Texts")]
    [SerializeField] TextMeshProUGUI forceLevelText;
    [SerializeField] TextMeshProUGUI accuracyLevelText;
    [SerializeField] TextMeshProUGUI shieldLevelText;

    [Header("Costs To Upgrade")]
    public int costToUpgradeForce ;
    public int costToUpgradeAccuracy;
    public int costToUpgradeShield;

    private void Awake()
    {
        
    }

    


    //All three methods upgrade a stat and save it in the player data

    public void UpgradeForce(float amountToUpgrade)
    {
        if(playerInfo.goldAmount >= costToUpgradeForce)
        {
            CostToUpgrade(costToUpgradeForce);
            GameObject.FindGameObjectWithTag("SaveManager").GetComponent<PlayerInfo>().strengthLevel += 1;
            //PlayerPrefs.SetFloat("strengthLevel", PlayerPrefs.GetFloat("strengthLevel") + amountToUpgrade);
            ChangeForceLevelText();

        }
        SaveManager.instance.SavePlayerData();
    }
    public void UpgradeAccuracy(float amountToUpgrade)
    {
        if (playerInfo.goldAmount >= costToUpgradeAccuracy)
        {
            CostToUpgrade(costToUpgradeAccuracy);
            GameObject.FindGameObjectWithTag("SaveManager").GetComponent<PlayerInfo>().accuracyLevel += 1;
            //PlayerPrefs.SetFloat("strengthLevel", PlayerPrefs.GetFloat("strengthLevel") + amountToUpgrade);
            ChangeAccuracyLevelText();

        }
        SaveManager.instance.SavePlayerData();
    }
    public void UpgradeShield(float amountToUpgrade)
    {
        if (playerInfo.goldAmount >= costToUpgradeShield)
        {
            CostToUpgrade(costToUpgradeShield);
            GameObject.FindGameObjectWithTag("SaveManager").GetComponent<PlayerInfo>().shieldLevel += 1;
            //PlayerPrefs.SetFloat("strengthLevel", PlayerPrefs.GetFloat("strengthLevel") + amountToUpgrade);
            ChangeShieldLevelText();

        }
        SaveManager.instance.SavePlayerData();
    }


    /// <summary>
    /// Take money to upgrade a stat
    /// </summary>
    /// <param name="cost"></param>
    public void CostToUpgrade(int cost)
    {
        GameObject.FindGameObjectWithTag("SaveManager").GetComponent<PlayerInfo>().ChangeGoldAmount(cost);
    }

    //Change the text that shows the level of each stat
    private void ChangeForceLevelText()
    {
        forceLevelText.text = "Level: " + GameObject.FindGameObjectWithTag("SaveManager").GetComponent<PlayerInfo>().strengthLevel;
    }
    private void ChangeAccuracyLevelText()
    {
        accuracyLevelText.text = "Level: " + GameObject.FindGameObjectWithTag("SaveManager").GetComponent<PlayerInfo>().accuracyLevel;
    }
    private void ChangeShieldLevelText()
    {
        shieldLevelText.text = "Level: " + GameObject.FindGameObjectWithTag("SaveManager").GetComponent<PlayerInfo>().shieldLevel;
    }
}
