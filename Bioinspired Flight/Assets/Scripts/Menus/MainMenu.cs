using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private CustomizationMenu customizationMenu;


    private SaveData achievementData;
    private SaveData loadoutData;
    private bool[] loadoutArray;
    void Awake(){
        achievementData = new SaveData("Achievements.save");
        achievementData.Load();
        loadoutData = new SaveData("Loadout.save");
        loadoutData.Load();
        loadoutArray = new bool[4];
}

    public SaveData getAchievementSave()
    {
        return achievementData;
    }

    public SaveData GetLoadoutSave()
    {
        return loadoutData;
    }

    public bool[] getLoadoutArray()
    {
        return loadoutArray;
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
        customizationMenu = GameObject.FindObjectOfType<CustomizationMenu>();
        bool firstLoadout = false;
        if (loadoutData.data.ContainsKey("Loadout")){
            firstLoadout = loadoutData.data["Loadout"];
            loadoutData.Save();
            loadoutArray[0] = loadoutData.data["Feathers"];
            loadoutArray[1] = loadoutData.data["Turtle"];
            loadoutArray[2] = loadoutData.data["Hammerhead"];
            loadoutArray[3] = loadoutData.data["Octopus"];
            UnityEngine.Debug.Log(loadoutArray[0]);
            UnityEngine.Debug.Log(loadoutArray[1]);
            UnityEngine.Debug.Log(loadoutArray[2]);
            UnityEngine.Debug.Log(loadoutArray[3]);
        }

        // First loadout
        if (!firstLoadout)
        {
            // Set Loadout value to true
            loadoutData.data["Loadout"] = true;
            // Default loadout
            loadoutData.data["Feathers"] = false;
            loadoutData.data["Turtle"] = false;
            loadoutData.data["Hammerhead"] = false;
            loadoutData.data["Octopus"] = false;

            // Save intitial loadout
            loadoutData.Save();

            UnityEngine.Debug.Log("Loadouts created at lvl4");
        }

        customizationMenu.openMenu(achievementData, loadoutData, loadoutArray);
    }

    public void QuitGame() {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
