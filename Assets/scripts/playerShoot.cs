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
    void Start()
    {
        

        trigger.action.Enable(); 
        trigger.action.performed += Shoot;
    }


    void Shoot(InputAction.CallbackContext __) {
        GameObject newBullet = Instantiate(BulletTemplate, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower);

        audioSource.PlayOneShot(gunshotSFX);
    }
}
