using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleSpawner : MonoBehaviour
{
    public GameObject particlePrefab;   // Prefab of your particle system
    public float spawnRadius = 10f;     // Radius within which to spawn particles
    public float visibilityDistance = 15f;  // Distance at which the particle system is visible
    private GameObject spawnedParticle; // Reference to the spawned particle system
    private Transform mainCamera;       // Reference to the main camera

    void Start()
    {
        mainCamera = Camera.main.transform;
        SpawnParticle();
    }

    void Update()
    {
        // Check if particle system is in the camera's sight
        if (spawnedParticle != null)
        {
            float distanceToCamera = Vector3.Distance(mainCamera.position, spawnedParticle.transform.position);

            if (distanceToCamera > visibilityDistance)
            {
                // Disable the particle system if the camera is too far away
                spawnedParticle.SetActive(false);
            }
            else
            {
                // Enable the particle system if the camera is close enough
                spawnedParticle.SetActive(true);
            }
        }
        else
        {
            // If no particle system exists, spawn a new one
            SpawnParticle();
        }
    }

    void SpawnParticle()
    {
        // Random position within the specified radius around the camera
        Vector3 randomPosition = mainCamera.position + Random.onUnitSphere * spawnRadius;
        randomPosition.y = 0f; // Keep particles on the ground or adjust as necessary

        // Instantiate the particle system at the random position
        spawnedParticle = Instantiate(particlePrefab, randomPosition, Quaternion.identity);
        spawnedParticle.SetActive(true);
    }
}

