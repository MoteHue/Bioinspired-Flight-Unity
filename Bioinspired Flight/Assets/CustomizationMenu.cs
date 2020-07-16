
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
        // Instantiating relevant components
        achievementData = rAchievementData;
        loadoutData = rLoadoutData;
        loadoutArray = rLoadoutArray;
        dronePreview = GameObject.Find("allAttachmentDroneTilt");
        featherModel = GameObject.Find("seagull_sensor");
        turtleModel = GameObject.Find("turtle_sensor");
        hammerheadModel = GameObject.Find("hammerhead_sensor");
        octopusModel = GameObject.Find("octopus_sensor");

        //Display previously saved loadout
        if (loadoutData.data["Feathers"])
        {
            featherModel.GetComponent<MeshRenderer>().enabled = true;
        }

        if (loadoutData.data["Turtle"])
        {
            turtleModel.GetComponent<MeshRenderer>().enabled = true;
        }

        if (loadoutData.data["Hammerhead"])
        {
            hammerheadModel.GetComponent<MeshRenderer>().enabled = true;
        }

        if (loadoutData.data["Octopus"])
        {
            octopusModel.GetComponent<MeshRenderer>().enabled = true;
        }
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

    public void toggleHammerhead()
    {
        bool hammerheadStatus = loadoutData.data["Hammerhead"];
        UnityEngine.Debug.Log("Changing Hammerhead from");
        UnityEngine.Debug.Log(hammerheadStatus);
        UnityEngine.Debug.Log("To:");
        if (hammerheadStatus)
        {
            loadoutData.data["Hammerhead"] = false;
            hammerheadStatus = loadoutData.data["Hammerhead"];
            loadoutArray[2] = hammerheadStatus;

        }
        else
        {
            loadoutData.data["Hammerhead"] = true;
            hammerheadStatus = loadoutData.data["Hammerhead"];
            loadoutArray[2] = hammerheadStatus;
        }
        UnityEngine.Debug.Log(hammerheadStatus);
        UnityEngine.Debug.Log("Saving Hammerhead change");
        loadoutData.Save();
        hammerheadModel.GetComponent<MeshRenderer>().enabled = loadoutArray[2];
    }

    public void toggleOctopus()
    {
        bool octopusStatus = loadoutData.data["Octopus"];
        UnityEngine.Debug.Log("Changing Octopus from");
        UnityEngine.Debug.Log(octopusStatus);
        UnityEngine.Debug.Log("To:");
        if (octopusStatus)
        {
            loadoutData.data["Octopus"] = false;
            octopusStatus = loadoutData.data["Octopus"];
            loadoutArray[3] = octopusStatus;

        }
        else
        {
            loadoutData.data["Octopus"] = true;
            octopusStatus = loadoutData.data["Octopus"];
            loadoutArray[3] = octopusStatus;
        }
        UnityEngine.Debug.Log(octopusStatus);
        UnityEngine.Debug.Log("Saving Octopus change");
        loadoutData.Save();
        octopusModel.GetComponent<MeshRenderer>().enabled = loadoutArray[3];
    }


    public void checkLoadout()
    {
        UnityEngine.Debug.Log(loadoutArray[0]);
        UnityEngine.Debug.Log(loadoutArray[1]);
        UnityEngine.Debug.Log(loadoutArray[2]);
        UnityEngine.Debug.Log(loadoutArray[3]);

    }


}


