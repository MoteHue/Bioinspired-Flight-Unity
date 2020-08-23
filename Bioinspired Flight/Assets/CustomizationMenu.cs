
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
    private bool[] loadoutArrayChange;
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
        loadoutArrayChange = new bool[4];
        dronePreview = GameObject.Find("allAttachmentDroneTilt");
        featherModel = GameObject.Find("seagull_sensor");
        turtleModel = GameObject.Find("turtle_sensor");
        hammerheadModel = GameObject.Find("hammerhead_sensor");
        octopusModel = GameObject.Find("octopus_sensor");

        // Make loadoutArrayChange same as loadout Array
        for(int i = 0; i<loadoutArray.Length; i++)
        {
            loadoutArrayChange[i] = loadoutArray[i];
        }

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
        bool featherStatus = loadoutArrayChange[0]; 

        if (featherStatus)
        {
            featherStatus = false;
            loadoutArrayChange[0] = false;
        }
        else
        {
            featherStatus = true;
            loadoutArrayChange[0] = true;
        }

        featherModel.GetComponent<MeshRenderer>().enabled = loadoutArrayChange[0];
    }

    public void toggleTurtle()
    {
        bool turtleStatus = loadoutArrayChange[1];

        if (turtleStatus)
        {
            turtleStatus = false;
            loadoutArrayChange[1] = false;
        }
        else
        {
            turtleStatus = true;
            loadoutArrayChange[1] = true;
        }

        turtleModel.GetComponent<MeshRenderer>().enabled = loadoutArrayChange[1];
    }

    public void toggleHammerhead()
    {
        bool hammerheadStatus = loadoutArrayChange[2];

        if (hammerheadStatus)
        {
            hammerheadStatus = false;
            loadoutArrayChange[2] = false;
        }
        else
        {
            hammerheadStatus = true;
            loadoutArrayChange[2] = true;
        }

        hammerheadModel.GetComponent<MeshRenderer>().enabled = loadoutArrayChange[2];
    }

    public void toggleOctopus()
    {
        bool octopusStatus = loadoutArrayChange[3];

        if (octopusStatus)
        {
            octopusStatus = false;
            loadoutArrayChange[3] = false;
        }
        else
        {
            octopusStatus = true;
            loadoutArrayChange[3] = true;
        }

        octopusModel.GetComponent<MeshRenderer>().enabled = loadoutArrayChange[3];
    }


    public void saveButton()
    {
        for (int a = 0; a < loadoutArrayChange.Length; a++)
        {
            loadoutArray[a] = loadoutArrayChange[a];
        }

        loadoutData.data["Feathers"] = loadoutArray[0];
        loadoutData.data["Turtle"] = loadoutArray[1];
        loadoutData.data["Hammerhead"] = loadoutArray[2];
        loadoutData.data["Octopus"] = loadoutArray[3];

        loadoutData.Save();
    }

    public void checkLoadout()
    {
        UnityEngine.Debug.Log(loadoutArray[0]);
        UnityEngine.Debug.Log(loadoutArray[1]);
        UnityEngine.Debug.Log(loadoutArray[2]);
        UnityEngine.Debug.Log(loadoutArray[3]);

    }


}


