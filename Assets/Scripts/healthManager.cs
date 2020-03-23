using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour
{
    [SerializeField] private GameObject healthGrid;
    [SerializeField] private GameObject healthIconPrefab;

    private List<GameObject> healthIcons = new List<GameObject>();

    private PlayerStats playerStats;

    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        for(int i = 0; i < PlayerStats.MAX_HEALTH; i++)
        {
            healthIcons.Add(Instantiate(healthIconPrefab, healthGrid.transform, false));
        }
    }

    void Update()
    {
        int health = playerStats.playerHealth;

        healthIcons.GetRange(0, health).ForEach(
            icon =>
            {
                if (!icon.activeSelf)
                {
                    icon.SetActive(true);
                }
            });

        healthIcons.GetRange(health, healthIcons.Count - health).ForEach(
            icon =>
            {
                if (icon.activeSelf)
                {
                    icon.SetActive(false);
                }
            });

        if(health <= 0)
        {
            GetComponent<InGameMenu>().LoseGame();
        }
    }
}
