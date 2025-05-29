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

    private void Start()
    {
        if(playerInfo == null)
        playerInfo = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<PlayerInfo>();
    }

    public void UpgradeForce(float amountToUpgrade)
    {
        if(playerInfo.goldAmount >= costToUpgradeForce)
        {
            CostToUpgrade(costToUpgradeForce);
            playerInfo.strengthLevel += 1;
            PlayerPrefs.SetFloat("strengthLevel", PlayerPrefs.GetFloat("strengthLevel") + amountToUpgrade);
            ChangeForceLevelText();

        }
        SaveManager.instance.SavePlayerData();
    }
    public void UpgradeAccuracy(float amountToUpgrade)
    {
        if (playerInfo.goldAmount >= costToUpgradeAccuracy)
        {
            CostToUpgrade(costToUpgradeAccuracy);
            playerInfo.accuracyLevel += 1;
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
            playerInfo.shieldLevel += 1;
            //PlayerPrefs.SetFloat("strengthLevel", PlayerPrefs.GetFloat("strengthLevel") + amountToUpgrade);
            ChangeShieldLevelText();

        }
        SaveManager.instance.SavePlayerData();
    }

    public void CostToUpgrade(int cost)
    {
        playerInfo.ChangeGoldAmount(cost);
    }

    private void ChangeForceLevelText()
    {
        forceLevelText.text = "Level: " + playerInfo.strengthLevel;
    }
    private void ChangeAccuracyLevelText()
    {
        accuracyLevelText.text = "Level: " + playerInfo.accuracyLevel;
    }
    private void ChangeShieldLevelText()
    {
        shieldLevelText.text = "Level: " + playerInfo.shieldLevel;
    }
}
