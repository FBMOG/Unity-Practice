using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Spawner spawner;

    public TMP_Text scoreText;
    public GameObject playButton;
    public GameObject replayButton;
    public GameObject gameOver;
    public GameObject play;
    public int score { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        play.SetActive(true);
        replayButton.SetActive(false);

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


}
