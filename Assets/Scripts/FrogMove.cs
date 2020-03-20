using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float jumpStrength = 1f;
    [SerializeField] private float waitTime = 2f;

    private float groundCheckRadius = 0.1f;

    private Rigidbody2D body;
    private Animator animator;

    private float jumpX = -60f;
    private float jumpY = 120f;

    private bool canJump = true;
    private bool jumpBlocked = false;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayers);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                canJump = true;
                animator.SetBool("Airborne", false);
            }
        }

        if (canJump && !jumpBlocked) 
        { 
            StartCoroutine(jump());
            canJump = false;
        }
    }

    IEnumerator jump()
    {
        body.AddForce(new Vector2(jumpX, jumpY)*jumpStrength);
        animator.SetBool("Airborne", true);

        jumpBlocked = true;
        yield return new WaitForSeconds(waitTime);
        jumpBlocked = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            body.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            body.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }
}
