using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BranchType
{
    Branch1,
    Branch2
}


public class DialogueButton : MonoBehaviour
{
    public BranchType branch;
    public bool pressed = false;
    public TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnButtonClick()
    {
        pressed = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
