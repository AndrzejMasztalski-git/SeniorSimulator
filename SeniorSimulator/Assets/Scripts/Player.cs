using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    public WellBeingBar wellBeingBar;
    public int maxWellBeing = 100;
    public int currentWellBeing;
    
    public HungerBar hungerBar;
    public int maxHunger = 100;
    public int currentHunger;

    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;
    
    public bool campfire = false;

    //FRIDGE
    public bool shoppingList = false;
    public bool doctor_drugstore = false;
    public int beer = 2;
    public int food = 6;
    //GATEWAY
    public bool church = false;
    public bool doctor_visit = false;
    //BED
    public DateTime lastTimeWokeUp;
    public bool nap = false;
    //KITCHEN
    public int dirt = 0;
    //WARDROBE
    public bool pajamas = false;
    public int clean_cloaths = 3;

    
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        currentHealth = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    void Start()
    {
        lastTimeWokeUp = DateTime.Now.Date + TimeSpan.FromHours(5);
        Debug.Log(lastTimeWokeUp.ToString("MM/dd/yyyy HH:mm:ss"));
        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);

        currentWellBeing = maxWellBeing;
        wellBeingBar.SetMaxWellBeing(maxWellBeing);

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        else
        {
            healthBar.SetHealth(currentHealth);
        }
    }

    public void Heal(int health)
    {
        currentHealth += health;
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
        else
        {
            healthBar.SetHealth(currentHealth);
        }
    }


    public void DecreaseWellBeing(int amountToDecrease)
    {
        currentWellBeing -= amountToDecrease;
        if (currentWellBeing < 0)
        {
            currentWellBeing = 0;
        }
        else
        {
            wellBeingBar.SetWellBeing(currentWellBeing);
        }
    }

    public void IncreaseWellBeing(int amountToIncrease)
    {
        currentWellBeing += amountToIncrease;
        if(currentWellBeing > 100)
        {
            currentWellBeing = 100;
        }
        else
        {
            wellBeingBar.SetWellBeing(currentWellBeing);
        }
        
    }

    public void DecreaseHunger(int amountToDecrease)
    {
        currentHunger -= amountToDecrease;
        if (currentHunger < 0)
        {
            currentHunger = 0;
        }
        else
        {
            hungerBar.SetHunger(currentHunger);
        }
    }

    public void IncreaseHunger(int amountToIncrease)
    {
        currentHunger += amountToIncrease;
        if (currentHunger > 100)
        {
            currentHunger = 100;
        }
        else
        {
            hungerBar.SetHunger(currentHunger);
        }

    }
}