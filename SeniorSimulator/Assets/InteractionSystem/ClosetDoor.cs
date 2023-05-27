using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    private Animator closetDoorAnim;

    private bool closetDoorOpen = false;
    public bool Interact(Interactor interactor)
    {
        PlayAnimation();
        return true;
    }

    private void Awake()
    {
        closetDoorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!closetDoorOpen)
        {
            closetDoorAnim.Play("ClosetDoorOpenAnimation", 0, 0.0f);
            closetDoorOpen = true;
        }
        else
        {
            closetDoorAnim.Play("ClosetDoorCloseAnimation", 0, 0.0f);
            closetDoorOpen = false;
        }
    }
}
