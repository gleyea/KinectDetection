using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeUp : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    private GameObject rightHand;
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject head;

    private float speed;
    [SerializeField]
    private float maxSpeed;

    private float previousLeftPosition;
    private float previousRightPosition;
    [SerializeField]
    private int speedCount;
    [SerializeField]
    private int maxSpeedCount;
    [SerializeField]
    private int headCount;
    private bool headPosition;
    private bool previousHeadPosition;

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

    public int HeadCount
    {
        get
        {
            return this.headCount;
        }
        set
        {
            this.headCount = value;
        }
    }
    void Start()
    {
        previousRightPosition = rightHand.transform.position.y;
        previousLeftPosition = leftHand.transform.position.y;
        if (rightHand.transform.position.y >= head.transform.position.y && leftHand.transform.position.y >= head.transform.position.y)
        {
            headPosition = true;
        }
        else
        {
            headPosition = false;
        }
        previousHeadPosition = headPosition;
        if (headPosition == true)
        {
            headCount = 1;

        }
        else
        {
            headCount = 0;
        }
        speedCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Cooldown>().StopScript == true)
        {
            if (rightHand.transform.position.y >= head.transform.position.y && leftHand.transform.position.y >= head.transform.position.y)
            {
                headPosition = true;
            }
            else
            {
                headPosition = false;
            }
            if (headPosition != previousHeadPosition)
            {
                headCount++;
            }
            speed = (Mathf.Abs((rightHand.transform.position.y - previousRightPosition) / (Time.deltaTime)) + Mathf.Abs((leftHand.transform.position.y - previousLeftPosition) / (Time.deltaTime))) / 2;
            //Debug.Log(speed);
            previousRightPosition = rightHand.transform.position.y;
            previousLeftPosition = leftHand.transform.position.y;
            previousHeadPosition = headPosition;
            if (speed >= maxSpeed)
            {
                speedCount++;
            }
            if (speed < maxSpeed)
            {
                speedCount = 0;
                if (headPosition == true)
                {
                    headCount = 1;

                }
                else
                {
                    headCount = 0;
                }
            }
            if (headCount == 3)
            {
                headCount = 1;
            }
            if (speedCount > maxSpeedCount && headCount == 2)
            {
                Debug.Log("Swipe Up");
                GameObject.Find("GestureRecognition").GetComponent<Text>().text = "Swipe Up";
                GameObject.Find("GestureRecognition").GetComponent<Text>().color = Color.green;
                speedCount = 0;
                headCount = 0;
                GetComponent<Cooldown>().Reset();
                StartCoroutine(GetComponent<Cooldown>().Timer());
            }
        }
    }
}
