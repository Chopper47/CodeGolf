using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStats : MonoBehaviour
{
    
    public void UpgradeForce(float amountToUpgrade)
    {
        PlayerPrefs.SetFloat("strengthLevel", PlayerPrefs.GetFloat("strengthLevel") + amountToUpgrade);
    }
}
