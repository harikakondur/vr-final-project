using UnityEngine;

public class SkateColorChanger : MonoBehaviour
{
    public Transform leftSkatePosition;  // Position to place the left skate prefab
    public Transform rightSkatePosition; // Position to place the right skate prefab
    public GameObject[] skatePrefabs;   // Array of skate prefabs for different colors

    private GameObject currentLeftSkate;
    private GameObject currentRightSkate;

    // On Awake, load the saved color choice from PlayerPrefs
    private void Awake()
    {
        // Retrieve the selected color index from PlayerPrefs (defaulting to 0 if no value is saved)
        int skateIndex = PlayerPrefs.GetInt("SkateColor", 0);

        // Apply the color change based on the saved index
        ChangeSkateColor(skateIndex);
    }

    // Method to change the skates by swapping prefabs
    public void ChangeSkateColor(int skateIndex)
    {
        Debug.Log($"Changing skate color to prefab at index: {skateIndex}");


        // Save the selected color index to PlayerPrefs so it persists between scenes
        PlayerPrefs.SetInt("SkateColor", skateIndex);
        PlayerPrefs.Save();

        // Destroy the existing skate objects if they are already instantiated
        if (currentLeftSkate != null) Destroy(currentLeftSkate);
        if (currentRightSkate != null) Destroy(currentRightSkate);

        // Instantiate the new skate prefab for both left and right positions
        GameObject skatePrefab = skatePrefabs[skateIndex];
        currentLeftSkate = Instantiate(skatePrefab, leftSkatePosition.position, Quaternion.identity, leftSkatePosition);
        currentRightSkate = Instantiate(skatePrefab, rightSkatePosition.position, Quaternion.identity, rightSkatePosition);
    }
}
