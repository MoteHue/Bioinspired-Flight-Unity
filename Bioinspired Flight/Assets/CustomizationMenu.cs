
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
    private GameObject dronePreview;
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
        UnityEngine.Debug.Log("Saving Feather change");
        loadoutData.Save();
    }

    public void toggleTurtle()
    {
        bool turtleStatus = loadoutData.data["Turtle"];
        UnityEngine.Debug.Log("Changing Turtle from");
        UnityEngine.Debug.Log(turtleStatus);
        UnityEngine.Debug.Log("To:");
        if (turtleStatus)
        {
            loadoutData.data["Turtle"] = false;
            turtleStatus = loadoutData.data["Turtle"];
            loadoutArray[0] = turtleStatus;

        }
        else
        {
            loadoutData.data["Turtle"] = true;
            turtleStatus = loadoutData.data["Turtle"];
            loadoutArray[0] = turtleStatus;
        }
        UnityEngine.Debug.Log(turtleStatus);
        UnityEngine.Debug.Log("Saving Turtle change");
        loadoutData.Save();
    }

    public void checkLoadout()
    {
        UnityEngine.Debug.Log(loadoutArray[0]);
        UnityEngine.Debug.Log(loadoutArray[1]);
    }

  
}


