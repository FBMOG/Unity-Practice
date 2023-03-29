using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class TrashManager : MonoBehaviour
{
    public GameObject[] gameObjects;
    public Canvas endOfLevelCanvas;
    public TMP_Text counter;
    private int trashCounter = 0;


    void Update()
    {
        bool isAllNull = true;
        trashCounter= 0;
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null)
            {
                trashCounter++;
                isAllNull = false;
            }
        }
        counter.text = "Hidden Trash Counter: " + trashCounter;

        if (isAllNull)
        {
            endOfLevelCanvas.gameObject.SetActive(true);
            
        }
    }
}

