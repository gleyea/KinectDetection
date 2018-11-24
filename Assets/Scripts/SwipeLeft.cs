using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeLeft : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    private GameObject rightHand;
    [SerializeField]
    private GameObject rightWrist;
    [SerializeField]
    private GameObject rightElbow;
    [SerializeField]
    private GameObject centerShoulder;
    [SerializeField]
    private GameObject head;

    private float speed;
    [SerializeField]
    private float maxSpeed;

    private float previousPosition;
    [SerializeField]
    private int speedCount;
    [SerializeField]
    private int maxSpeedCount;
    [SerializeField]
    private int elbowCount;
    [SerializeField]
    private int shoulderCount;
    private bool elbowPosition;
    private bool previousElbowPosition;
    private bool shoulderPosition;
    private bool previousShoulderPosition;

    public int SpeedCount
    {
        get
        {
            return this.speedCount;
        }
        set
        {
            this.speedCount = value;
        }
    }

    public int ShoulderCount
    {
        get
        {
            return this.shoulderCount;
        }
        set
        {
            this.shoulderCount = value;
        }
    }
    void Start()
    {
        previousPosition = rightHand.transform.position.x;
        if (rightHand.transform.position.x <= centerShoulder.transform.position.x)
        {
            shoulderPosition = true;
        }
        else
        {
            shoulderPosition = false;
        }
        previousShoulderPosition = shoulderPosition;
        if (shoulderPosition == true)
        {
            shoulderCount = 0;

        }
        else
        {
            shoulderCount = 1;
        }
        speedCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Cooldown>().StopScript == true)
        {
            if (rightHand.transform.position.y > rightElbow.transform.position.y && (Mathf.Abs((Mathf.Abs(rightHand.transform.position.z) - Mathf.Abs(rightElbow.transform.position.z)))) < 0.3 && (rightHand.transform.position.y < head.transform.position.y))
            {
                if (rightHand.transform.position.x <= centerShoulder.transform.position.x)
                {
                    shoulderPosition = true;
                }
                else
                {
                    shoulderPosition = false;
                }
                if (shoulderPosition != previousShoulderPosition)
                {
                    shoulderCount++;
                }
                speed = Mathf.Abs((rightHand.transform.position.x - previousPosition) / (Time.deltaTime));
                //Debug.Log(speed);
                previousPosition = rightHand.transform.position.x;
                previousShoulderPosition = shoulderPosition;
                if (speed >= maxSpeed)
                {
                    speedCount++;
                }
                if (speed < maxSpeed)
                {
                    speedCount = 0;
                    if (shoulderPosition == true)
                    {
                        shoulderCount = 1;

                    }
                    else
                    {
                        shoulderCount = 0;
                    }
                }
                if (shoulderCount == 3)
                {
                    shoulderCount = 1;
                }
                if (speedCount > maxSpeedCount && shoulderCount == 2)
                {
                    Debug.Log("Swipe Left");
                    GameObject.Find("GestureRecognition").GetComponent<Text>().text = "Swipe Left";
                    GameObject.Find("GestureRecognition").GetComponent<Text>().color = Color.green;
                    speedCount = 0;
                    shoulderCount = 0;
                    GetComponent<Cooldown>().Reset();
                    StartCoroutine(GetComponent<Cooldown>().Timer());
                }
            }
            else
            {
                speedCount = 0;
                shoulderCount = 0;
            }
        }
    }
}
