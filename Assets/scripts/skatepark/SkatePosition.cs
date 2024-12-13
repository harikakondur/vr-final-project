using UnityEngine;

public class SkatePosition : MonoBehaviour
{public GameObject playerOrigin; 
    public GameObject rightHandReference; 
    public GameObject leftHandReference;

    public GameObject rightSkate;
    public GameObject leftSkate;

    private Quaternion rotationOffset = Quaternion.Euler(0, 90, 0);
    void Update()
    {
        Vector3 playerPosition = playerOrigin.transform.position;

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

        // Calculate the direction from player to hand positions
        Vector3 rightSkateDirection = rightHandPosition - playerPosition;
        Vector3 leftSkateDirection = leftHandPosition - playerPosition;

        // Calculate the rotation only based on the hand direction (ignores character rotation)
        if (rightSkateDirection != Vector3.zero)
        {
            rightSkate.transform.rotation = Quaternion.LookRotation(rightSkateDirection)*rotationOffset;
        }

        if (leftSkateDirection != Vector3.zero)
        {
            leftSkate.transform.rotation = Quaternion.LookRotation(leftSkateDirection)*rotationOffset;
        }
    }
}
