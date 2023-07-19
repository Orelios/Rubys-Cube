using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject component;
    public GameObject selector; 
    private bool activeScene = true; 
    // Start is called before the first frame update
    void Start()
    {
        component.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && activeScene == false)
        {
            component.SetActive(true);
            selector.SetActive(true);
            activeScene = true;
        }

        else if(Input.GetKeyDown(KeyCode.Q) && activeScene == true)
        {
            component.SetActive(false);
            selector.SetActive(false);
            activeScene = false;
        }
    }
}
