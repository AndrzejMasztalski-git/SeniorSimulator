using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fridge : MonoBehaviour, IInteractable
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

    public Image errorPrompt;
    public Text errorPromptText;
    public int counter = -1;

    public AudioSource audioSource;
    public AudioClip drinkingBeerSound;
    public AudioClip eatSound;
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
        Debug.Log("Opening fridge");
        panel.SetActive(true);
        Time.timeScale = 0;
        option12Text.text = "Just open and look at food";
        option22Text.text = "Eat something";
        option32Text.text = "Drink beer";
        option12.onClick.AddListener(() => 
        {   Debug.Log("Just open and look at food!"); 
            panel.SetActive(false);
            player.DecreaseWellBeing(10);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners();
            });
        option22.onClick.AddListener(() => {
            panel.SetActive(false);
            if (player.food > 0)
            {
                audioSource.PlayOneShot(eatSound, 0.2f);
                Debug.Log("Eating something");
                player.food--;
                player.Heal(5);
                player.IncreaseHunger(10);
                player.IncreaseWellBeing(5);
                timeControllerScript.AddHoursToTime(0.1);
            }
            else
            {
                Debug.Log("Error Eating something");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "No food in the fridge!";
                counter = 500;
            }
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option32.onClick.AddListener(() => { 
            panel.SetActive(false);
            if (player.beer > 0)
            {
                audioSource.PlayOneShot(drinkingBeerSound, 0.2f);
                Debug.Log("Drinking beer");
                player.beer--;
                player.TakeDamage(1);
                player.DecreaseHunger(5);
                player.IncreaseWellBeing(10);
                timeControllerScript.AddHoursToTime(0.1);
            }
            else
            {
                Debug.Log("Error Drinking beer");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "No beer in the fridge!";
                counter = 500;
            }
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
