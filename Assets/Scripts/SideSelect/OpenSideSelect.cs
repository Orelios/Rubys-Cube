using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSideSelect : MonoBehaviour
{
    public GameObject canvas;
    public GameObject sideSelectCamera;
    public GameObject playerCamera;
    public GameObject player;
    public DetectSide detectSide;

    public Transform playerP;
    public Transform spawn;

    [SerializeField] private OpenInventory openInventory;
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject prompts;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canvas.SetActive(true);
            sideSelectCamera.SetActive(true);
            playerCamera.SetActive(false);

            UnlockMouse();
            mainCanvas.SetActive(false);
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
        if(detectSide.locked == true)
        {
            Debug.Log("Side is locked!");
        }
        if(detectSide.locked == false)
        {
            canvas.SetActive(false);
            sideSelectCamera.SetActive(false);
            playerCamera.SetActive(true);

            Debug.Log("Player Teleported!");

            player.SetActive(false);
            playerP.position = spawn.position;
            player.SetActive(true);

            LockMouse();
            EnableMainCanvas();
        }
    }

    private void EnableMainCanvas()
    {
        mainCanvas.SetActive(true);
        openInventory.activeScene = false;
        openInventory.selector.SetActive(false);
        inventory.SetActive(false);
        prompts.SetActive(true);
    }
}
