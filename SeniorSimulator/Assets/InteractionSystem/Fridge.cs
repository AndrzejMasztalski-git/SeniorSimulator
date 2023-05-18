using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fridge : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public GameObject panel;
    public Button option1;
    public Button option2;
    public Button option3;
    public Text option1Text;
    public Text option2Text;
    public Text option3Text;
    public Player player;
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Opening fridge");
        panel.SetActive(true);
        option1Text.text = "Drink water";
        option2Text.text = "Eat something";
        option3Text.text = "Drink beer";
        option1.onClick.AddListener(() => { Debug.Log("Drinking water!"); panel.SetActive(false); player.Heal(10); });
        option2.onClick.AddListener(() => { Debug.Log("Eating something"); panel.SetActive(false); player.Heal(20); });
        option3.onClick.AddListener(() => { Debug.Log("Drinking beer"); panel.SetActive(false); player.TakeDamage(10); });
        return true;
    }
}
