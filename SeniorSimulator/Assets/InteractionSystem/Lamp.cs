using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lamp : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public GameObject lamp;


    public bool Interact(Interactor interactor)
    {
        if (lamp.gameObject.activeSelf)
        {
            lamp.gameObject.SetActive(false);
        }
        else {
            lamp.gameObject.SetActive(true);
        }
        return true;

    }
}
