using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference: FIRST PERSON MOVEMENT in Unity - FPS Controller by Brackeys

    public CharacterController controller;

    public float moveSpeed = 12f;
    public float gravity = -10f;

    //Used to create a sphere below the player so it will check the ground
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    Camera cam;
    public Interactable focus;
    private bool interacting = false;
    Vector3 pos = new Vector3(100f, 100f, 0);


    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //GroundChecker        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Resets Velocity if they hit the ground
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Move player in a direction
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        //Moves the character when they are falling down based on the gravity and velocity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(pos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) //Set Focus to the object
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null && interacting == true)
                {
                    Debug.Log("Remove Focus");
                    RemoveFocus();
                }

                if (interactable != null && interacting == false)
                {
                    Debug.Log("Add Focus");
                    SetFocus(interactable);
                }

                if (interacting == false)
                {
                    interacting = true;
                }

                else
                {
                    interacting = false;
                }
            }
        }
    }

    void SetFocus (Interactable newFocus)
    {
        focus = newFocus;
    }

    void RemoveFocus()
    {
        focus = null;
    }
}
