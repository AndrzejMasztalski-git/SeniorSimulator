using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyClosetDoorController : MonoBehaviour
{
    private Animator closetDoorAnim;

    private bool closetDoorOpen = false;

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