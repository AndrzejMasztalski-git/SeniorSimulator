using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bed : MonoBehaviour, IInteractable
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
        Debug.Log("Bed");
        panel.SetActive(true);
        Time.timeScale = 0;
        option12Text.text = "Sleep";
        option22Text.text = "Take a nap";
        option32Text.text = "Hanky-panky";
        option12.onClick.AddListener(() =>
        {
            Debug.Log("Sleep!");
            panel.SetActive(false);
            player.Heal(100);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option12.onClick.RemoveAllListeners();
        });
        option22.onClick.AddListener(() => {
            Debug.Log("Take a nap");
            panel.SetActive(false);
            player.Heal(30);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option22.onClick.RemoveAllListeners();
        });
        option32.onClick.AddListener(() => {
            Debug.Log("Hanky-panky");
            panel.SetActive(false);
            player.TakeDamage(20);
            player.IncreaseWellBeing(100);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option32.onClick.RemoveAllListeners();
        });
        return true;

    }
}
