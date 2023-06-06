using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    private Animator entryDoorAnim;

    private bool entryDoorOpen = false;
    public bool Interact(Interactor interactor)
    {
        PlayAnimation();
        return true;
    }

    private void Awake()
    {
        entryDoorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!entryDoorOpen)
        {
            entryDoorAnim.Play("EntryDoorOpenAnimation", 0, 0.0f);
            entryDoorOpen = true;
        }
        else
        {
            entryDoorAnim.Play("EntryDoorCloseAnimation", 0, 0.0f);
            entryDoorOpen = false;
        }
    }
}
