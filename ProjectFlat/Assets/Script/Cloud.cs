using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
	
	public float dirX, moveSpeed = 3f;
	public float space;
	public float space1;

	bool moveRight = true;

	// Update is called once per frame
	void Update () {
		if (transform.position.x > space)
			moveRight = false;
		if (transform.position.x < space1)
			moveRight = true;

		if (moveRight)
			transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
		else
			transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
	}
}
