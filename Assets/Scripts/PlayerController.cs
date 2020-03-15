using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float jumpStrength = 300f;
	[Range(0, .3f)] [SerializeField] private float movementSmooth = .05f;
	[SerializeField] private LayerMask groundLayers;
	[SerializeField] private Transform groundCheck;

	const float onGroundRadius = .2f;
	private bool onGround;

	private Rigidbody2D rrigidbody2D;
	private Vector3 velocity = Vector3.zero;

	void Awake()
    {
		rrigidbody2D = GetComponent<Rigidbody2D>();
    }

	private void FixedUpdate()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, onGroundRadius, groundLayers);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				onGround = true;
			}
		}
	}

	public void Move(float move, bool jump)
	{
		Vector3 targetVelocity = new Vector3(move * 10f, rrigidbody2D.velocity.y);
		rrigidbody2D.velocity = Vector3.SmoothDamp(rrigidbody2D.velocity, targetVelocity, ref velocity, movementSmooth);

		if(onGround && jump)
		{
			onGround = false;
			rrigidbody2D.AddForce(new Vector2(0, jumpStrength));
		}
	}
}
