using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float pushPower = 1500f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStats>().takeDamage();
            Rigidbody2D playerBody = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 direction = playerBody.transform.position - transform.position;
            playerBody.AddForce(new Vector2(direction.x * 2, direction.y)*pushPower);
        }
    }
}
