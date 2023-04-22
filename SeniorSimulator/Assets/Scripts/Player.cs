using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public CharacterDatabase characterDB;
    //public SpriteRenderer artworkSprite;

    private int selectedOption = 0;


    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }

        //UpdateCharacter(selectedOption);

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }


    //private void UpdateCharacter(int selectedOption)
    //{
    //    Character character = characterDB.GetCharacter(selectedOption);

    //    artworkSprite.sprite = character.characterSprite;
        
    //}

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}