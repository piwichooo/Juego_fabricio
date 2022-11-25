using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rigidbody;
	private Vector2 posicionInicial;
	[Header("Movimiento")]

	public float moveSpeed;

	[Header("Salto")]
	private bool canDoubleJump;
	public float jumpForce;


	[Header("Componente")]

	public Rigidbody2D theRB;

	[Header("Animator")]
	public Animator anim;
	private SpriteRenderer theSR;


	[Header("Grounded")]
	private bool isGrounded;
	public Transform groundChekpoint;
	public LayerMask whatIsGround;



	void Start () {
		anim = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
		theSR = GetComponent<SpriteRenderer>();
		posicionInicial = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//mover

				theRB.velocity = new Vector2 (moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

				isGrounded = Physics2D.OverlapCircle (groundChekpoint.position, .2f, whatIsGround);

			//salto

		if (isGrounded) {
			canDoubleJump = true;
		}

		if (Input.GetButtonDown ("Jump")) {
			if (isGrounded) {
				theRB.velocity = new Vector2 (theRB.velocity.x, jumpForce);
			} else {
			
				if (canDoubleJump) {
					theRB.velocity = new Vector2 (theRB.velocity.x, jumpForce);
					canDoubleJump = false;
				}
			}
	
		
		}
		if (theRB.velocity.x < 0) {
			theSR.flipX = true;

		} else if (theRB.velocity.x > 0) {
			theSR.flipX = false;
		}




			if (transform.position.y< -15) { //posicion de arriba/abajo (y) del player es mayor regresa al inicio automatico
				transform.position = posicionInicial;
			}

	//animaciones
		anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
		anim.SetBool("isGround", isGrounded);
	
	}

	private void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "PlataformaMovible"){
			transform.parent = collision.transform;
		}
	}

	private void OnCollisionExit2D(Collision2D collision){
		if(collision.gameObject.tag == "PlataformaMovible"){
			transform.parent = null;
		}
	}
	void OnTriggerEnter2D(Collider2D fantasma){
		Debug.Log("Hola");
		if(fantasma.gameObject.tag == "Enemigo"){
			transform.position = posicionInicial;
		}
	}
}
