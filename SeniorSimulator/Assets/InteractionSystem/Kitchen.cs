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
    public bool Interact(Interactor interactor)
    {
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
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option12.onClick.RemoveAllListeners();
        });
        option12.onClick.AddListener(() =>
        {
            Debug.Log("Bake cake!");
            panel.SetActive(false);
            player.IncreaseWellBeing(10);
            player.Heal(5);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option12.onClick.RemoveAllListeners();
        });
        option13.onClick.AddListener(() =>
        {
            Debug.Log("Make drums out of pots!");
            panel.SetActive(false);
            player.TakeDamage(10);
            player.IncreaseWellBeing(10);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option12.onClick.RemoveAllListeners();
        });
        option21.onClick.AddListener(() =>
        {
            Debug.Log("Make popcorn!");
            panel.SetActive(false);
            player.IncreaseWellBeing(10);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option12.onClick.RemoveAllListeners();
        });
        option22.onClick.AddListener(() =>
        {
            Debug.Log("Pretend you're cooking!");
            panel.SetActive(false);
            player.Heal(5);
            player.DecreaseWellBeing(10);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option12.onClick.RemoveAllListeners();
        });
        option23.onClick.AddListener(() =>
        {
            Debug.Log("Pretend you're in masterchef!");
            panel.SetActive(false);
            player.IncreaseWellBeing(10);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option12.onClick.RemoveAllListeners();
        });
        option31.onClick.AddListener(() =>
        {
            Debug.Log("Make sandwiches and talk like Mak³owicz!");
            panel.SetActive(false);
            player.Heal(5);
            player.IncreaseWellBeing(5);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option12.onClick.RemoveAllListeners();
        });
        option32.onClick.AddListener(() =>
        {
            Debug.Log("Just prepare a meal!");
            panel.SetActive(false);
            player.Heal(10);
            player.IncreaseWellBeing(5);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option12.onClick.RemoveAllListeners();
        });
        option33.onClick.AddListener(() =>
        {
            Debug.Log("Make a shopping list!");
            player.shoppingList = true;
            panel.SetActive(false);
            player.IncreaseWellBeing(5);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            option12.onClick.RemoveAllListeners();
        });
        return true;

    }
}
