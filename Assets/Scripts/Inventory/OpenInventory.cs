using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject component;
    public GameObject selector;
    public bool activeScene = false;
    [SerializeField] GameObject prompts;
    [SerializeField] GameObject sideSelect;

    void Start()
    {
        component.SetActive(false);
        selector.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && activeScene == false)
        {
            component.SetActive(true);
            selector.SetActive(true);
            activeScene = true;
            prompts.SetActive(false);
        }

        else if(Input.GetKeyDown(KeyCode.Q) && activeScene == true)
        {
            component.SetActive(false);
            selector.SetActive(false);
            activeScene = false;
            prompts.SetActive(true);
        }
    }
}
