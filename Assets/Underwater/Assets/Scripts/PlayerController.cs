using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] float speed;
	Rigidbody rb;

	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire1")) {
			// Move in the direction the player is looking.
			rb.velocity = Camera.main.transform.forward * speed;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (!other.CompareTag ("Fish")) {
			rb.velocity = new Vector3 (0f, 0f, 0f);
		}
	}
}
