using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;


public class jump : MonoBehaviour
{
  [SerializeField] private InputActionReference jumpButton;
  [SerializeField] private float jumpHeight = 2f;
  [SerializeField] private float gravity = -9.81f;

  public AudioClip jumpSfx;
  public AudioSource jumpAudioSource;


  private CharacterController controller;
  private Vector3 velocity;

  private void Awake()
  {
    controller = GetComponent<CharacterController>();
  }

  private void OnEnable() => jumpButton.action.performed += Jumping;
  
  private void OnDisable() => jumpButton.action.performed -= Jumping;


  private void Jumping(InputAction.CallbackContext _)
  {
    if (!controller.isGrounded) return; // if the player is on the ground, return

    //play jump sound
    jumpAudioSource.PlayOneShot(jumpSfx);
    Debug.Log("Jumping");
    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
  }

  private void Update()
  {
    if (controller.isGrounded && velocity.y < 0)
    {
      velocity.y = 0f;
    }
     
    velocity.y += gravity * Time.deltaTime; 
    controller.Move(velocity * Time.deltaTime); 

  }

}
