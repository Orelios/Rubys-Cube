using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectSide : MonoBehaviour
{
    [SerializeField]
    private float raycastDistance = 2.0f;

    [SerializeField]
    LayerMask side;

    public TextMeshProUGUI sideInfo;

    private bool sideHover = false;

    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        sideHover = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastDistance, side);

        if(sideHover)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastDistance, Color.red);
            Debug.Log("Collided with side!");

            Side side = hit.collider.GetComponent("Side") as Side;
            Debug.Log("Changed name! " + side.id);
            sideInfo.text = side.id;
        }
        else if(!sideHover)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastDistance, Color.green);
        }
    }
}
