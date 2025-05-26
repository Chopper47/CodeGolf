using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HitCounter : MonoBehaviour
{
    public TextMeshProUGUI hitsShower;
    public TextMeshProUGUI endShower;
    int hits = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateShower();
    }

    public void Hit()
    {
        hits++;
        UpdateShower();
    }

    void UpdateShower()
    {
        hitsShower.text = "" + hits;
    }

    public void End()
    {
        hitsShower.gameObject.SetActive(false);
        endShower.gameObject.SetActive(true);
    }
}
