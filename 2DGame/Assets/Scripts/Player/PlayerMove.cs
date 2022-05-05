using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float speed = 5f;
	public float jumpSpeed = 10f;

	public Animator animator;
	private Rigidbody2D rb;
	private float moveInput;
	private bool isGround = false;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		animator.SetFloat("Move", Mathf.Abs(moveInput));

		if (Input.GetKeyDown(KeyCode.Space) && isGround)
		{
			animator.SetTrigger("Jump");
			rb.velocity = Vector2.up * jumpSpeed;
		}
	}

	private void FixedUpdate()
	{
		moveInput = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
		if (moveInput < 0f)
		{
			transform.eulerAngles = new Vector3(0, -180, 0);
		}
		else if (moveInput > 0f)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
			isGround = true;
		}
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
		if (collision.collider.tag == "Ground")
		{
			isGround = true;
		}
	}
    private void OnCollisionExit2D(Collision2D collision)
    {
		if (collision.collider.tag == "Ground")
		{
			isGround = false;
		}
	} 
}
