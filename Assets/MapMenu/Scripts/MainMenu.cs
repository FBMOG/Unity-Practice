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
        SceneManager.LoadScene("SpaceInvadersStart");
    }

    public void StartAirPollutionMeasuresToCombatGame(){
        SceneManager.LoadScene("SpaceInvadersGame");
    }

    public void ShowMM1(){
        SceneManager.LoadScene("MM1");
    }

    public void ShowMM2(){
        Debug.Log("something");
        SceneManager.LoadScene("MM2");
    }



    public void QuitGame(){
        
        Debug.Log("QUIT!");
        Application.Quit();

    }
    
}
