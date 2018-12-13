using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	//Flaco Movement Variables
	public int moveSpeed;
	public float jumpHeight;
	private bool doubleJump;
	public Animator Animator;

	//Flaco Grounded Variables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	//Non-Slide Player
	private float moveVelocity;

	// Use this for initialization
	void Start () {
		Animator.SetBool("isWalking", false);
		Animator.SetBool("isJumping", false);
		Animator.SetBool("isBooling", false);
	}

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {

		// Flaco Jump Code
	 if(Input.GetKeyDown (KeyCode.Space)&&grounded){
		Jump();
		}

		// Double Jump Code
		if(grounded){
			doubleJump = false;
			Animator.SetBool("isJumping",false);
		}

		if(Input.GetKeyDown (KeyCode.Space)&& !doubleJump && !grounded){
			Jump();
			doubleJump = true;
		}
		//Non-Slide Player
		moveVelocity = 0f;

		// Flaco Move side to side
		if(Input.GetKey (KeyCode.D)){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = moveSpeed;
			Animator.SetBool("isWalking" , true);
		}
		else if(Input.GetKeyUp (KeyCode.D)){
			Animator.SetBool("isWalking" , false);
		}
		if(Input.GetKey (KeyCode.A)){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = -moveSpeed;
				Animator.SetBool("isWalking" , true);
		}
			else if(Input.GetKeyUp (KeyCode.A)){
				Animator.SetBool("isWalking" , false);
			}

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

		//Player Flip
		if(GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(2f, 2f, 0f);

		else if (GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3(-2f, 2f, 0f);
	}

	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		Animator.SetBool("isJumping" , true);
	}

}
