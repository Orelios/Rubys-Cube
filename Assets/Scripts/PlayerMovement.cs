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
    bool isMoveable = true;

    //Used to check what's infront of the player so that they can interact
    Camera cam;
    public Interactable focus;
    private bool isInteracting = false;


    void Start()
    {
        cam = Camera.main; //Gets the Camera
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

        if (isMoveable)
        {
            //Move player in a direction
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * moveSpeed * Time.deltaTime);
        }

        //Moves the character when they are falling down based on the gravity and velocity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.E)) //Interaction
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            if (Input.GetKeyDown(KeyCode.E) && isInteracting == true) //Remove Interaction
            {
                Debug.Log("Remove Focus");
                RemoveFocus(); //Remove your focus
                isMoveable = true; //Enable Player Movement
                isInteracting = false;
            }

            else if (Physics.Raycast(ray, out hit, 100)) //Add Interaction
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null && isInteracting == false && hit.collider.GetComponent<Interactable>().withinRange == true)
                {
                    Debug.Log("Add Focus");
                    SetFocus(interactable); //Sets it as the focus on what you're interacting with
                    isInteracting = true;

                    if (hit.collider.GetComponent<Interactable>().type == ObjectType.NPC)
                    {
                        isMoveable = false; //Disable Player Movement
                    }
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
