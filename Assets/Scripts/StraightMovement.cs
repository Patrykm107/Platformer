using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StraightMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Rigidbody2D body;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        body.velocity=new Vector2(speed * gameObject.transform.localScale.normalized.x, body.velocity.y);
    }
}
