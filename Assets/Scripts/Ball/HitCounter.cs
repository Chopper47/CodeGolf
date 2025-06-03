using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HitCounter : MonoBehaviour
{
    public TextMeshProUGUI hitsShower;
    public TextMeshProUGUI endShower;

    [SerializeField] private int level;
    [SerializeField] GameObject holeCanvas;
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

        holeCanvas.GetComponentInChildren<TextMeshProUGUI>().text = hits.ToString();
        holeCanvas.SetActive(true);

        //Stars based on number of hits
        GameObject firstStar = GameObject.FindGameObjectWithTag("1Star");
        GameObject secondStar = GameObject.FindGameObjectWithTag("2Star");
        GameObject thirdStar = GameObject.FindGameObjectWithTag("3Star");
        if(hits >= 5)
        {
            thirdStar.SetActive(false);

            if (hits >= 8)
            {
                secondStar.SetActive(false);
            }
        }

        //Gives money based on performance
        if (SaveManager.instance)
        {
            PlayerInfo playerInfo = SaveManager.instance.gameObject.GetComponent<PlayerInfo>();
            if (playerInfo.levelsCompleted < 7)
            { 
                if(level == playerInfo.levelsCompleted + 1)
                {
                    playerInfo.levelsCompleted++;
                }
            } 
            playerInfo.goldAmount += 100;
            if (hits >= 5)
            {
                playerInfo.goldAmount -= 25;

                if (hits >= 8)
                {
                    playerInfo.goldAmount -= 25;
                }
            }
            SaveManager.instance.SavePlayerData();
        }

    }
}
