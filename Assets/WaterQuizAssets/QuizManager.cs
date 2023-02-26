using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options; //buttons
    public int currentQuestion;
    public TMP_Text QuestionText;



    private void Start(){
       // QnA.RemoveAt(currentQuestion);
        generateQuestion();

    }

    public void correct(){
        generateQuestion();
    }

    void setAnswers(){
        for(int i = 0; i < options.Length; i++){
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].correctAnswer == i+1){
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion(){
        currentQuestion = Random.Range(0,QnA.Count);

        QuestionText.text = QnA[currentQuestion].Question;

        setAnswers();

        QnA.RemoveAt(currentQuestion);
    }
    
}
