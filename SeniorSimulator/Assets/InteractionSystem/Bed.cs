using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class Bed : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public GameObject panel;
    public Button option12;
    public Button option22;
    public Button option32;
    public Button option11;
    public Button option13;
    public Button option21;
    public Button option23;
    public Button option31;
    public Button option33;
    public Button exit;
    public Image image;
    public Canvas interactionPrompt;
    public Text option12Text;
    public Text option22Text;
    public Text option32Text;
    public Player player;
    private int counter = -1;
    public Image errorPrompt;
    public Text errorPromptText;
    
    public bool Interact(Interactor interactor)
    {
        GameObject timeController = GameObject.Find("TimeController");
        TimeController timeControllerScript = timeController.GetComponent<TimeController>();

        interactionPrompt.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        option11.gameObject.SetActive(false);
        option13.gameObject.SetActive(false);
        option21.gameObject.SetActive(false);
        option23.gameObject.SetActive(false);
        option31.gameObject.SetActive(false);
        option33.gameObject.SetActive(false);
        option12.gameObject.SetActive(true);
        option22.gameObject.SetActive(true);
        option32.gameObject.SetActive(true);
        Debug.Log("Bed");
        panel.SetActive(true);
        Time.timeScale = 0;
        option12Text.text = "Sleep";
        option22Text.text = "Take a nap";
        option32Text.text = "Hanky-panky";
        option12.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            var diffOfDates = (DateTime.Now.Date + TimeSpan.FromHours(timeControllerScript.GetHour())) - player.lastTimeWokeUp;
            Debug.Log(diffOfDates.Days + "  " + diffOfDates.Hours);
            if (diffOfDates.Days > 0 || diffOfDates.Hours > 12)
            {
                if (player.pajamas == true)
                {
                    Debug.Log("Sleep!");
                    player.Heal(50);
                    player.DecreaseHunger(20);
                    player.IncreaseWellBeing(20);
                    timeControllerScript.AddHoursToTime(8);
                    player.lastTimeWokeUp = DateTime.Now.Date + TimeSpan.FromHours(timeControllerScript.GetHour());
                    player.church = false;
                    player.doctor_visit = false;
                    player.nap = false;
                    player.pajamas = false;
                    player.clean_cloaths++;
                }
                else
                {
                    Debug.Log("Error Sleep1!");
                    errorPrompt.gameObject.SetActive(true);
                    errorPromptText.text = "Put on pajamas first";
                    counter = 500;
                }
            }
            else
            {
                Debug.Log("Error Sleep2!");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "You are not tired enough!";
                counter = 500;
            }
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();

        });
        option22.onClick.AddListener(() => {
            if (player.nap == false)
            {
                Debug.Log("Take a nap");
                player.Heal(20);
                player.DecreaseHunger(10);
                player.IncreaseWellBeing(15);
                timeControllerScript.AddHoursToTime(1.5);
                player.nap = true;
            }
            else
            {
                Debug.Log("Error Take a nap!");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "You already took a nap!";
                counter = 500;
            }
            panel.SetActive(false);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option32.onClick.AddListener(() => {
            panel.SetActive(false);
            System.Random r = new System.Random();
            int rInt = r.Next(0, 10);
            if (rInt > 6)
            {
                Debug.Log("Hanky-panky");
                player.TakeDamage(10);
                player.DecreaseHunger(10);
                player.IncreaseWellBeing(50);
                timeControllerScript.AddHoursToTime(0.3);
            }
            else {
                Debug.Log("Error Hanky-panky!");
                errorPrompt.gameObject.SetActive(true);
                player.DecreaseWellBeing(10);
                errorPromptText.text = "Your partner has an headache, but nice try!";
                counter = 500;
            }
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        exit.onClick.AddListener(() => {
            panel.SetActive(false);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
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
        exit.onClick.RemoveAllListeners();
    }
}
