using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    

    public bool Interact(Interactor interactor)
    {
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
        option23Text.text = "Meet with firends";
        option32Text.text = "Go to the doctor";
        option12.onClick.AddListener(() => {
            Debug.Log("Go to the Church");
            panel.SetActive(false);
            player.Heal(20);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option12.onClick.RemoveAllListeners(); });
        option21.onClick.AddListener(() => {
            Debug.Log("Go to the grocery shop");
            panel.SetActive(false);
            if (player.shoppingList == true) {
                Debug.Log("Go to the grocery shop");
                player.TakeDamage(20);
                player.shoppingList = false;
                player.beer = 3;
                player.food = 8;
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
                option21.onClick.RemoveAllListeners();
            });
        option22.onClick.AddListener(() => {
            panel.SetActive(false);
            if (player.doctor == true)
            {
                Debug.Log("Go to the drugstore");
                player.doctor = false;
                player.TakeDamage(10);
            }
            else
            {
                Debug.Log("Error Go to the drugstore");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "go to the doctor first";
                counter = 500;

            }
            player.TakeDamage(10);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option22.onClick.RemoveAllListeners(); });
        option23.onClick.AddListener(() => {
            Debug.Log("Meet with firends");
            panel.SetActive(false);
            player.TakeDamage(20);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option23.onClick.RemoveAllListeners(); });
        option32.onClick.AddListener(() => {
            Debug.Log("Go to the doctor");
            player.doctor = true;
            panel.SetActive(false);
            player.Heal(50);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option32.onClick.RemoveAllListeners(); });
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
        }
    }

}
