using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Gateway : MonoBehaviour, IInteractable
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
    public Button exit;
    public Image image;
    public Canvas interactionPrompt;
    public Image errorPrompt;
    public Text errorPromptText;
    public Text option12Text;
    public Text option21Text;
    public Text option22Text;
    public Text option23Text;
    public Text option32Text;
    public Player player;
    private int counter = -1;
    public AudioSource audioSource;
    public AudioClip churchSound;
    public AudioClip doctorSound;
    public AudioClip shopSound;
    public AudioClip friendSound;



    public bool Interact(Interactor interactor)
    {
        GameObject timeController = GameObject.Find("TimeController");
        TimeController timeControllerScript = timeController.GetComponent<TimeController>();
        int h = timeControllerScript.GetHour();
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
        Debug.Log("Gateway Interaction");
         
        panel.SetActive(true);
        Time.timeScale = 0;
        option12Text.text = "Go to the Church";
        option21Text.text = "Go to the grocery shop";
        option22Text.text = "Go to the drugstore";
        option23Text.text = "Go fishing with friends";
        option32Text.text = "Go to the doctor";

        option12.onClick.AddListener(() => {
            if ((h >= 6 && h <= 10) || (h >= 16 && h <= 19))
            {
                if (player.church == false)
                {
                    audioSource.PlayOneShot(churchSound, 0.2f);
                    Debug.Log("Go to the Church");
                    player.TakeDamage(5);
                    player.DecreaseHunger(10);
                    player.IncreaseWellBeing(20);
                    timeControllerScript.AddHoursToTime(2.0);
                }
                else
                {
                    Debug.Log("Error Go to the Church");
                    errorPrompt.gameObject.SetActive(true);
                    errorPromptText.text = "You were in the church today!";
                    counter = 500;
                }
            }
            else {
                Debug.Log("Error Go to the Church");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "There is no Holy Mass now!";
                counter = 500;
            }
            panel.SetActive(false);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners(); });

        option21.onClick.AddListener(() => {
            Debug.Log("Go to the grocery shop");
            panel.SetActive(false);
            if (player.shoppingList == true) {
                if (h >= 6 && h <= 22)
                {
                    audioSource.PlayOneShot(shopSound, 0.2f);
                    Debug.Log("Go to the grocery shop");
                    player.TakeDamage(10);
                    player.DecreaseHunger(5);
                    player.IncreaseWellBeing(15);
                    player.shoppingList = false;
                    player.beer += 5;
                    player.food += 10;
                    timeControllerScript.AddHoursToTime(1.5);
                }
                else
                {
                    Debug.Log("Error Go to the grocery shop");
                    errorPrompt.gameObject.SetActive(true);
                    errorPromptText.text = "Shop is closed now!";
                    counter = 500;
                }
            }
            else
            {
                Debug.Log("Error Go to the grocery shop");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "do shopping list first";
                counter = 500;
            }
                interactionPrompt.gameObject.SetActive(true);
                Time.timeScale = 1;
            RemoveListeners();
            });

        option22.onClick.AddListener(() => {
            if (player.doctor_drugstore == true)
            {
                if (h >= 6 && h <= 22)
                {
                    audioSource.PlayOneShot(shopSound, 0.2f);
                    Debug.Log("Go to the drugstore");
                    player.doctor_drugstore = false;
                    player.TakeDamage(5);
                    player.DecreaseHunger(3);
                    player.IncreaseWellBeing(5);
                    timeControllerScript.AddHoursToTime(0.75);
                }
                else
                {
                    Debug.Log("Error Go to the drugstore");
                    errorPrompt.gameObject.SetActive(true);
                    errorPromptText.text = "Drug store is closed now!";
                    counter = 500;
                }
            }
            else
            {
                Debug.Log("Error Go to the drugstore");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "go to the doctor first";
                counter = 500;
            }
            panel.SetActive(false);
            player.TakeDamage(10);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners(); });

        option23.onClick.AddListener(() => {
        if (h >= 10 && h <= 18)
        {
                audioSource.PlayOneShot(friendSound, 0.2f);
                Debug.Log("Meet with firends");
                player.TakeDamage(15);
                player.DecreaseHunger(10);
                player.IncreaseWellBeing(30);
                timeControllerScript.AddHoursToTime(3);
        }
        else
        {
                Debug.Log("Error Meet with firends");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "No friends avalilable right now!";
                counter = 500;
            }
            panel.SetActive(false);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners(); 
        });

        option32.onClick.AddListener(() => {
        if (h >= 10 && h <= 18)
        {
                if (player.doctor_visit == false)
                {
                    audioSource.PlayOneShot(doctorSound, 0.2f);
                    Debug.Log("Go to the doctor");
                    timeControllerScript.AddHoursToTime(3);
                    player.doctor_drugstore = true;
                    player.doctor_visit = true;
                    player.Heal(50);
                    player.DecreaseHunger(15);
                    player.IncreaseWellBeing(10);
                }
                else
                {
                    Debug.Log("Error Go to the doctor");
                    errorPrompt.gameObject.SetActive(true);
                    errorPromptText.text = "You already went to the doctor today!";
                    counter = 500;
                }
            }
            else
            {
                Debug.Log("Error Go to the doctor");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "Doctor is not available at this time!";
                counter = 500;
            }
            panel.SetActive(false);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners(); });
        exit.onClick.AddListener(() => {
            panel.SetActive(false);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });

        return true;
    }

    
    void Update() {
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
    void RemoveListeners() {
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
