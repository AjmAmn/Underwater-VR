using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishController : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] float reverseSpeed;

	Rigidbody rb;

	void Awake () {
		Debug.Log ("Created fish");
		rb = GetComponent<Rigidbody> ();	
	}

	void Start () {
		Debug.Log ("Setting fish velocity");
		rb.velocity = transform.forward * speed;
	}
		
	void Reverse() {
		transform.forward *= -1;
		rb.velocity = reverseSpeed * transform.forward;
	}

	void OnTriggerEnter(Collider other) {
		if (!other.CompareTag("Fish")) {
			Reverse ();		
		}
	}
}
