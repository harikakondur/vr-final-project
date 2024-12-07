using UnityEngine;

public class GrindSound : MonoBehaviour
{
    public AudioSource grindAudioSource;  // Reference to the audio source
    public GameObject leftSkate;  // Reference to the left skate
    public GameObject rightSkate;  // Reference to the right skate

    // Public Audio Clips for different obstacles
    public AudioClip railGrindClip;
    public AudioClip boxGrindClip;
    public AudioClip rampGrindClip;

    private AudioClip currentGrindSound;  // The current sound being played for grinding

    private void OnTriggerEnter(Collider other)
    {
        // Check if the obstacle is skatable (Rail, Box, or Ramp)
        if (other.CompareTag("Rail") || other.CompareTag("Box") || other.CompareTag("Ramp"))
        {
            // Get the corresponding sound for the obstacle
            AudioClip obstacleSound = GetObstacleSound(other);

            // If it's a new sound, change the current sound and play it
            if (obstacleSound != currentGrindSound)
            {
                currentGrindSound = obstacleSound;
                grindAudioSource.clip = currentGrindSound;
                grindAudioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the skate has exited the skatable object (Rail, Box, or Ramp)
        if (other.CompareTag("Rail") || other.CompareTag("Box") || other.CompareTag("Ramp"))
        {
            // If neither skate is grinding, stop the audio
            grindAudioSource.Stop();
        }
    }

    // Function to return the appropriate sound based on the obstacle
    private AudioClip GetObstacleSound(Collider obstacle)
    {
        // Return the appropriate sound based on the tag of the obstacle
        switch (obstacle.gameObject.tag)
        {
            case "Ramp":
                return rampGrindClip;
            case "Rail":
                return railGrindClip;
            case "Box":
                return boxGrindClip;
            default:
                return null;
        }
    }
}
