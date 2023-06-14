using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wardrobe : MonoBehaviour, IInteractable
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
        option12Text.text = "Put on pajamas";
        option21Text.text = "Wear clean clothes";
        option22Text.text = "Hide in the closet from your partner";
        option23Text.text = "Clean up in the closet";
        option32Text.text = "Try on clothes";
        option12.onClick.AddListener(() => {
            panel.SetActive(false);
            if (player.pajamas == false)
            {
                Debug.Log("Put on pajamas");
                player.Heal(0);
                player.IncreaseHunger(0);
                player.IncreaseWellBeing(5);
                timeControllerScript.AddHoursToTime(0.15);
                player.pajamas = true;
            }
            else
            {
                Debug.Log("Error Put on pajamas!");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "You already have pajamas on!";
                counter = 500;
            }
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option21.onClick.AddListener(() => {
            panel.SetActive(false);
            if (player.clean_cloaths > 0)
            {
                Debug.Log("Wear clean clothes");
                player.Heal(0);
                player.DecreaseHunger(0);
                player.IncreaseWellBeing(5);
                timeControllerScript.AddHoursToTime(0.15);
                player.clean_cloaths--;
            }
            else
            {
                Debug.Log("Error Wear clean clothes!");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "You dont have clean cloaths!";
                counter = 500;
            }
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option22.onClick.AddListener(() => { 
            Debug.Log("Hide in the closet from your partner"); 
            panel.SetActive(false);
            player.Heal(10);
            player.DecreaseHunger(15);
            player.IncreaseWellBeing(5);
            timeControllerScript.AddHoursToTime(1);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option23.onClick.AddListener(() => { 
            Debug.Log("Clean up in the closet");
            panel.SetActive(false);
            player.TakeDamage(5);
            player.DecreaseHunger(5);
            player.IncreaseWellBeing(10);
            timeControllerScript.AddHoursToTime(0.4);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option32.onClick.AddListener(() => { 
            Debug.Log("Try on clothes"); 
            panel.SetActive(false);
            player.TakeDamage(3);
            player.IncreaseHunger(3);
            player.IncreaseWellBeing(5);
            timeControllerScript.AddHoursToTime(0.3);
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
            counter = -1;
        }
    }
}
