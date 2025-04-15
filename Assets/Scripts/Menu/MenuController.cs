using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    List<GameObject> GetAllObjectsOnlyInScene()
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
            {
                objectsInScene.Add(go);

            }
        }

        return objectsInScene;
    }
    public List<GameObject> GetAllButtonsInScene()
    {
        List<GameObject> objects = GetAllObjectsOnlyInScene();

        List<GameObject> buttonsInScene = new List<GameObject>();

        foreach(GameObject o in objects)
        {

            if (o.GetComponent<Button>())
            {
                Debug.Log(o);
                buttonsInScene.Add(o);
            }
        }

        return buttonsInScene;
    }
}
