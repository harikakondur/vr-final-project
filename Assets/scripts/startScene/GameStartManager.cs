using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("nextSceneTile")) 
    {
        Debug.Log("Next Scene");
        SceneManager.LoadScene("Scenes/startScene");
    }
}
}