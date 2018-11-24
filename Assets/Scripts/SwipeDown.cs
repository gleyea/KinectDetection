using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeDown : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    private GameObject rightHand;
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject hipCenter;
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
    private int hipCount;
    private bool hipPosition;
    private bool previousHipPosition;

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

    public int HipCount
    {
        get
        {
            return this.hipCount;
        }
        set
        {
            this.hipCount = value;
        }
    }

    void Start()
    {
        previousRightPosition = rightHand.transform.position.y;
        if (rightHand.transform.position.y <= (hipCenter.transform.position.y - 0.1) && leftHand.transform.position.y >= head.transform.position.y)
        {
            hipPosition = true;
        }
        else
        {
            hipPosition = false;
        }
        previousHipPosition = hipPosition;
        if (hipPosition == true)
        {
            hipCount = 1;

        }
        else
        {
            hipCount = 0;
        }
        speedCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Cooldown>().StopScript == true)
        {
            if (rightHand.transform.position.y <= (hipCenter.transform.position.y - 0.1) && leftHand.transform.position.y >= head.transform.position.y)
            {
                hipPosition = true;
            }
            else
            {
                hipPosition = false;
            }
            if (hipPosition != previousHipPosition)
            {
                hipCount++;
            }
            speed = Mathf.Abs((rightHand.transform.position.y - previousRightPosition)) / Time.deltaTime;
            //Debug.Log(speed);
            previousRightPosition = rightHand.transform.position.y;
            if (speed >= maxSpeed)
            {
                speedCount++;
            }
            if (speed < maxSpeed)
            {
                speedCount = 0;
                if (hipPosition == true)
                {
                    hipCount = 1;

                }
                else
                {
                    hipCount = 0;
                }
            }
            if (hipCount == 3)
            {
                hipCount = 1;
            }
            if (speedCount > maxSpeedCount && hipPosition == true)
            {
                Debug.Log("Swipe Down");
                GameObject.Find("GestureRecognition").GetComponent<Text>().text = "Swipe Down";
                GameObject.Find("GestureRecognition").GetComponent<Text>().color = Color.green;
                speedCount = 0;
                hipCount = 0;
                GetComponent<Cooldown>().Reset();
                GetComponent<MenuReturn>().Return();
            }
        }
    }
}
