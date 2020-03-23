using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
    void Awake()
    {
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            Instantiate(playerPrefab);
        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Respawn();

        foreach (GameObject hud in GameObject.FindGameObjectsWithTag("HUD"))
        {
            hud.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }
    }
}
