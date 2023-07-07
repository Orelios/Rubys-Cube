using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastController : MonoBehaviour
{
    [SerializeField]
    private float raycastDistance = 5.0f;

    [SerializeField]
    //The layer that will determine what the raycast will hit
    LayerMask layerMask;
    //The UI text component that will display the name of the interactable hit
    // public TextMeshProUGUI interactionInfo;

    // Update is called once per frame
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, raycastDistance, layerMask))
        {
            if(hit.collider.TryGetComponent<Interactable>(out Interactable interactable))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    interactable.Interact();
                    Debug.Log("It hit");
                }
            }
        }
    }
}
