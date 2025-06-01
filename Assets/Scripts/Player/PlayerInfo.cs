using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
        GameObject.FindGameObjectWithTag("GoldText").GetComponent<TextMeshProUGUI>().text = goldAmount.ToString();
    }
    
    public void SetGoldAmount(int amountToSet)
    {
        goldAmount = amountToSet;
        GameObject.FindGameObjectWithTag("GoldText").GetComponent<TextMeshProUGUI>().text = goldAmount.ToString();
    }

    //public void ChangeGemAmount(int amountToReduce)
    //{
    //    gemAmount -= amountToReduce;
    //    gemAmountText.text = gemAmount.ToString();
    //}

    //public void SetGemAmount(int amountToSet)
    //{
    //    gemAmount = amountToSet;
    //    gemAmountText.text = gemAmount.ToString();
    //}

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

                if(i == levelsCompleted)
                {
                    levelController.levelsButtonsArray[i].GetComponent<Image>().color = new Color(1f, 0.45f, 0.45f, 1f);
                }
                else
                {
                    levelController.levelsButtonsArray[i].GetComponent<Image>().color = new Color(0.45f, 0.76f, 1f, 1f);
                }
            }

        }

    }
}
