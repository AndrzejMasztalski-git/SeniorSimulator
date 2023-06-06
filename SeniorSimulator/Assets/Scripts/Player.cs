using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
    public bool doctor = false;
    public int beer = 2;
    public int food = 6;
    void Start()
    {
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