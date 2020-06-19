using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public void ResumeGame() {
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void ExitGame() {
        SceneManager.LoadScene(0);
    }

    public void PauseGame() {
        GameIsPaused = true;
        Time.timeScale = 0f;
    }
}
