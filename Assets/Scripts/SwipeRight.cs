using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeRight : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private GameObject rightHand;
    [SerializeField]
    private GameObject rightWrist;
    [SerializeField]
    private GameObject rightElbow;
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
    private bool elbowPosition;
    private bool previousElbowPosition;

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

    public int ElbowCount
    {
        get
        {
            return this.elbowCount;
        }
        set
        {
            this.elbowCount = value;
        }
    }

    void Start() {
        previousPosition = rightHand.transform.position.x;
        if (rightHand.transform.position.x >= rightElbow.transform.position.x + 0.1)
        {
            elbowPosition = true;
        }
        else
        {
            elbowPosition = false;
        }
        previousElbowPosition = elbowPosition;
        if (elbowPosition == true)
        {
            elbowCount = 1;

        }
        else
        {
            elbowCount = 0;
        }
        speedCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Cooldown>().StopScript == true)
        {
            if (rightHand.transform.position.y > rightElbow.transform.position.y && Mathf.Abs((Mathf.Abs(rightHand.transform.position.z) - Mathf.Abs(rightElbow.transform.position.z))) < 0.3 && (rightHand.transform.position.y < head.transform.position.y))
            {

                if (rightHand.transform.position.x >= rightElbow.transform.position.x + 0.1)
                {
                    elbowPosition = true;
                }
                else
                {
                    elbowPosition = false;
                }
                if (elbowPosition != previousElbowPosition)
                {
                    elbowCount++;
                }
                speed = Mathf.Abs((rightHand.transform.position.x - previousPosition) / (Time.deltaTime));
                //Debug.Log(speed);
                previousPosition = rightHand.transform.position.x;
                previousElbowPosition = elbowPosition;
                if (speed >= maxSpeed)
                {
                    speedCount++;
                }
                if (speed < maxSpeed)
                {
                    speedCount = 0;
                    if (elbowPosition == true)
                    {
                        elbowCount = 1;

                    }
                    else
                    {
                        elbowCount = 0;
                    }
                }
                if (elbowCount == 3)
                {
                    elbowCount = 1;
                }
                if (speedCount > maxSpeedCount && elbowCount == 2)
                {
                    Debug.Log("Swipe Right");
                    GameObject.Find("GestureRecognition").GetComponent<Text>().text = "Swipe Right";
                    GameObject.Find("GestureRecognition").GetComponent<Text>().color = Color.green;
                    speedCount = 0;
                    elbowCount = 0;
                    GetComponent<Cooldown>().Reset();
                    StartCoroutine(GetComponent<Cooldown>().Timer());
                }
            }
            else
            {
                speedCount = 0;
                elbowCount = 0;
            }
        }
    }
}
