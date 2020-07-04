using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private SaveData achievementData;
    private SaveData loadoutData;
    private bool[] loadoutArray = new bool[2];

    void Awake(){
        achievementData = new SaveData("Achievements.save");
        achievementData.Load();
        loadoutData = new SaveData("Loadout.save");
        loadoutData.Load();
    }

    public void PlayGame() {
        bool firstFlight = false;
        if (achievementData.data.ContainsKey("First Flight")) {
            firstFlight = achievementData.data["First Flight"];
        }
        if (!firstFlight){
            //Setup First time achievement data
            achievementData.data["First Flight"] = true;
            achievementData.Save();


            UnityEngine.Debug.Log("First time?");
        } else {
            UnityEngine.Debug.Log("You've done this before, you'll be fine.");

        }
        SceneManager.LoadScene( 2 );
    }

    // When Customizations is pressed:
    // First Time: Create Loadout.save to save loadout preferences
    // Any other time: Reassign loadoutArray to reflect values in
    // previously saved Loadout.save
    public void Customizations()
    {
        bool firstLoadout = false;
        bool[] loadoutArray = new bool[2];
        if (loadoutData.data.ContainsKey("Loadout")){
            firstLoadout = loadoutData.data["Loadout"];
            loadoutArray[0] = loadoutData.data["Feathers"];
            loadoutArray[1] = loadoutData.data["Turtle"];
            UnityEngine.Debug.Log("Made your last saved loadout");
        }

        // First loadout
        if (!firstLoadout)
        {
            // Set Loadout value to true
            loadoutData.data["Loadout"] = true;
            // Default loadout
            loadoutData.data["Feathers"] = false;
            loadoutData.data["Turtle"] = true;

            // Save intitial loadout
            loadoutData.Save();

            UnityEngine.Debug.Log("Loadouts created at lvl4");
        }
        else
        {
            UnityEngine.Debug.Log("Loadout already there");
            UnityEngine.Debug.Log(loadoutArray[0]);
            UnityEngine.Debug.Log(loadoutArray[1]);
        }
    }

    // Used to test whether you can freely change loadout values
    // whilst having it update in customizations
    public void testChangeLoadout()
    {
        UnityEngine.Debug.Log("Fine I'll give you feathers");
        loadoutData.data["Feathers"] = true;
        if (loadoutData.data["Feathers"])
        {
            UnityEngine.Debug.Log("So it changes even without saving but it worked");
        }

        loadoutData.Save();

    }
    public void QuitGame() {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
