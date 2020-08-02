using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    

    public void setVolume(float i)
    {
        mainMixer.SetFloat("mainVolume" , i);
    }

    public void setGraphics(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }


}
