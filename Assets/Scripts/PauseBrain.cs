using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBrain : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject menuButtons;
    public GameObject monsterStats;

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Stats()
    {
        menuButtons.SetActive(false);
        monsterStats.SetActive(true);
    }

    public void StatsToMenu()
    {
        menuButtons.SetActive(true);
        monsterStats.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
