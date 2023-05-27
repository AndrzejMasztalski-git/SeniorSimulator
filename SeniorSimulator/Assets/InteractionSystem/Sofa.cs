using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sofa : MonoBehaviour, IInteractable
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
    public Text option22Text;
    public Text option32Text;
    public Player player;

    public bool Interact(Interactor interactor)
    {
        interactionPrompt.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        option11.gameObject.SetActive(false);
        option12.gameObject.SetActive(true);
        option13.gameObject.SetActive(false);
        option21.gameObject.SetActive(false);
        option22.gameObject.SetActive(true);
        option23.gameObject.SetActive(false);
        option31.gameObject.SetActive(false);
        option32.gameObject.SetActive(true);
        option33.gameObject.SetActive(false);
        Debug.Log("Sofa");
        panel.SetActive(true);
        option12Text.text = "Read newspaper";
        option22Text.text = "Take a nap";
        option32Text.text = "Solve a crossword puzzle";
        option12.onClick.AddListener(() => { Debug.Log("Selected Read newspaper"); panel.SetActive(false); player.TakeDamage(10); });
        option21.onClick.AddListener(() => { Debug.Log("Selected Take a nap"); panel.SetActive(false); player.Heal(40); });
        option22.onClick.AddListener(() => { Debug.Log("Selected Solve a crossword puzzle"); panel.SetActive(false); player.Heal(20); });
        interactionPrompt.gameObject.SetActive(true);
        return true;
    }
}

