using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    public void StartGame (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartAirPollutionCauses(){
        SceneManager.LoadScene("AirPollutionCauses");
    }

    public void StartWaterPollutionCauses(){
        SceneManager.LoadScene("WaterPollutionQuiz");
    }

    public void StartLandPollutionCauses(){
        SceneManager.LoadScene("LandPollutionCauses");
    }

    public void StartAirPollutionMeasuresToCombat(){
        SceneManager.LoadScene("SpaceInvadersGame");
    }



    public void QuitGame(){
        
        Debug.Log("QUIT!");
        Application.Quit();

    }
    
}
