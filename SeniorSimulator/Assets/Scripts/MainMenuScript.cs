using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;
    public AudioMixer mainMixer;

    private void Start()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }
    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);
    }
    public void ChangeSceneToCharacterSelection()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangePanelToMainMenu()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void ChangePanelToOptionsMenu()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
        
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
