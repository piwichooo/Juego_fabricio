using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform target;
	public Transform farBackground, middleBackground;

	public float minHeigth, maxHeigth;
	private Vector2 lastPos;
	// Use this for initialization
	void Start () {
		lastPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (target.position.x, Mathf.Clamp (target.position.y, minHeigth, maxHeigth), transform.position.z);
		Vector2 amountToMove = new Vector2 (transform.position.x - lastPos.x, transform.position.y - lastPos.y);
		farBackground.position = farBackground.position + new Vector3 (amountToMove.x, amountToMove.y, 0f);
		middleBackground.position += new Vector3 (amountToMove.x, amountToMove.y, 0f)* .9f;
		lastPos = transform.position;
	}
}
