using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    private GameObject rightHand;
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject leftElbow;
    [SerializeField]
    private GameObject rightElbow;

    [SerializeField]
    private float maxTimeSpan;
    [SerializeField]
    private int runningCount;
    [SerializeField]
    private int maxRunningCount;
    private float timeSpan;
    [SerializeField]
    private bool leftHandPosition;
    private bool previousLeftHandPosition;
    [SerializeField]
    private bool rightHandPosition;
    private bool previousRightHandPosition;


    public int RunningCount
    {
        get
        {
            return this.runningCount;
        }
        set
        {
            this.runningCount = value;
        }
    }

    public float TimeSpan
    {
        get
        {
            return this.timeSpan;
        }
        set
        {
            this.timeSpan = value;
        }
    }
    void Start()
    {
        if (rightHand.transform.position.y >= rightElbow.transform.position.y)
        {
            rightHandPosition = true;
        }
        else
        {
            rightHandPosition = false;
        }
        if (leftHand.transform.position.y >= leftElbow.transform.position.y)
        {
            leftHandPosition = true;
        }
        else
        {
            leftHandPosition = false;
        }
        previousRightHandPosition = rightHandPosition;
        previousLeftHandPosition = leftHandPosition;
        runningCount = 0;
        timeSpan = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Cooldown>().StopScript == true)
        {
            if (rightHand.transform.position.y >= rightElbow.transform.position.y)
            {
                rightHandPosition = true;
            }
            else
            {
                rightHandPosition = false;
            }
            if (leftHand.transform.position.y >= leftElbow.transform.position.y)
            {
                leftHandPosition = true;
            }
            else
            {
                leftHandPosition = false;
            }
            timeSpan += Time.deltaTime;
            //Debug.Log(speed);
            if (timeSpan >= maxTimeSpan)
            {
                runningCount = 0;
                timeSpan = 0;
                previousLeftHandPosition = leftHandPosition;
                previousRightHandPosition = rightHandPosition;
            }
            if (((leftHandPosition == true && rightHandPosition == false) && (previousLeftHandPosition == false && previousRightHandPosition == true)) && timeSpan < maxTimeSpan)
            {
                runningCount++;
                timeSpan = 0;
                previousLeftHandPosition = true;
                previousRightHandPosition = false;
                if (runningCount == maxRunningCount)
                {
                    Debug.Log("Running" + runningCount);
                    GameObject.Find("GestureRecognition").GetComponent<Text>().text = "Running";
                    GameObject.Find("GestureRecognition").GetComponent<Text>().color = Color.green;
                    GetComponent<Cooldown>().Reset();
                    StartCoroutine(GetComponent<Cooldown>().Timer());
                }
            }
            if (((leftHandPosition == false && rightHandPosition == true) && (previousLeftHandPosition == true && previousRightHandPosition == false)) && timeSpan < maxTimeSpan)
            {
                runningCount++;
                timeSpan = 0;
                previousLeftHandPosition = false;
                previousRightHandPosition = true;
                if (runningCount == maxRunningCount)
                {
                    Debug.Log("Running" + runningCount);
                    GameObject.Find("GestureRecognition").GetComponent<Text>().text = "Running";
                    GameObject.Find("GestureRecognition").GetComponent<Text>().color = Color.green;
                    GetComponent<Cooldown>().Reset();
                    StartCoroutine(GetComponent<Cooldown>().Timer());
                }
            }
        }
    }
}
