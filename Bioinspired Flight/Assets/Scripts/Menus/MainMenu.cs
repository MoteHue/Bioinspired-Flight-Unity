using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private SaveData achievementData;

    void Awake(){
        achievementData = new SaveData("Achievements.save");
        achievementData.Load();
    }

    public void PlayGame() {
        bool firstFlight = false;
        if (achievementData.data.ContainsKey("First Flight")){
            firstFlight = achievementData.data["First Flight"];
        }
        if (!firstFlight){
            achievementData.data["First Flight"] = true;
            achievementData.Save();
            UnityEngine.Debug.Log("First time?");
        } else {
            UnityEngine.Debug.Log("You've done this before, you'll be fine.");
        }
        SceneManager.LoadScene( 2 );
    }

    public void QuitGame() {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
