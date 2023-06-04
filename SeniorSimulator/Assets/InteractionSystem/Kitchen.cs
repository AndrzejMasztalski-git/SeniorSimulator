using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kitchen : MonoBehaviour, IInteractable
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
    public Text option11Text;
    public Text option12Text;
    public Text option13Text;
    public Text option21Text;
    public Text option22Text;
    public Text option23Text;
    public Text option31Text;
    public Text option32Text;
    public Text option33Text;
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
        option11.gameObject.SetActive(true);
        option12.gameObject.SetActive(true);
        option13.gameObject.SetActive(true);
        option21.gameObject.SetActive(true);
        option22.gameObject.SetActive(true);
        option23.gameObject.SetActive(true);
        option31.gameObject.SetActive(true);
        option32.gameObject.SetActive(true);
        option33.gameObject.SetActive(true);
        Debug.Log("Kitchen interaction");
        panel.SetActive(true);
        Time.timeScale = 0;
        option11Text.text = "Clean kitchen";
        option12Text.text = "Bake cake";
        option13Text.text = "Make drums out of pots";
        option21Text.text = "Make popcorn";
        option22Text.text = "Pretend you're cooking";
        option23Text.text = "Pretend you're in masterchef";
        option31Text.text = "Make sandwiches and talk like Mak³owicz";
        option32Text.text = "Just prepare meal";
        option33Text.text = "Make a shopping list";
        option11.onClick.AddListener(() =>
        {
            Debug.Log("Clean kitchen!");
            panel.SetActive(false);
            player.IncreaseWellBeing(20);
            player.TakeDamage(10);
            timeControllerScript.AddHoursToTime(0.5);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option12.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            if (player.food > 1)
            {
                Debug.Log("Bake cake!");
                player.food -= 2;
                player.IncreaseWellBeing(10);
                player.Heal(5);
                timeControllerScript.AddHoursToTime(1.5);
            }
            else
            {
                Debug.Log("Error Bake cake");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "no ingredients";
                counter = 500;

            }
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option13.onClick.AddListener(() =>
        {
            Debug.Log("Make drums out of pots!");
            panel.SetActive(false);
            player.TakeDamage(10);
            player.IncreaseWellBeing(10);
            timeControllerScript.AddHoursToTime(0.5);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option21.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            if (player.food > 0)
            {
                Debug.Log("Make popcorn!");
                player.food -= 1;
                player.IncreaseWellBeing(10);
                timeControllerScript.AddHoursToTime(0.2);
            }
            else
            {
                Debug.Log("Error Make popcorn!");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "no ingredients";
                counter = 500;

            }
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option22.onClick.AddListener(() =>
        {
            Debug.Log("Pretend you're cooking!");
            panel.SetActive(false);
            player.TakeDamage(5);
            player.IncreaseWellBeing(10);
            timeControllerScript.AddHoursToTime(0.5);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option23.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            if (player.food > 2)
            {
                Debug.Log("Pretend you're in masterchef!");
                player.food -= 3;
                player.IncreaseWellBeing(10);
                timeControllerScript.AddHoursToTime(1);
            }
            else
            {
                Debug.Log("Error Pretend you're in masterchef!");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "no ingredients";
                counter = 500;

            }
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option31.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            if (player.food > 0)
            {
                Debug.Log("Make sandwiches and talk like Mak³owicz!");
                player.food -= 1;
                player.Heal(5);
                player.IncreaseWellBeing(5);
                timeControllerScript.AddHoursToTime(0.5);
            }
            else
            {
                Debug.Log("Error Make sandwiches and talk like Mak³owicz!");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "no ingredients";
                counter = 500;

            }
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option32.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            if (player.food > 1)
            {
                Debug.Log("Just prepare a meal!");
                player.food -= 2;
                player.Heal(5);
                player.IncreaseWellBeing(5);
                timeControllerScript.AddHoursToTime(1);
            }
            else
            {
                Debug.Log("Error Just prepare a meal!");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "no ingredients";
                counter = 500;
            }
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option33.onClick.AddListener(() =>
        {
            Debug.Log("Make a shopping list!");
            player.shoppingList = true;
            panel.SetActive(false);
            timeControllerScript.AddHoursToTime(0.5);
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
