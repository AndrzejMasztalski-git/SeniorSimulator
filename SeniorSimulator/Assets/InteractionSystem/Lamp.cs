using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lamp : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public GameObject lamp;
    public AudioSource audioSource;
    public AudioClip lampSound;


    public bool Interact(Interactor interactor)
    {
        if (lamp.gameObject.activeSelf)
        {
            audioSource.PlayOneShot(lampSound, 0.3f);
            lamp.gameObject.SetActive(false);
        }
        else
        {
            audioSource.PlayOneShot(lampSound, 0.3f);
            lamp.gameObject.SetActive(true);
        }
        return true;

    }
}
