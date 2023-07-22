using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection3 : MonoBehaviour
{
    public bool isPuzzleComplete = false;
    public GameObject fragment1, fragment2, fragment3;
    // Start is called before the first frame update
    void Start()
    {
        fragment1.SetActive(false);
        fragment2.SetActive(false);
        fragment3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPuzzleComplete == true)
        {
            fragment1.SetActive(true);
            fragment2.SetActive(true);
            fragment3.SetActive(true);
        }
    }

    public void SetPuzzleComplete()
    {
        isPuzzleComplete = true;
    }
}