using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject btn;

    void Awake() {
        for(int i = 0; i < 8; i++){
            GameObject Button = Instantiate(btn);
            Button.name = "" + i;
            Button.transform.SetParent(puzzleField, false);
        }
    }
}
