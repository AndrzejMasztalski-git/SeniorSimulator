using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shower : MonoBehaviour, IInteractable
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
        Debug.Log("Entering Bath");
        panel.SetActive(true);
        Time.timeScale = 0;
        option12Text.text = "Quick shower";
        option22Text.text = "Shower and sing";
        option32Text.text = "Take a bath";
        option12.onClick.AddListener(() =>
        {
            Debug.Log("Quick shower!");
            panel.SetActive(false);
            player.TakeDamage(3);
            player.DecreaseHunger(2);
            player.IncreaseWellBeing(5);
            timeControllerScript.AddHoursToTime(0.2);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option22.onClick.AddListener(() => {
            panel.SetActive(false);
            
            Debug.Log("Shower and sing");
            player.TakeDamage(3);
            player.DecreaseHunger(5);
            player.IncreaseWellBeing(10);
            timeControllerScript.AddHoursToTime(0.5);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option32.onClick.AddListener(() => {
            panel.SetActive(false);
            
            Debug.Log("Take a bath");
            player.TakeDamage(3);
            player.DecreaseHunger(8);
            player.IncreaseWellBeing(13);
            timeControllerScript.AddHoursToTime(0.9);

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
