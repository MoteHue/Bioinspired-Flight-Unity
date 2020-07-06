
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
public class CustomizationMenu : MonoBehaviour
{
    private SaveData achievementData;
    private SaveData loadoutData;
    private bool[] loadoutArray;

    public void openMenu(SaveData rAchievementData, SaveData rLoadoutData, bool[] rLoadoutArray)
    {
        achievementData = rAchievementData;
        loadoutData = rLoadoutData;
        loadoutArray = rLoadoutArray;
    }

    public void toggleFeather()
    {
        bool featherStatus = loadoutData.data["Feathers"];
        UnityEngine.Debug.Log("Changing Feather from");
        UnityEngine.Debug.Log(featherStatus);
        UnityEngine.Debug.Log("To:");
        if (featherStatus)
        {
            loadoutData.data["Feathers"] = false;
            featherStatus = loadoutData.data["Feathers"];
            loadoutArray[0] = featherStatus;

        }
        else
        {
            loadoutData.data["Feathers"] = true;
            featherStatus = loadoutData.data["Feathers"];
            loadoutArray[0] = featherStatus;
        }
        UnityEngine.Debug.Log(featherStatus);
        UnityEngine.Debug.Log("Saving feather change");
        loadoutData.Save();
    }

    public void toggleTurtle()
    {
        bool turtleStatus = loadoutData.data["Turtle"];

        if (turtleStatus)
        {
            loadoutData.data["Turtle"] = false;
            turtleStatus = loadoutData.data["Turtle"];
            loadoutArray[1] = turtleStatus;
        }
        else
        {
            loadoutData.data["Turtle"] = true;
            turtleStatus = loadoutData.data["Turtle"];
            loadoutArray[1] = turtleStatus;
        }
        loadoutData.Save();
        UnityEngine.Debug.Log("Loadout now:");
        UnityEngine.Debug.Log(loadoutArray[0]);
        UnityEngine.Debug.Log(loadoutArray[1]);
    }
    
    public void checkLoadout()
    {
        UnityEngine.Debug.Log(loadoutArray[0]);
        UnityEngine.Debug.Log(loadoutArray[1]);
    }

  
}


