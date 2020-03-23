using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moneyManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    [SerializeField] private GameObject collectiblesGrid;
    private PlayerStats playerStats;
    private int maxMoneyAmount;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        maxMoneyAmount = collectiblesGrid.GetComponentsInChildren<Money>().Length + playerStats.playerMoney;
    }
    void Update()
    {
        moneyText.text = $"{playerStats.playerMoney}/{maxMoneyAmount}";
    }
}
