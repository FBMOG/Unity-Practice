using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: "+ score;
    }

    // Update is called once per frame
    public void updateScore(int points)
    {
        score = score+ points;
        scoreText.text = "Score: "+ score;
        
    }
}
