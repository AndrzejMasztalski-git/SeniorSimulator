using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flowers : MonoBehaviour, IInteractable
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
    public Image image;
    public Canvas interactionPrompt;
    public Text option12Text;
    public Text option22Text;
    public Text option32Text;
    public Player player;

    public AudioSource audioSource;
    public AudioClip waterSound;

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
        Debug.Log("Flowers");
        panel.SetActive(true);
        Time.timeScale = 0;
        option12Text.text = "Water flowers";
        option22Text.text = "Collect vegetables";
        option32Text.text = "Remove weeds";
        option12.onClick.AddListener(() => { 
            Debug.Log("Selected water flowers");
            audioSource.PlayOneShot(waterSound, 0.2f);
            panel.SetActive(false);
            player.TakeDamage(10);
            player.DecreaseHunger(3);
            player.IncreaseWellBeing(10);
            timeControllerScript.AddHoursToTime(0.4);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); 
        });
        option22.onClick.AddListener(() => { 
            Debug.Log("Selected collect vegetables"); 
            panel.SetActive(false);
            player.TakeDamage(7);
            player.DecreaseHunger(4);
            player.IncreaseWellBeing(10);
            player.food += 3;
            timeControllerScript.AddHoursToTime(0.6);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); 
        });
        option32.onClick.AddListener(() => { 
            Debug.Log("Selected remove weeds"); 
            panel.SetActive(false);
            player.TakeDamage(10);
            player.DecreaseHunger(5);
            player.IncreaseWellBeing(5);
            timeControllerScript.AddHoursToTime(0.7);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); 
        });
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
}