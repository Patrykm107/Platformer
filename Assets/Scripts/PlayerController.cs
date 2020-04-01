using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private float jumpStrength = 30f;
	[Range(0, .3f)] [SerializeField] private float movementSmooth = .05f;
	[SerializeField] private LayerMask groundLayers;
	[SerializeField] private Transform groundCheck;

	const float onGroundRadius = .3f;
	private bool onGround;
	private bool jumpBlocked = false;
	[SerializeField] private float jumpBlockTime = 0.5f;

	private Rigidbody2D rrigidbody2D;
	private Vector3 velocity = Vector3.zero;
	private bool facingRight = true;

	private float respawnHeight = -10f;

	public UnityEvent onLandEvent;

	void Start()
    {
		rrigidbody2D = GetComponent<Rigidbody2D>();
		Respawn();
    }

	private void FixedUpdate()
	{
		bool wasOnGround = onGround;
		onGround = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, onGroundRadius, groundLayers);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				onGround = true;

				if (!wasOnGround)
					onLandEvent.Invoke();
			}
		}

		if (rrigidbody2D.position.y < respawnHeight)
		{
			Respawn();
		}
	}

	public void Move(float move, bool jump)
	{

		Vector3 targetVelocity = new Vector3(move * 10f, rrigidbody2D.velocity.y);
		rrigidbody2D.velocity = Vector3.SmoothDamp(rrigidbody2D.velocity, targetVelocity, ref velocity, movementSmooth);

		if(onGround && jump && !jumpBlocked)
		{
			onGround = false;
			rrigidbody2D.AddForce(new Vector2(0, jumpStrength), ForceMode2D.Impulse);
			StartCoroutine(BlockJump());
		}

		if(move < 0 && facingRight)
		{
			Flip();
		} 
		else if (move > 0 && !facingRight)
		{
			Flip();
		}
	}

	void Flip()
	{
		facingRight = !facingRight;

		transform.Rotate(0, 180f, 0);
	}

	public void Respawn()
	{
		transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
	}

	IEnumerator BlockJump()
	{
		jumpBlocked = true;
		yield return new WaitForSeconds(jumpBlockTime);
		jumpBlocked = false;
	}
}
