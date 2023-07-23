using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject player;
    public GameObject dialogueBox;
    public string[] lines;
    public float textSpeed;
    public int index = 0;
    public bool branching = false;
    public bool endLineChecker = false;
    public bool notFirst = false;
    public bool startLine = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0) && endLineChecker == false)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

        if (startLine == true && notFirst == true)
        {
            StartDialogue();
            startLine = false;
            
        }

        if (!dialogueBox.activeSelf && notFirst == true)
        {
            startLine = true;
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        
        if (index < lines.Length - 1 && endLineChecker == false)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        else
        {
            index = 0;
            if (branching == true)
            {
                endLineChecker = true;
                Debug.Log("EndLine");
            }
            else
            {
                player.GetComponent<PlayerMovement>().isMoveable = true;
                player.GetComponent<PlayerMovement>().isInteracting = false;
                textComponent.text = string.Empty;
                notFirst = true;
                gameObject.SetActive(false);
            }
            
        }
    }
}
