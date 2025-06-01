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

    private void Start()
    {
        SaveManager.instance.LoadPlayerData();
    }

    /// <summary>
    /// Gets all objects in the scene
    /// </summary>
    /// <returns></returns>
    List<GameObject> GetAllObjectsOnlyInScene()
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            objectsInScene.Add(go);
#if UNITY_EDITOR
            if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
            {

            }
#endif
        }

        return objectsInScene;
    }

    /// <summary>
    /// Gets all buttons in the scene
    /// </summary>
    /// <returns></returns>
    public List<GameObject> GetAllButtonsInScene()
    {
        List<GameObject> objects = GetAllObjectsOnlyInScene();

        List<GameObject> buttonsInScene = new List<GameObject>();

        foreach(GameObject o in objects)
        {

            if (o.GetComponent<Button>())
            {
                buttonsInScene.Add(o);
            }
        }

        return buttonsInScene;
    }

    public void MoveResourcesToUpgradePage(Transform resources)
    {
        resources.position = new Vector3(resources.position.x, resources.position.y - 100, resources.position.z);
    }
}
