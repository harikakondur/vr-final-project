using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Audio;

public class collect : MonoBehaviour
{
    public AudioSource collectAudioSource;
    public AudioClip collectSfx;
  
   void OnTriggerEnter(Collider other)
    {
        collectAudioSource.PlayOneShot(collectSfx);
        this.gameObject.SetActive(false);
    }
}
