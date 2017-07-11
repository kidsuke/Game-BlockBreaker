using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private Vector2 initialVeclocity;
	private bool hasStarted = false;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		initialVeclocity = new Vector2 (2f, 10f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;

			if (Input.GetMouseButtonDown (0)) {
				this.rigidbody2D.velocity = initialVeclocity;
				hasStarted = true;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
		if (hasStarted) {
			audio.Play ();
			this.rigidbody2D.velocity += tweak;
		}
	}
}
