using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitControl : MonoBehaviour
{
    public GameObject theNPC;
    void Update()
    {
        if (Input.GetButtonDown("Sit"))
        {
            theNPC.GetComponent<Animator>().Play("Armature_sitting");
        }
    }
}