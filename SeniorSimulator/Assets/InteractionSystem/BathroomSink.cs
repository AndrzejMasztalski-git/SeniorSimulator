using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BathroomSink : MonoBehaviour, IInteractable
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

    public Image errorPrompt;
    public Text errorPromptText;
    public int counter = -1;

    public AudioSource audioSource;
    public AudioClip washingHandsSound;
    public AudioClip brushingSound;
    public AudioClip admiringSound;

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
        option12Text.text = "Wash your hands";
        option22Text.text = "Clean the false teeth";
        option32Text.text = "Admire your face in the mirror";
        option12.onClick.AddListener(() =>
        {
            audioSource.PlayOneShot(washingHandsSound, 0.2f);
            Debug.Log("Wash your hands!");
            panel.SetActive(false);
            player.TakeDamage(2);
            player.DecreaseHunger(1);
            player.IncreaseWellBeing(3);
            timeControllerScript.AddHoursToTime(0.1);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option22.onClick.AddListener(() => {
            audioSource.PlayOneShot(brushingSound, 0.2f);
            Debug.Log("Clean the false teeth!");
            panel.SetActive(false);
            player.TakeDamage(1);
            player.DecreaseHunger(2);
            player.IncreaseWellBeing(3);
            timeControllerScript.AddHoursToTime(0.1);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option32.onClick.AddListener(() => {
            audioSource.PlayOneShot(admiringSound, 0.2f);
            Debug.Log("Admire your face in the mirror!");
            player.TakeDamage(0 );
            player.DecreaseHunger(1);
            player.IncreaseWellBeing(1);
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
    }
}
