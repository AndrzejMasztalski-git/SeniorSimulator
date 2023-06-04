using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fireplace : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public GameObject panel;
    public GameObject fire;
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
    public Image errorPrompt;
    public Text errorPromptText;
    private int counter = -1;
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
        Debug.Log("Fireplace");
        panel.SetActive(true);
        Time.timeScale = 0;
        if (player.campfire == false)
            option12Text.text = "Light the campfire";
        else option12Text.text = "Put out the fire";
        option22Text.text = "Get warm";
        option32Text.text = "Bake a sausage";
        option12.onClick.AddListener(() =>
        {
            Debug.Log("Light the campfire!");
            panel.SetActive(false);
            if (player.campfire == false)
            {
                player.TakeDamage(5);
                player.IncreaseWellBeing(15);
                fire.gameObject.SetActive(true);
                player.campfire = true;
            }
            else
            {
                player.TakeDamage(5);
                player.DecreaseWellBeing(5);
                fire.gameObject.SetActive(false);
                player.campfire = false;
            }
            timeControllerScript.AddHoursToTime(0.3);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option22.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            if (player.campfire == true)
            {

                Debug.Log("Get warm!");
                player.Heal(5);
                player.IncreaseWellBeing(5);
            }
            else
            {
                Debug.Log("Error Go to the drugstore");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "light the campfire first";
                counter = 500;
            }
            timeControllerScript.AddHoursToTime(0.5);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option32.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            if (player.food > 0)
            {
                Debug.Log("Bake a sausage!");
                player.food -= 1;
                player.Heal(5);
                player.IncreaseWellBeing(5);
                timeControllerScript.AddHoursToTime(0.8);
            }
            else
            {
                Debug.Log("Error Bake a sausage!");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "no ingredients";
                counter = 500;

            }
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