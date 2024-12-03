using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI; 

public class RayCastUI : MonoBehaviour
{
    [SerializeField]
    private LayerMask uiLayerMask; 
    [SerializeField]
    private InputActionReference buttonPress; 

    void Start()
    {
        buttonPress.action.performed += DoRayCast;
    }

    void DoRayCast(InputAction.CallbackContext __)
    {
        RaycastHit hit;
        bool didHit = Physics.Raycast(
            transform.position,
            transform.forward,
            out hit,
            Mathf.Infinity,
            uiLayerMask);

        if (didHit)
        {
            
            Debug.Log("Hit ");

            var button = hit.collider.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.Invoke();
            }
        }
    }
}

