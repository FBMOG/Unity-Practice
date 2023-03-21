using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TrashManager : MonoBehaviour
{
    public GameObject[] gameObjects;
    public Canvas endOfLevelCanvas;

    void Update()
    {
        bool isAllNull = true;
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null)
            {
                isAllNull = false;
                break;
            }
        }

        if (isAllNull)
        {
            endOfLevelCanvas.gameObject.SetActive(true);
        }
    }
}

