using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class GrindSound : MonoBehaviour
{
    public AudioSource grindAudioSource;   

    // Clips for different obstacles
    public AudioClip railGrindClip;
    public AudioClip boxGrindClip;
    public AudioClip rampGrindClip;


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Rail") || other.CompareTag("Box") || other.CompareTag("Ramp"))
        {
            Debug.Log("colliding");

            AudioClip obstacleSound = GetObstacleSound(other);
            grindAudioSource.clip = obstacleSound;
            grindAudioSource.Play();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Rail") || other.CompareTag("Box") || other.CompareTag("Ramp"))
        {
            grindAudioSource.Stop();
        }
    }

    // Function to return the appropriate sound based on the obstacle
    private AudioClip GetObstacleSound(Collider obstacle)
    {
        switch (obstacle.gameObject.tag)
        {
            case "Ramp":
                return rampGrindClip;
            case "Rail":
                Debug.Log("Rail");
                return railGrindClip;
            case "Box":
                Debug.Log("Box");
                return boxGrindClip;
            default:
                return null;
        }
    }
}
