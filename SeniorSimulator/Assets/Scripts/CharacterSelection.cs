using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;
    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[2];
        // Wype³nianie tablicy modelami
        for (int i = 0; i < 2; i++)
            characterList[i] = transform.GetChild(i).gameObject;

        // wy³¹czanie renderera modeli
        foreach (GameObject go in characterList)
            go.SetActive(false);
        
        // W³¹czenie wybranego modelu
        if (characterList[index])
            characterList[index].SetActive(true);
        
    }

    public void ToggleLeft()
    {
        // Wy³¹cz aktualny model
        characterList[index].SetActive(false);


        index--;
        if(index < 0)
        {
            index = characterList.Length - 1;
        }


        // W³¹cz nowy model
        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        // Wy³¹cz aktualny model
        characterList[index].SetActive(false);


        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }


        // W³¹cz nowy model
        characterList[index].SetActive(true);
    }

    public void ChangeScene()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene(2);
    }
}
