﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyFlip : MonoBehaviour
{
    private Rigidbody2D body;
    private bool facingRight = true;
    private float lastX = 0;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (body.position.x > lastX && !facingRight || body.position.x < lastX && facingRight)
        {
            Flip();
        }

        lastX = body.position.x;
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
