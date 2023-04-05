using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options; //buttons
    public int currentQuestion;
    public TMP_Text QuestionText;
    public GameObject gameOverPanel;
    public GameObject quizPanel;
    public GameObject startScreen;
     [SerializeField] public AudioSource audioSource1, audioSource2, audioSource3, audioSource4, audioSource5, audioSource6;

    public TMP_Text ScoreText;

    int totalQuestions = 0; 

    public int score = 0;



    private void Start(){
        audioSource1.Play();
        totalQuestions = QnA.Count;
        
        gameOverPanel.SetActive(false);
        quizPanel.SetActive(false);
        startScreen.SetActive(true);

        generateQuestion();



    }

    public void play(){
        audioSource6.Play();
        audioSource1.Stop();
        audioSource2.Play();
        startScreen.SetActive(false);
        quizPanel.SetActive(true);
    }

    public void retry(){
        audioSource6.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }


    public void GameOver(){
        audioSource2.Stop();
        audioSource3.Play();
        quizPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        ScoreText.text = "Score: " + score + "/" + totalQuestions;
    }

    public void correct(){
        audioSource4.Play();
        score = score + 1;
        StartCoroutine(WaitForNext());
        QnA.RemoveAt(currentQuestion);
        //generateQuestion();
    }

    public void wrong(){
        //do something for wrong
        audioSource5.Play();
        Debug.Log("Sorry, the correct answer is: "+ QnA[currentQuestion].correctAnswerString);
        StartCoroutine(WaitForNext());
        QnA.RemoveAt(currentQuestion);
    }


    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }

    void setAnswers(){
        for(int i = 0; i < options.Length; i++){
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;

            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Image>().sprite = QnA[currentQuestion].Answers[i];
            

            if(QnA[currentQuestion].correctAnswer == i+1){
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
            
            
        }
    }

    void generateQuestion(){
        
        if(QnA.Count > 0){
            currentQuestion = Random.Range(0,QnA.Count);
            QuestionText.text = QnA[currentQuestion].Question;
            setAnswers();
        }
        else{
            Debug.Log("Out of Questions");
            GameOver();
        }


    }
    
}
