using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastController : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 10.0f;
    [SerializeField] LayerMask itemLayer;
    [SerializeField] LayerMask npcLayer;
    [SerializeField] LayerMask unlockableLayer = 7;
    public TextMeshProUGUI interactionInfo;

    private void FixedUpdate()
    {
        RaycastHit hit;
        interactionInfo.enabled = false;

        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, itemLayer))
        {
            if(hit.collider.TryGetComponent<InteractableObject>(out InteractableObject interactable))
            {
                interactionInfo.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                    /*Debug.Log("It hit");*/
                }
            }
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, npcLayer))
        {
            interactionInfo.enabled = true;
        }
    }
}
