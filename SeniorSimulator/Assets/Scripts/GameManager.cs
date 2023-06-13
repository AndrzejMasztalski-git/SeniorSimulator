using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject optionDialoguePanel;
    public GameObject escapePanel;
    public GameObject gameOverPanel;
    void Start()
    {
        optionDialoguePanel.SetActive(false);
        escapePanel.SetActive(false);
        gameOverPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            escapePanel.SetActive(true);
        }
    }
}
