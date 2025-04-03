using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStats : MonoBehaviour
{
    
    public void UpgradeForce(float amountToUpgrade)
    {
        PlayerPrefs.SetFloat("inputForce", PlayerPrefs.GetFloat("inputForce") + amountToUpgrade);
    }
}
