using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementsMenu : MonoBehaviour
{
    private SaveData achievementData;

    void Awake(){
        achievementData = new SaveData("Achievements.save");
        achievementData.Load();
        RevealAchievements();
    }

    private void RevealAchievements(){
        GameObject[] achievements = GameObject.FindGameObjectsWithTag("Achievement");
        TextMeshProUGUI currentNameText;
        GameObject description;
        GameObject hidden;
        string name;
        foreach (GameObject achievement in achievements){
            currentNameText = achievement.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
            name = currentNameText.text;
            if (achievementData.data.ContainsKey(name)
                && achievementData.data[name]){
                currentNameText.color = new Color32(255, 255, 255, 255);
                description = achievement.transform.Find("Description").gameObject;
                hidden = achievement.transform.Find("Hidden").gameObject;
                description.SetActive(true);
                hidden.SetActive(false);
            }
        }
    }
    
}
