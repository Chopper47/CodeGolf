using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SetSoundsToButtons : MonoBehaviour
{
    private GameObject[] buttons;

    //List<Button> buttons = new List<Button>(); 
    // Start is called before the first frame update
    void Start()
    {
        buttons = MenuController.instance.GetAllButtonsInScene().ToArray();   

        foreach(var b in buttons)
        {
            UnityAction delegateToAssign = delegate { OnClick(); };
            b.GetComponent<Button>().onClick.AddListener(delegateToAssign);
        }
    }


    void OnClick()
    {
        Debug.Log("CLICKED");
        SoundManager.instance.PlaySound(SoundType.BUTTONCLICK, Random.Range(0.5f, 1f));
    }
}
