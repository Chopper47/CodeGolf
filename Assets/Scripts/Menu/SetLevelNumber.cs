using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetLevelNumber : MonoBehaviour
{
    TextMesh textMesh;
    List<Transform> childrenList = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            childrenList.Add(transform.GetChild(i));
        }

        for(int i = 0; i < childrenList.Count; i++)
        {
            childrenList[i].GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
