using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class NextSceneManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("nextSceneTile"))
        {
            Debug.Log("Loading next scene in queue");

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;

            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("Returning to the first scene.");
                SceneManager.LoadScene(0); // restart
            }
        }
}
}