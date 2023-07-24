using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference: FIRST PERSON MOVEMENT in Unity - FPS Controller by Brackeys

    public CharacterController controller;
    public GameObject DialogueBox;
    public Projection1 projection;
    public ItemController itemController;

    public float moveSpeed = 12f;
    public float gravity = -10f;

    //Used to create a sphere below the player so it will check the ground
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    public bool isGrounded;
    public bool isMoveable = true;

    //Used to check what's infront of the player so that they can interact
    Camera cam;
    public NPCInteractable interactable;
    public bool isInteracting = false;
    public GameObject buttonCanvas;
    public GameObject button1;
    public GameObject button2;
    public bool choosing = false;
    private int index = 1;


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


        if (Input.GetKeyDown(KeyCode.E) && isInteracting == false) //Interaction
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) //Add Interaction
            {
                interactable = hit.collider.GetComponent<NPCInteractable>();

                if (interactable != null && isInteracting == false && interactable.GetComponent<NPCInteractable>().withinRange == true)
                {
                    
                    isMoveable = false; //Disable Player Movement
                    isInteracting = true;

                    DialogueBox.SetActive(true);
                    DialogueBox.GetComponent<Dialogue>().lines = (string[])interactable.GetComponent<NPCInteractable>().NPCLines.Clone();

                    if (interactable.GetComponent<NPCInteractable>().branchingDialogue == true)
                    {
                        DialogueBox.GetComponent<Dialogue>().branching = true;
                    }
                    
                }
            }
        }

        if (DialogueBox.GetComponent<Dialogue>().endLineChecker == true)
        {
            buttonCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;

            //Set up the text in the buttons
            if (index == 1)
            {
                button1.GetComponent<DialogueButton>().textComponent.text = interactable.GetComponent<NPCInteractable>().branchAnswers1;
                index++;
            }

            if (index == 2)
            {
                button2.GetComponent<DialogueButton>().textComponent.text = interactable.GetComponent<NPCInteractable>().branchAnswers2;
                index = 1;
            }

            //If upper button is presssed
            if (button1.GetComponent<DialogueButton>().pressed == true)
            {
                DialogueBox.GetComponent<Dialogue>().lines = (string[])interactable.GetComponent<NPCInteractable>().branchingLines1.Clone();
                DialogueBox.GetComponent<Dialogue>().branching = false;
                DialogueBox.GetComponent<Dialogue>().endLineChecker = false;

                InventoryManager.Instance.Search(projection.Shoes, projection.collectedShoes);
                if (projection.collectedShoes == true && interactable.GetComponent<NPCInteractable>().fragmentType == FragmentType.Necklace)
                {
                    Debug.Log("Necklace");
                    InventoryManager.Instance.Add(itemController.itemClass);
                }

                DialogueBox.GetComponent<Dialogue>().index = 0;
                isInteracting = false;
                Cursor.lockState = CursorLockMode.Locked;
                button1.GetComponent<DialogueButton>().pressed = false;
                buttonCanvas.SetActive(false);
                
            }

            //If lower button is presssed
            else if (button2.GetComponent<DialogueButton>().pressed == true)
            {
                DialogueBox.GetComponent<Dialogue>().lines = (string[])interactable.GetComponent<Collider>().GetComponent<NPCInteractable>().branchingLines2.Clone();
                DialogueBox.GetComponent<Dialogue>().branching = false;
                DialogueBox.GetComponent<Dialogue>().endLineChecker = false;  
                DialogueBox.GetComponent<Dialogue>().index = 0;
                isInteracting = false;
                Cursor.lockState = CursorLockMode.Locked;
                button2.GetComponent<DialogueButton>().pressed = false;
                buttonCanvas.SetActive(false);
                
            }
        }
    }
}


