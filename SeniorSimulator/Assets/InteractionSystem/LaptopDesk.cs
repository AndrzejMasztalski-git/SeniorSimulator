using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LaptopDesk : MonoBehaviour, IInteractable
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
    public Text option21Text;
    public Text option22Text;
    public Text option23Text;
    public Text option32Text;
    public Player player;
    public Image errorPrompt;
    public Text errorPromptText;
    public int counter = -1;

    public AudioSource audioSource;
    public AudioClip clickingSound;
    public bool Interact(Interactor interactor)
    {
        GameObject timeController = GameObject.Find("TimeController");
        TimeController timeControllerScript = timeController.GetComponent<TimeController>();

        interactionPrompt.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        option11.gameObject.SetActive(false);
        option13.gameObject.SetActive(false);
        option31.gameObject.SetActive(false);
        option33.gameObject.SetActive(false);
        option12.gameObject.SetActive(true);
        option21.gameObject.SetActive(true);
        option22.gameObject.SetActive(true);
        option23.gameObject.SetActive(true);
        option32.gameObject.SetActive(true);
        Debug.Log("TV interaction");
        panel.SetActive(true);
        Time.timeScale = 0;
        option12Text.text = "Read news";
        option21Text.text = "Play Senior Simulator";
        option22Text.text = "Release CS2";
        option23Text.text = "Write some code in ASM";
        option32Text.text = "Watch newest WK film";

        System.Random r = new System.Random();
        int rInt = r.Next(-5, 5);

        option12.onClick.AddListener(() => { 
            Debug.Log("Selected Read news"); 
            panel.SetActive(false);
            player.Heal(2);
            player.DecreaseHunger(3);
            player.DecreaseWellBeing(rInt);
            timeControllerScript.AddHoursToTime(0.3);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option21.onClick.AddListener(() => { 
            Debug.Log("Selected Play Senior Simulator"); 
            panel.SetActive(false);
            player.TakeDamage(2);
            player.DecreaseHunger(7);
            player.IncreaseWellBeing(10);
            timeControllerScript.AddHoursToTime(1);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option22.onClick.AddListener(() => {
            if (player.cs == false) {
                Debug.Log("Selected Release CS2");
                audioSource.PlayOneShot(clickingSound);
                panel.SetActive(false);
                player.IncreaseWellBeing(100);
                timeControllerScript.AddHoursToTime(0.2);
            }
            else
            {
                Debug.Log("Error Selected Release CS2!");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "CS2 is already released!";
                counter = 500;
            }
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option23.onClick.AddListener(() => {
            
            Debug.Log("Selected Write some code in ASM");
            
            panel.SetActive(false);
            player.Heal(5);
            player.DecreaseHunger(5);
            player.DecreaseWellBeing(20);
            timeControllerScript.AddHoursToTime(1);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option32.onClick.AddListener(() => { 
            Debug.Log("Selected Watch newest WK film"); 
            panel.SetActive(false);
            player.Heal(3);
            player.DecreaseHunger(5);
            player.IncreaseWellBeing(5);
            timeControllerScript.AddHoursToTime(0.4);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        return true;
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
    void Update()
    {
        if (counter > 0)
        {
            counter--;
        }
        else if (counter == 0)
        {
            errorPrompt.gameObject.SetActive(false);
        }
    }

}
