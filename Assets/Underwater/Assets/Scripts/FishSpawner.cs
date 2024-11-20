using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

	List<FishController> fish;

	[SerializeField] int minSchoolSize = 1;
	[SerializeField] int maxSchoolSize = 1;
	[SerializeField] GameObject fishPrefab;
	[SerializeField] float activationDistance = 5;
	[SerializeField] float deactivationDistance = 100;

	List<GameObject> school = new List<GameObject>();
	bool activated = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		// Determine the distance between the FishSpawner and the player.
		float distance = Vector3.Distance (transform.position, Camera.main.transform.position);

		// If the player is within the activation distance, and the fish are not active,
		// initialize a school of fish.
		if (!activated && (distance <= activationDistance)) {
			SpawnSchool ();
			activated = true;
		}
		// Destroy the school when the player is outside maxDistance.
		else if (activated && (distance >= deactivationDistance)) {
			DestroySchool ();
			activated = false;
		}
	}

	// Instantiate a school of fish and populate the school list.
	void SpawnSchool() {
		int numFish = Random.Range (minSchoolSize, maxSchoolSize + 1);

		// Generate a rotation for all fish in the school.
		Vector3 euler = GetRandomRotation();

		for (int i = 0; i < numFish; i++) {
			school.Add(SpawnFish(euler));
		}
	}

	Vector3 GetRandomRotation() {
		Vector3 rotation = Vector3.zero;
		rotation.x = Random.Range (-45, 45);
		rotation.y = Random.Range (-45, 45);
		return rotation;
	}

	// Instantiate and return a single fish near the FishSpawner object.
	GameObject SpawnFish(Vector3 euler) {
		GameObject newFish = Instantiate (fishPrefab, transform);

		// Generate randomness in the position of this new fish.
		float x = transform.position.x + Random.Range (-5f, 5f);
		float y = transform.position.y + Random.Range (-5f, 5f);
		float z = transform.position.z + Random.Range (-5f, 5f);
		newFish.transform.position = new Vector3 (x, y, z);

		newFish.transform.eulerAngles = euler;
		return newFish;
	}
		
	// Destroy all fish in the school.
	void DestroySchool() {
		foreach (GameObject fish in school) {
			Destroy(fish);
		}
		school = new List<GameObject> ();
	}


}
