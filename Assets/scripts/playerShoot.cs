using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
// using UnityEngine.Audio;

public class playerShoot : MonoBehaviour
{
    public AudioSource audioSource;   

    public GameObject BulletTemplate;
    public float shootPower = 100f;
    public AudioClip gunshotSFX;

    public InputActionReference trigger;
    // Start is called before the first frame update
    void Start()
    {
        if (trigger == null)
        {
            Debug.LogError("Trigger reference is not assigned in the Inspector.");
            return;
        }

        if (trigger.action == null)
        {
            Debug.LogError("Action in trigger is null. Check the Input Action setup.");
            return;
        }

        trigger.action.Enable(); // Optional, but ensures action is enabled
        trigger.action.performed += Shoot;
        Debug.Log("Trigger action successfully subscribed.");
    }


    void Shoot(InputAction.CallbackContext __) {
        Debug.Log("Shooting");
        GameObject newBullet = Instantiate(BulletTemplate, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower);

        audioSource.PlayOneShot(gunshotSFX);
    }
}
