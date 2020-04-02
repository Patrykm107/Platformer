using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class Fireball : MonoBehaviour
{
    public Vector2 velocity;
    public GameObject explosionPrefab;
    [SerializeField] private float timeToExplode = 6f;
    private Rigidbody2D body;

    void Start()
    {
        Assert.IsTrue(timeToExplode >= 0f, "TimeToExplode must be >= 0");
        StartCoroutine(ExplodeAfterTime(6f));
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(transform.right.x * velocity.x, -velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 normal = col.contacts[0].normal;
        Vector2 bottomSide = new Vector2(0f, 1f);


        if (normal == bottomSide)
        {
            body.velocity = new Vector2(body.velocity.x, velocity.y);
        }
        else
        {
            Explode();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Explode();
        }
    }

    IEnumerator ExplodeAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Explode();
    }

    private void Explode()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

}
