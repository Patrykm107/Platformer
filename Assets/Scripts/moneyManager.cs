using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moneyManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();    
    }
    void Update()
    {
        moneyText.text = $"{playerStats.playerMoney}";
    }
}
