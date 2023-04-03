using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    public void StartGame (){
        SceneManager.LoadScene("Start Menu");
        
    }

    public void GoBackToMenu(){
        SceneManager.LoadScene("Start Menu");
    }

    public void StartAirPollutionCauses(){
        SceneManager.LoadScene("AirPollutionCauses");
    }

    public void StartWaterPollutionCauses(){
        SceneManager.LoadScene("WaterPollutionQuiz");
    }

    public void StartAirPollutionFlappyBird(){
        SceneManager.LoadScene("AirPollutionFlappyBird");
    }

    public void StartLandPollutionCauses(){
        SceneManager.LoadScene("LandPollutionCauses");
    }

    public void StartSpaceInv1(){
        SceneManager.LoadScene("SpaceInvadersStart");
    }

    public void StartAirPollutionMeasuresToCombatGame(){
        SceneManager.LoadScene("SpaceInvadersGame");
    }

    public void StartLandPollutionEffects(){
        SceneManager.LoadScene("LandPollutionEffects");
    }

    public void StartLandCombatMethods(){
        SceneManager.LoadScene("LandCombatMethods");
    }

    public void StartWaterPollutionEffects(){
        SceneManager.LoadScene("WaterPollutionEffects");
    }

    public void StartWaterPollutionCombat(){
        SceneManager.LoadScene("WaterPollutionCombat");
    }

    public void ShowMM1(){
        SceneManager.LoadScene("MM1");
    }

    public void ShowMM2(){
        SceneManager.LoadScene("MM2");
    }

    public void ShowMM3(){
        SceneManager.LoadScene("MM3");
    }

    public void ShowMM4(){
        SceneManager.LoadScene("MM4");
    }
    
    public void QuitGame(){
        
        Debug.Log("QUIT!");
        Application.Quit();

    }
    
}