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

    public bool Interact(Interactor interactor)
    {
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
            Debug.Log("Put on pajamas"); 
            panel.SetActive(false); 
            player.IncreaseWellBeing(10); 
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1; 
            option12.onClick.RemoveAllListeners(); });
        option21.onClick.AddListener(() => { 
            Debug.Log("Wear clean clothes"); 
            panel.SetActive(false); 
            player.IncreaseWellBeing(10);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1; 
            option21.onClick.RemoveAllListeners(); });
        option22.onClick.AddListener(() => { 
            Debug.Log("Hide in the closet from your partner"); 
            panel.SetActive(false); 
            player.TakeDamage(5);
            player.IncreaseWellBeing(15);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1; 
            option22.onClick.RemoveAllListeners(); });
        option23.onClick.AddListener(() => { 
            Debug.Log("Clean up in the closet");
            panel.SetActive(false);
            player.IncreaseWellBeing(15);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1; 
            option23.onClick.RemoveAllListeners(); });
        option32.onClick.AddListener(() => { 
            Debug.Log("Try on clothes"); 
            panel.SetActive(false);
            player.Heal(5);
            player.IncreaseWellBeing(5);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1; 
            option32.onClick.RemoveAllListeners(); });
        return true;
    }
}
