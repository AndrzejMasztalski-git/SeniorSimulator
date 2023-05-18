using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandling : MonoBehaviour
{

    public GameObject panel;
    Button button;
    private void OnMouseDown()
    {
        button.onClick.AddListener(() => { panel.SetActive(false); });
        
    }
}
