using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    public void ChangeGemAmount(int amountToReduce)
    {
        gemAmount -= amountToReduce;
        gemAmountText.text = gemAmount.ToString();
    }
}
