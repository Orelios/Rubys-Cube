using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private int rotateSpeed;
    bool isMoving = false;

    // Update is called once per frame
    void Update()
    {
    }

    public void Clicked()
    {
        string ClickedButton = EventSystem.current.currentSelectedGameObject.name;

        Debug.Log("Clicked!");
        Debug.Log(ClickedButton + " is created!");

        if (isMoving)
        {
            return;
        }

        if(ClickedButton == "UpButton")
        {
            Debug.Log("Found button name!");
            StartCoroutine(CubeRotate(Vector3.forward));
        }

        else if(ClickedButton == "RightButton")
        {
            StartCoroutine(CubeRotate(Vector3.right));
        }

        else if(ClickedButton == "LeftButton")
        {
            StartCoroutine(CubeRotate(Vector3.left));
        }

        else if(ClickedButton == "DownButton")
        {
            StartCoroutine(CubeRotate(Vector3.back));
        }

    }

    IEnumerator CubeRotate(Vector3 direction)
    {
        isMoving = true;

        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);
        
        while (remainingAngle > 0)
        {
            float rotationAngle = Mathf.Min(Time.deltaTime * rotateSpeed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }

        isMoving = false;
    }
}
