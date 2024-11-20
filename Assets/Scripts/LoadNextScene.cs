using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entered object has a camera component (since VR setups may not use "MainCamera" tag)
        Camera enteredCamera = other.GetComponentInChildren<Camera>();

        if (enteredCamera != null)
        {
            Debug.Log("VR Camera entered the trigger zone");

            if (!string.IsNullOrEmpty(nextSceneName))
            {
                Debug.Log("Loading next scene: " + nextSceneName);
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogError("Next scene name is not set!");
            }
        }
        else
        {
            Debug.Log("Entered object is not a camera");
        }
    }
}

