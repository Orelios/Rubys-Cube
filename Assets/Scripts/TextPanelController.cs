using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextPanelController : ScreenManager
{
    private GameObject[] textElements;
    private int currentIndex = 0;

    private void Start()
    {
        textElements = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            textElements[i] = GameObject.Find("Text" + (i + 1));
            textElements[i].SetActive(i == 0);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentIndex = (currentIndex + 1) % textElements.Length;

            if (currentIndex == 0)
            {
                LoadMainScene();
            }
            else
            {
                textElements[currentIndex].SetActive(true);
            }
        }
    }
}
