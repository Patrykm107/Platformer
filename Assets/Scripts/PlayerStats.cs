using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public const int MAX_HEALTH = 5;

    [Range(0, MAX_HEALTH)][SerializeField] private static int health = 3;
    [SerializeField] private static int money = 0;
    [SerializeField] private float timeImmue = 3f;
    private float singleFlash = 0.1f;

    public int playerHealth { get { return health; } }
    public int playerMoney { get { return money; } }

    private bool canTakeDamage = true;

    void Awake()
    {
        health = 3;
        money = 0;
    }

    public void takeDamage(int amount = 1)
    {
        if (canTakeDamage)
        {
            health -= amount;

            if (health < 0)
            {
                health = 0;
            }

            if (health > MAX_HEALTH)
            {
                health = MAX_HEALTH;
            }

            StartCoroutine(flash());
        }
    }

    public void addMoney(int amount = 1)
    {
        money += amount;
    }

    IEnumerator flash()
    {
        canTakeDamage = false;
        Renderer renderer = GetComponent<Renderer>();

        for (int i = 0; i < timeImmue / (2 * singleFlash); i++)
        {
            renderer.enabled = false;
            yield return new WaitForSeconds(singleFlash);
            renderer.enabled = true;
            yield return new WaitForSeconds(singleFlash);
        }

        canTakeDamage = true;
    }
}
