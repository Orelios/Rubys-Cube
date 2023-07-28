using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectionCompletionPopUp : MonoBehaviour
{
    public static ProjectionCompletionPopUp instance;

    [SerializeField] private string[] projectionComplete;
    [SerializeField] private float maxAmountOfTimeUp;
    [SerializeField] TextMeshProUGUI completionText;

    private string projectionNumber = "";
    private float amountOfTimeUp;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        amountOfTimeUp = maxAmountOfTimeUp;
        projectionComplete[0] = projectionComplete[0];
    }
    void Update()
    {
        ShowText();
    }
    public void ProjectionNumber(int projNum)
    {
        //Debug.Log(projNum); 
        projectionComplete[projNum] = projectionComplete[projNum];
        projectionNumber = projectionComplete[projNum];
        //Debug.Log(projectionNumber); 
    }

    public void ShowText()
    {
        if (amountOfTimeUp >= 0 && projectionNumber != "")
        {
            completionText.text = projectionNumber;
            amountOfTimeUp -= Time.deltaTime;
            if (amountOfTimeUp < 0)
            {
                projectionNumber = "";
                projectionComplete[0] = projectionComplete[0];
                completionText.text = projectionNumber;
                amountOfTimeUp = maxAmountOfTimeUp;
            }
        }
    }

}
