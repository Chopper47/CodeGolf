using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(SaveManager))]
public class PlayerInfo : MonoBehaviour
{
    public int goldAmount;
    public int gemAmount;

    public int strengthLevel;
    public int accuracyLevel;
    public int shieldLevel;

    public int levelsCompleted;

    public TextMeshProUGUI goldAmountText;
    public TextMeshProUGUI gemAmountText;

    private void Awake()
    {
        goldAmountText.text = goldAmount.ToString();
        gemAmountText.text = gemAmount.ToString();
    }

    public void ChangeGoldAmount(int amountToReduce)
    {
        goldAmount -= amountToReduce;
        goldAmountText.text = goldAmount.ToString();
    }
    
    public void SetGoldAmount(int amountToSet)
    {
        goldAmount = amountToSet;
        goldAmountText.text = goldAmount.ToString();
    }

    public void ChangeGemAmount(int amountToReduce)
    {
        gemAmount -= amountToReduce;
        gemAmountText.text = gemAmount.ToString();
    }

    public void SetGemAmount(int amountToSet)
    {
        gemAmount = amountToSet;
        gemAmountText.text = gemAmount.ToString();
    }

    public void SetLevelsCompleted()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        foreach(GameObject button in levelController.levelsButtonsArray)
        {
            button.SetActive(false);
        }
        if(levelsCompleted > levelController.levelsButtonsArray.Length)
        {
            Debug.LogError("LEVELS COMPLETED HIGHER THAN CURRENT AMOUNT OF LEVELS");
        }
        else
        {
            for (int i = 0; i <= levelsCompleted; i++)
            {
                levelController.levelsButtonsArray[i].SetActive(true);
            }

        }

    }
}
