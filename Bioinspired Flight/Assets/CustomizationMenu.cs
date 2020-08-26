
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomizationMenu : MonoBehaviour
{
    [SerializeField] List<Button> attachmentButtons = new List<Button>();
    [SerializeField] List<bool> unlockedAttachments = new List<bool>();


    private SaveData achievementData;
    private SaveData loadoutData;
    private bool[] loadoutArray;
    private bool[] loadoutArrayChange;
    private GameObject dronePreview;
    private GameObject featherModel;
    private GameObject turtleModel;
    private GameObject hammerheadModel;
    private GameObject octopusModel;

    public Button getButtonFromIndex(int i)
    {
        return attachmentButtons[i];
    }

    public void openMenu(SaveData rAchievementData, SaveData rLoadoutData, bool[] rLoadoutArray)
    {

        // Instantiating relevant components
        achievementData = rAchievementData;
        loadoutData = rLoadoutData;
        loadoutArray = rLoadoutArray;
        loadoutArrayChange = new bool[4];

        // Checking objects are found
        dronePreview = GameObject.Find("Player Variant");
        if(dronePreview == null)
        {
            UnityEngine.Debug.Log("Soz too broke to afford a drone prefab");
        }
        featherModel = dronePreview.transform.Find("HitBox/Scalar/feathers").gameObject;
        if(featherModel == null)
        {
            UnityEngine.Debug.Log("Lool canne find feathers");
        }
        turtleModel = dronePreview.transform.Find("HitBox/Scalar/turtleSensor").gameObject;
        if(turtleModel == null)
        {
            UnityEngine.Debug.Log("Nope, no turtles here");
        }
        hammerheadModel = dronePreview.transform.Find("HitBox/Scalar/hammerheadSensor").gameObject;
        if(hammerheadModel == null)
        {
            UnityEngine.Debug.Log("Nice try, hammerheads arent real");
        }
        octopusModel = dronePreview.transform.Find("HitBox/Scalar/tentacleSensor").gameObject;
        if(octopusModel == null)
        {
            UnityEngine.Debug.Log("Octupi are sneaky, can't find them");
        }

        // Make loadoutArrayChange same as loadout Array
        for(int i = 0; i<loadoutArray.Length; i++)
        {
            loadoutArrayChange[i] = loadoutArray[i];
        }

        //Display previously saved loadout ONLY
        if (loadoutData.data["Feathers"])
        {
            featherModel.SetActive(true);
        }
        else
        {
            featherModel.SetActive(false);
        }

        if (loadoutData.data["Turtle"])
        {
            turtleModel.SetActive(true);
        }
        else
        {
            turtleModel.SetActive(false);
        }

        if (loadoutData.data["Hammerhead"])
        {
            hammerheadModel.SetActive(true);
        }
        else
        {
            hammerheadModel.SetActive(false);
        }

        if (loadoutData.data["Octopus"])
        {
            octopusModel.SetActive(true);
        }
        else
        {
            octopusModel.SetActive(false);
        }

        // Unlock Attachments Unlocked
        for (int i = 0; i < unlockedAttachments.Count; i++)
        {
            if(unlockedAttachments[i] == true)
            {
                Button currentAttachment = getButtonFromIndex(i);
                GameObject lockedButton = currentAttachment.transform.Find("Locked").gameObject;
                GameObject equipButton = currentAttachment.transform.Find("Equip").gameObject;
                lockedButton.SetActive(false);
                equipButton.SetActive(true);
            }
            else
            {
                Button currentAttachment = getButtonFromIndex(i);
                GameObject lockedButton = currentAttachment.transform.Find("Locked").gameObject;
                GameObject equipButton = currentAttachment.transform.Find("Equip").gameObject;
                lockedButton.SetActive(true);
                equipButton.SetActive(false);
            }
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

        featherModel.SetActive(loadoutArrayChange[0]);
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

        turtleModel.SetActive(loadoutArrayChange[1]);
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

        hammerheadModel.SetActive(loadoutArrayChange[2]);
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

        octopusModel.SetActive(loadoutArrayChange[3]);
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


