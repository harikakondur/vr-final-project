using UnityEngine;

public class AttatchSkates : MonoBehaviour
{
    public Transform mainCamera;  // Reference to the Main Camera
    public float heightOffset = -1f;  // Height of the PlayerBody relative to the camera
    public float forwardOffset = 0.2f;  // Forward offset for PlayerBody

    void Update()
    {
        // Sync PlayerBody position with Main Camera (horizontal movement only)
        Vector3 cameraPosition = mainCamera.position;
        transform.position = new Vector3(cameraPosition.x, cameraPosition.y + heightOffset, cameraPosition.z + forwardOffset);
    }
}