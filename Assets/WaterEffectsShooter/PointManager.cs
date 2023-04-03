using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public int wrong;
    public int correct;
    public TMP_Text correctText;
    public TMP_Text scoreText;
    public TMP_Text wrongText;

    public TMP_Text finalcorrectText;
    public TMP_Text finalscoreText;
    public TMP_Text finalwrongText;

    public GameObject game;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: "+ score;
        wrongText.text = "Wrong Targets Shot: "+ wrong;
        correctText.text = "Correct Targets Shot: "+ correct;

        finalscoreText.text = "Score: "+ score;
        finalwrongText.text = "Wrong Targets Shot: "+ wrong;
        finalcorrectText.text = "Correct Targets Shot: "+ correct;
    }

    // Update is called once per frame
    public void updateScore(int points)
    {
        score = score+ points;
        scoreText.text = "Score: "+ score;
        
    }

    public void updateWrong(int wrongInt){
        wrong = wrong + wrongInt;
        wrongText.text = "Wrong Targets Shot: "+ wrong;
    }

    public void updateCorrect(int correctInt){
        correct = correct + correctInt;
        correctText.text = "Correct Targets Shot: "+ correct;
    }

    public void GameOver(){
        game.SetActive(false);
        gameOver.SetActive(true);

        finalscoreText.text = "Score: "+ score;
        finalwrongText.text = "Wrong Targets Shot: "+ wrong;
        finalcorrectText.text = "Correct Targets Shot: "+ correct;
        
    }
}
