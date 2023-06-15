using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Sofa : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public GameObject panel;
    public Button option11;
    public Button option12;
    public Button option13;
    public Button option21;
    public Button option22;
    public Button option23;
    public Button option31;
    public Button option32;
    public Button option33;
    public Image image;
    public Canvas interactionPrompt;
    public Text option12Text;
    public Text option22Text;
    public Text option32Text;
    public Player player;
    private int counter = -1;
    public Image errorPrompt;
    public Text errorPromptText;

    public AudioSource audioSource;
    public AudioClip readingSound;
    public AudioClip writtnigSound;
    public AudioClip sleepingSound;

    public bool Interact(Interactor interactor)
    {
        GameObject timeController = GameObject.Find("TimeController");
        TimeController timeControllerScript = timeController.GetComponent<TimeController>();

        interactionPrompt.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        option11.gameObject.SetActive(false);
        option12.gameObject.SetActive(true);
        option13.gameObject.SetActive(false);
        option21.gameObject.SetActive(false);
        option22.gameObject.SetActive(true);
        option23.gameObject.SetActive(false);
        option31.gameObject.SetActive(false);
        option32.gameObject.SetActive(true);
        option33.gameObject.SetActive(false);
        Debug.Log("Sofa");
        panel.SetActive(true);
        Time.timeScale = 0;
        option12Text.text = "Read newspaper";
        option22Text.text = "Take a nap";
        option32Text.text = "Solve a crossword puzzle";

        System.Random r = new System.Random();
        int rInt = r.Next(-5, 5);
        int rInt2 = r.Next(0, 10);

        option12.onClick.AddListener(() => {
            audioSource.PlayOneShot(readingSound, 0.4f);
            Debug.Log("Selected Read newspaper"); 
            panel.SetActive(false);
            player.Heal(3);
            player.DecreaseHunger(5);
            player.DecreaseWellBeing(rInt);
            timeControllerScript.AddHoursToTime(0.4);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option22.onClick.AddListener(() => {
            panel.SetActive(false);
            if (player.nap == false)
            {
                audioSource.PlayOneShot(sleepingSound, 0.2f);
                Debug.Log("Selected Take a nap");
                timeControllerScript.AddHoursToTime(1);
                player.Heal(10);
                player.DecreaseHunger(5);
                player.IncreaseWellBeing(5);
                player.nap = true;
            }
            else
            {
                Debug.Log("Error Take a nap!");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "You already took a nap!";
                counter = 500;
            }
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option32.onClick.AddListener(() => {
            audioSource.PlayOneShot(writtnigSound, 0.4f);
            Debug.Log("Selected Solve a crossword puzzle"); 
            panel.SetActive(false);
            player.Heal(3);
            player.DecreaseHunger(5);
            player.IncreaseWellBeing(rInt2);
            timeControllerScript.AddHoursToTime(0.75);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        return true;
    }

    void Update()
    {
        if (counter > 0)
        {
            counter--;
        }
        else if (counter == 0)
        {
            errorPrompt.gameObject.SetActive(false);
            counter = -1;
        }
    }

    void RemoveListeners()
    {
        option11.onClick.RemoveAllListeners();
        option12.onClick.RemoveAllListeners();
        option13.onClick.RemoveAllListeners();
        option21.onClick.RemoveAllListeners();
        option22.onClick.RemoveAllListeners();
        option23.onClick.RemoveAllListeners();
        option31.onClick.RemoveAllListeners();
        option32.onClick.RemoveAllListeners();
        option33.onClick.RemoveAllListeners();
    }
}

