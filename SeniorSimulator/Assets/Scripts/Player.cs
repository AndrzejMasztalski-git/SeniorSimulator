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

    
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool campfire = false;

    //FRIDGE
    public bool shoppingList = false;
    public int beer = 2;
    public int food = 10;
    void Start()
    {
        


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
}