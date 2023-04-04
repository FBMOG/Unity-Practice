using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
    public GameObject game;
    public GameObject gameOver;
    public GameObject startScreen;
    [SerializeField] public AudioSource audioSource1, audioSource2;
    // Start is called before the first frame update
    void Start()
    {
        game.SetActive(false);
        gameOver.SetActive(false);
        startScreen.SetActive(true);
        audioSource1.Play();

  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextGame(){
        SceneManager.LoadScene("WaterPollutionCombat");
    
    }

    public void loadShooter(){
        audioSource1.Stop();
        audioSource2.Play();
        startScreen.SetActive(false);
        game.SetActive(true);

    }
}
