using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrainManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject aboutPanel;

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void About()
    {
        menuPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }

    public void Menu()
    {
        aboutPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
