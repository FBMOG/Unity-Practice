using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Pipes pipe;
    public Spawner spawner;

    public TMP_Text scoreText;
    public GameObject playButton;
    public GameObject replayButton;
    public GameObject instruct;
    public GameObject lostTxt;
    public GameObject gameOver;
    public GameObject play;
    public int score { get; private set; }

    private void Awake()
    {
        
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        pipe = FindObjectOfType<Pipes>();
        play.SetActive(true);
        replayButton.SetActive(false);
        instruct.SetActive(true);
        lostTxt.SetActive(false);

        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        play.SetActive(false);
        replayButton.SetActive(false);
        instruct.SetActive(false);
        lostTxt.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }

    }

    public void GameOver()
    {
        //playButton.SetActive(true);
        replayButton.SetActive(true);
        gameOver.SetActive(true);
        lostTxt.SetActive(true);

        Pause();
    }

    public void Pause()
    {
    
        Time.timeScale = 0f;
        player.enabled = false;
    }



    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

    }

    public void restartGame(){
        //because we want the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Update(){
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        // Get the current value of the scoreText component's text
        string currentScoreText = scoreText.text;

        // Convert the text value to an integer using int.Parse() or int.TryParse()
        int currentScore;
        if (int.TryParse(currentScoreText, out currentScore))
        {
            // Do something with the score...
            if (currentScore > 10 && currentScore <= 20)
            {
                for (int i = 0; i < pipes.Length; i++) {
                    pipes[i].setSpeed(6);
                }

            }
                        // Do something with the score...
            else if (currentScore > 20 && currentScore <= 30)
            {
                for (int i = 0; i < pipes.Length; i++) {
                    pipes[i].setSpeed(8);
                }

            }
            // Do something with the score...
            else if (currentScore > 30 && currentScore <= 40)
            {
                for (int i = 0; i < pipes.Length; i++) {
                    pipes[i].setSpeed(10);
                }

            }
            // Do something with the score...
            else if (currentScore > 40 && currentScore <= 50)
            {
                for (int i = 0; i < pipes.Length; i++) {
                    pipes[i].setSpeed(12);
                }

            }
            // Do something with the score...
            else if (currentScore > 50)
            {
                for (int i = 0; i < pipes.Length; i++) {
                    pipes[i].setSpeed(15);
                }

            }
            else
            {
                Debug.Log("Score is less than or equal to 10.");
            }
        }
        else
        {
            Debug.LogWarning("Invalid score value: " + currentScoreText);
        }

    }


}
