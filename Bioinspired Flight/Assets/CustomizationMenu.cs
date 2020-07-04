
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
public class CustomizationMenu : MonoBehaviour
{

    private SaveData achievementData;
    private SaveData loadoutData;
    private bool[] loadoutArray = new bool[2];

    void Awake()
    {
        achievementData = new SaveData("Achievements.save");
        achievementData.Load();
        loadoutData = new SaveData("Loadout.save");
        loadoutData.Load();
    }

    public void toggleFeather()
    {
        bool featherStatus = loadoutData.data["Feathers"];

        if (featherStatus)
        {
            UnityEngine.Debug.Log("Feathers are true");
            loadoutData.data["Feathers"] = false;
            featherStatus = loadoutData.data["Feathers"];
            UnityEngine.Debug.Log("Now they are:");
            UnityEngine.Debug.Log(featherStatus);

        }
        else
        {
            UnityEngine.Debug.Log("Feathers are false");
            loadoutData.data["Feathers"] = true;
            featherStatus = loadoutData.data["Feathers"];
            UnityEngine.Debug.Log("Now they are:");
            UnityEngine.Debug.Log(featherStatus);
        }
        loadoutData.Save();

    }

    public void toggleTurtle()
    {
        bool turtleStatus = loadoutData.data["Turtle"];

        if (turtleStatus)
        {
            UnityEngine.Debug.Log("Turtle are true");
            loadoutData.data["Turtle"] = false;
            turtleStatus = loadoutData.data["Turtle"];
            UnityEngine.Debug.Log("Now they are:");
            UnityEngine.Debug.Log(turtleStatus);
        }
        else
        {
            UnityEngine.Debug.Log("Turtle are false");
            loadoutData.data["Turtle"] = true;
            turtleStatus = loadoutData.data["Turtle"];
            UnityEngine.Debug.Log("Now they are:");
            UnityEngine.Debug.Log(turtleStatus);
        }
        loadoutData.Save();

    }
}


