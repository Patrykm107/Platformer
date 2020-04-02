using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject firePrefab;
    public Transform startPosition;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(firePrefab, startPosition.position, startPosition.rotation);
        }
    }
}
