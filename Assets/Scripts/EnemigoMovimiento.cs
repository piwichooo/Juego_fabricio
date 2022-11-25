using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimiento : MonoBehaviour {
	public float moveSpeed;

	public Transform leftPoint, rightPoint;

	private bool movingRigth;

	private Rigidbody2D theRB;


	public SpriteRenderer theSR;



	// Use this for initialization
	void Start () {
		
		theRB = GetComponent<Rigidbody2D>();


		leftPoint.parent = null;
		rightPoint.parent = null;
	}

	// Update is called once per frame
	void Update () {
		if (movingRigth) {
			theRB.velocity = new Vector2 (moveSpeed, theRB.velocity.y);

			theSR.flipX = false;

			if (transform.position.x > rightPoint.position.x) {
				movingRigth = false;
			}
		} else {
			theRB.velocity = new Vector2 (-moveSpeed, theRB.velocity.y);
			theSR.flipX = true;


			if (transform.position.x < leftPoint.position.x) {
				movingRigth = true;
			}
		}
	}

}