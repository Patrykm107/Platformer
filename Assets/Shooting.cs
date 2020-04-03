using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Shooting : MonoBehaviour
{
    public GameObject firePrefab;
    public Transform startPosition;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Shoot");
            Instantiate(firePrefab, startPosition.position, startPosition.rotation);
        }
    }
}
