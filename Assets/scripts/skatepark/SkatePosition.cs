using UnityEngine;

public class SkatePosition : MonoBehaviour
{
    public GameObject playerOrigin; // XR origin position 
    public GameObject rightHandReference; // Right hand controller position
    public GameObject leftHandReference; // Left hand controller position

    public GameObject rightSkate;
    public GameObject leftSkate;

    public float rotationSensitivity = 1.2f; // How sensitive the rotation is to hand movements
    private Quaternion previousRightSkateRotation;
    private Quaternion previousLeftSkateRotation;

    void Start()
    {
        // Initialize previous rotations
        previousRightSkateRotation = rightSkate.transform.rotation;
        previousLeftSkateRotation = leftSkate.transform.rotation;
    }

    void Update()
    {
        Vector3 playerPosition = playerOrigin.transform.position;

        // Align hands to the player's Y position for consistent height
        Vector3 rightHandPosition = new Vector3(
            rightHandReference.transform.position.x,
            playerPosition.y, 
            rightHandReference.transform.position.z
        );

        Vector3 leftHandPosition = new Vector3(
            leftHandReference.transform.position.x,
            playerPosition.y, 
            leftHandReference.transform.position.z
        );

        // Calculate the direction from the player to the hand positions
        Vector3 rightSkateDirection = rightHandPosition - playerPosition;
        Vector3 leftSkateDirection = leftHandPosition - playerPosition;

        // Scale the direction vectors by the sensitivity factor
        rightSkateDirection *= rotationSensitivity;
        leftSkateDirection *= rotationSensitivity;

        // Calculate the rotation based on the hand's direction (ignoring external movements like the continuous move provider)
        if (rightSkateDirection != Vector3.zero)
        {
            // Target rotation for the right skate
            Quaternion targetRotationRight = Quaternion.LookRotation(rightSkateDirection);
            // Apply the offset and smooth the rotation
            rightSkate.transform.rotation = Quaternion.Slerp(previousRightSkateRotation, targetRotationRight * Quaternion.Euler(0, 85, 0), Time.deltaTime * rotationSensitivity);
            previousRightSkateRotation = rightSkate.transform.rotation;
        }

        if (leftSkateDirection != Vector3.zero)
        {
            // Target rotation for the left skate
            Quaternion targetRotationLeft = Quaternion.LookRotation(leftSkateDirection);
            // Apply the offset and smooth the rotation
            leftSkate.transform.rotation = Quaternion.Slerp(previousLeftSkateRotation, targetRotationLeft * Quaternion.Euler(0, 95, 0), Time.deltaTime * rotationSensitivity);
            previousLeftSkateRotation = leftSkate.transform.rotation;
        }
    }
}
