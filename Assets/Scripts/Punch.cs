using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Punch : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    private GameObject rightHand;
    [SerializeField]
    private GameObject rightElbow;
    [SerializeField]
    private GameObject rightShoulder;

    private float speed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float armLength;
    [SerializeField]
    private float startThreshold;
    private float previousPosition;
    [SerializeField]
    private int speedCount;
    [SerializeField]
    private int maxSpeedCount;
    [SerializeField]
    private bool handPositionStart;
    [SerializeField]
    private bool handPositionEnd;

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

    public bool HandPositionStart {
        get
        {
            return this.handPositionStart;
        }
        set
        {
            this.handPositionStart = value;
        }
    }
    void Start()
    {
        previousPosition = Mathf.Abs(rightHand.transform.position.z);
        if (Mathf.Abs(rightHand.transform.position.z) - Mathf.Abs(rightShoulder.transform.position.z) >= armLength)
        {
            handPositionEnd = true;
        }
        else
        {
            handPositionEnd = false;
        }
        if (Mathf.Abs(rightHand.transform.position.z) - Mathf.Abs(rightShoulder.transform.position.z) <= startThreshold)
        {
            handPositionStart = true;
        }
        else
        {
            handPositionStart = false;
        }
        speedCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Cooldown>().StopScript == true)
        {
            if (Mathf.Abs(Mathf.Abs(rightHand.transform.position.z) - Mathf.Abs(rightShoulder.transform.position.z)) <= startThreshold)
            {
                handPositionStart = true;
            }
            if (Mathf.Abs(Mathf.Abs(rightHand.transform.position.z) - Mathf.Abs(rightShoulder.transform.position.z)) >= armLength && handPositionStart == true)
            {
                handPositionEnd = true;
                handPositionStart = false;
            }
            else
            {
                handPositionEnd = false;
            }
            speed = (Mathf.Abs(Mathf.Abs(rightHand.transform.position.z) - previousPosition)) / (Time.deltaTime);
            //Debug.Log(speed);
            //Debug.Log(Mathf.Abs(Mathf.Abs(rightHand.transform.position.z) - Mathf.Abs(rightShoulder.transform.position.z)));
            previousPosition = Mathf.Abs(rightHand.transform.position.z);
            if (speed >= maxSpeed)
            {
                speedCount++;
            }
            if (speed < maxSpeed)
            {
                speedCount = 0;
                handPositionEnd = false;
            }
            if (speedCount > maxSpeedCount && handPositionEnd == true)
            {
                Debug.Log("Punch");
                GameObject.Find("GestureRecognition").GetComponent<Text>().text = "Punch";
                GameObject.Find("GestureRecognition").GetComponent<Text>().color = Color.green;
                speedCount = 0;
                handPositionStart = false;
                GetComponent<Cooldown>().Reset();
                StartCoroutine(GetComponent<Cooldown>().Timer());
            }
        }
    }
}
