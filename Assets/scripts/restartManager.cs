using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class restartManager : MonoBehaviour
{
    public InputActionReference restartButton;

    void Start(){
        restartButton.action.performed += Restart;
    }


    void Restart(InputAction.CallbackContext __) {
        SceneManager.LoadScene("Scenes/demoScene");
        //right hand a button
    } 
}