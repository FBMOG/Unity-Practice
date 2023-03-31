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
    public GameObject gameWin;
    public GameObject gameWinTxt;
    public GameObject play;
    [SerializeField] public AudioSource audioSource;
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
        gameWinTxt.SetActive(false);

        Pause();
        audioSource.Play();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        gameWin.SetActive(false);
        play.SetActive(false);
        replayButton.SetActive(false);
        instruct.SetActive(false);
        lostTxt.SetActive(false);
        gameWinTxt.SetActive(false);

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

    public int PlayerScore(){
        return score;
    }


    public void GameWin()
    {
        //playButton.SetActive(true);
        replayButton.SetActive(true);
        gameWin.SetActive(true);
        gameWinTxt.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        audioSource.Stop();
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
            if (currentScore > 2 && currentScore <= 4)
            {
                for (int i = 0; i < pipes.Length; i++) {
                    pipes[i].setSpeed(6);
                }

            }
                        // Do something with the score...
            else if (currentScore > 4 && currentScore <= 6)
            {
                for (int i = 0; i < pipes.Length; i++) {
                    pipes[i].setSpeed(8);
                }

            }
            // Do something with the score...
            else if (currentScore > 6 && currentScore <= 8)
            {
                for (int i = 0; i < pipes.Length; i++) {
                    pipes[i].setSpeed(10);
                }

            }
            // Do something with the score...
            else if (currentScore > 8)
            {
                for (int i = 0; i < pipes.Length; i++) {
                    pipes[i].setSpeed(12);
                }

            }
            else
            {
                Debug.Log("Score is less than or equal to 5.");
            }
        }
        else
        {
            Debug.LogWarning("Invalid score value: " + currentScoreText);
        }

    }


}
