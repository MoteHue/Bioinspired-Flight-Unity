
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
    private GameObject featherModel;
    private GameObject turtleModel;
    private GameObject hammerheadModel;
    private GameObject octopusModel;

    public void openMenu(SaveData rAchievementData, SaveData rLoadoutData, bool[] rLoadoutArray)
    {
        achievementData = rAchievementData;
        loadoutData = rLoadoutData;
        loadoutArray = rLoadoutArray;
        dronePreview = GameObject.Find("allAttachmentDroneTilt");
        featherModel = GameObject.Find("seagull_sensor");
        turtleModel = GameObject.Find("turtle_sensor");
        hammerheadModel = GameObject.Find("hammerhead_sensor");
        octopusModel = GameObject.Find("octopus_sensor");
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
        featherModel.GetComponent<MeshRenderer>().enabled = loadoutArray[0];
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
            loadoutArray[1] = turtleStatus;

        }
        else
        {
            loadoutData.data["Turtle"] = true;
            turtleStatus = loadoutData.data["Turtle"];
            loadoutArray[1] = turtleStatus;
        }
        UnityEngine.Debug.Log(turtleStatus);
        UnityEngine.Debug.Log("Saving Turtle change");
        loadoutData.Save();
        turtleModel.GetComponent<MeshRenderer>().enabled = loadoutArray[1];
    }

    public void checkLoadout()
    {
        UnityEngine.Debug.Log(loadoutArray[0]);
        UnityEngine.Debug.Log(loadoutArray[1]);
    }

  
}


