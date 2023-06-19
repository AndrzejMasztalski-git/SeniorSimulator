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
    public Button exit;
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

    public AudioSource audioSource;
    public AudioClip drumsSound;
    public AudioClip cleaningSound;
    public AudioClip popcornSound;
    public AudioClip cuttingSound;
    public AudioClip writtingSound;
    public AudioClip backerSound;
    public bool Interact(Interactor interactor)
    {
        GameObject timeController = GameObject.Find("TimeController");
        TimeController timeControllerScript = timeController.GetComponent<TimeController>();

        int acceptable_dirt = 8;

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
        option31Text.text = "Make sandwiches and talk like Mak這wicz";
        option32Text.text = "Just prepare meal";
        option33Text.text = "Make a shopping list";
        option11.onClick.AddListener(() =>
        {
            audioSource.PlayOneShot(cleaningSound, 0.5f);
            Debug.Log("Clean kitchen!");
            panel.SetActive(false);
            player.IncreaseWellBeing(10);
            player.TakeDamage(10);
            timeControllerScript.AddHoursToTime(0.5);
            player.dirt = 0;
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option12.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            if (player.food > 1)
            {
                if (player.dirt < acceptable_dirt)
                {
                    audioSource.PlayOneShot(backerSound, 0.3f);
                    Debug.Log("Bake cake!");
                    player.food -= 2;
                    player.TakeDamage(10);
                    player.IncreaseHunger(15);
                    player.IncreaseWellBeing(5);
                    player.dirt += 2;
                    timeControllerScript.AddHoursToTime(1.5);
                }
                else {
                    Debug.Log("Error Bake cake");
                    errorPrompt.gameObject.SetActive(true);
                    errorPromptText.text = "Kitchen is dirty!";
                    counter = 500;
                }
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
            panel.SetActive(false);
            if (player.dirt < acceptable_dirt)
            {
                audioSource.PlayOneShot(drumsSound, 0.3f);
                Debug.Log("Make drums out of pots!");
                player.TakeDamage(5);
                player.DecreaseHunger(3);
                player.IncreaseWellBeing(8);
                timeControllerScript.AddHoursToTime(0.5);
            }
            else
            {
                Debug.Log("Error Make drums out of pots");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "Kitchen is dirty!";
                counter = 500;
            }
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option21.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            if (player.food > 0)
            {
                if (player.dirt < acceptable_dirt)
                {
                    audioSource.PlayOneShot(popcornSound, 0.3f);
                    Debug.Log("Make popcorn!");
                    player.food -= 1;
                    player.TakeDamage(3);
                    player.IncreaseHunger(5);
                    player.IncreaseWellBeing(5);
                    player.dirt += 1;
                    timeControllerScript.AddHoursToTime(0.2);
                }
                else
                {
                    Debug.Log("Error Make popcorn!");
                    errorPrompt.gameObject.SetActive(true);
                    errorPromptText.text = "Kitchen is dirty!";
                    counter = 500;
                }
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
            panel.SetActive(false);
            if (player.dirt < acceptable_dirt)
            {
                audioSource.PlayOneShot(cuttingSound, 0.2f);
                Debug.Log("Pretend you're cooking!");
                player.TakeDamage(5);
                player.DecreaseHunger(5);
                player.DecreaseWellBeing(5);
                timeControllerScript.AddHoursToTime(0.5);
                player.dirt += 1;
            }
            else
            {
                Debug.Log("Error Pretend you're cooking!");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "Kitchen is dirty!";
                counter = 500;
            }
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option23.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            if (player.food > 2)
            {
                if (player.dirt < acceptable_dirt)
                {
                    Debug.Log("Pretend you're in masterchef!");
                    player.food -= 3;
                    player.dirt += 3;
                    player.TakeDamage(5);
                    player.IncreaseHunger(15);
                    player.IncreaseWellBeing(15);
                    timeControllerScript.AddHoursToTime(1);
                }
                else
                {
                    Debug.Log("Error Pretend you're in masterchef!");
                    errorPrompt.gameObject.SetActive(true);
                    errorPromptText.text = "Kitchen is dirty!";
                    counter = 500;
                }
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
                if (player.dirt < acceptable_dirt)
                {
                    Debug.Log("Make sandwiches and talk like Mak這wicz!");
                    player.food -= 1;
                    player.TakeDamage(5);
                    player.IncreaseHunger(10);
                    player.IncreaseWellBeing(10);
                    player.dirt += 1;
                    timeControllerScript.AddHoursToTime(0.5);
                }
                else
                {
                    Debug.Log("Error Make sandwiches and talk like Mak這wicz!");
                    errorPrompt.gameObject.SetActive(true);
                    errorPromptText.text = "Kitchen is dirty!";
                    counter = 500;
                }
            }
            else
            {
                Debug.Log("Error Make sandwiches and talk like Mak這wicz!");
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
                if (player.dirt < acceptable_dirt)
                {
                    audioSource.PlayOneShot(drumsSound, 0.1f);
                    audioSource.PlayOneShot(cuttingSound, 0.2f);
                    Debug.Log("Just prepare a meal!");
                    player.food -= 2;
                    player.dirt += 2;
                    player.TakeDamage(5);
                    player.IncreaseHunger(15);
                    player.IncreaseWellBeing(5);
                    timeControllerScript.AddHoursToTime(1);
                }
                else
                {
                    Debug.Log("Error Just prepare a meal!");
                    errorPrompt.gameObject.SetActive(true);
                    errorPromptText.text = "Kitchen is dirty!";
                    counter = 500;
                }
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
            panel.SetActive(false);
            if (player.dirt < acceptable_dirt)
            {
                audioSource.PlayOneShot(writtingSound, 0.3f);
                Debug.Log("Make a shopping list!");
                player.shoppingList = true;
                timeControllerScript.AddHoursToTime(0.5);
            }
            else
            {
                Debug.Log("Error Make a shopping list!");
                errorPrompt.gameObject.SetActive(true);
                errorPromptText.text = "Kitchen is dirty!";
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
