using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SkateColorChanger : MonoBehaviour
{
    public Transform leftSkatePosition;
    public Transform rightSkatePosition; 
    public GameObject[] skatePrefabs;   

    private GameObject currentLeftSkate;
    private GameObject currentRightSkate;
    private void Awake()
    {
        int skateIndex = PlayerPrefs.GetInt("SkateColor", 0);

        ChangeSkateColor(skateIndex);
    }

    public void ChangeSkateColor(int skateIndex)
    {

        // PlayerPrefs.SetInt("SkateColor", skateIndex);
        // PlayerPrefs.Save();

        if (currentLeftSkate != null) Destroy(currentLeftSkate);
        if (currentRightSkate != null) Destroy(currentRightSkate);

        GameObject skatePrefab = skatePrefabs[skateIndex];
        currentLeftSkate = Instantiate(skatePrefab, leftSkatePosition.position, Quaternion.identity, leftSkatePosition);
        currentRightSkate = Instantiate(skatePrefab, rightSkatePosition.position, Quaternion.identity, rightSkatePosition);
    }
}
