using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public const int MAX_HEALTH = 5;

    [Range(0, MAX_HEALTH)][SerializeField] private static int health = 3;
    [SerializeField] private static int money = 0;

    public int playerHealth { get { return health; } }
    public int playerMoney { get { return money; } }
    

    void Awake()
    {
        health = 3;
        money = 0;
    }

    public void takeDamage(int amount = 1)
    {
        health -= amount;

        if (health < 0)
        {
            health = 0;
        }

        if (health > MAX_HEALTH) {
            health = MAX_HEALTH;
        }
    }

    public void addMoney(int amount = 1)
    {
        money += amount;
    }
}
