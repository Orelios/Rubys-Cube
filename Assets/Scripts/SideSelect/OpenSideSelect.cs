using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSideSelect : MonoBehaviour
{
    public GameObject canvas;
    public GameObject sideSelectCamera; 
    public GameObject playerCamera;
    public GameObject player;

    public Transform playerP;
    public Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canvas.SetActive(true);
            sideSelectCamera.SetActive(true);
            playerCamera.SetActive(false);

            UnlockMouse();
        }
    }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Select()
    {
        canvas.SetActive(false);
        sideSelectCamera.SetActive(false);
        playerCamera.SetActive(true);

        Debug.Log("Player Teleported!");
    
        player.SetActive(false);
        playerP.position = spawn.position;
        player.SetActive(true);

        LockMouse();
    }
}
