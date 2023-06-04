using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GardenHouse : MonoBehaviour, IInteractable
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
        Debug.Log("Gateway Interaction");
        panel.SetActive(true);
        Time.timeScale = 0;
        option12Text.text = "Hide from your partner";
        option21Text.text = "Tinker";
        option22Text.text = "Clean up in the gazebo";
        option23Text.text = "Meditate";
        option32Text.text = "Listen to the music";
        option12.onClick.AddListener(() => { 
            Debug.Log("Hide from your partner"); 
            panel.SetActive(false);
            player.Heal(10);
            player.IncreaseWellBeing(5);
            timeControllerScript.AddHoursToTime(1);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option21.onClick.AddListener(() => { 
            Debug.Log("Tinker"); 
            panel.SetActive(false); 
            player.TakeDamage(10);
            player.IncreaseWellBeing(20);
            timeControllerScript.AddHoursToTime(1.8);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option22.onClick.AddListener(() => { 
            Debug.Log("Clean up in the gazebo"); panel.SetActive(false); 
            player.TakeDamage(5);
            player.IncreaseWellBeing(10);
            timeControllerScript.AddHoursToTime(1.1);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option23.onClick.AddListener(() => { 
            Debug.Log("Meditate");
            player.Heal(5);
            player.IncreaseWellBeing(10);
            timeControllerScript.AddHoursToTime(0.6);
            panel.SetActive(false);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option32.onClick.AddListener(() => { 
            Debug.Log("Listen to the music");
            player.IncreaseWellBeing(15);
            timeControllerScript.AddHoursToTime(0.9);
            panel.SetActive(false); 
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
}
