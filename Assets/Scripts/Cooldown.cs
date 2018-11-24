using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour {

    // Use this for initialization
    private bool stopScript;

    public void Reset()
    {
        GetComponent<Punch>().HandPositionStart = false;
        GetComponent<Punch>().SpeedCount = 0;

        GetComponent<SwipeLeft>().SpeedCount = 0;
        GetComponent<SwipeLeft>().ShoulderCount = 0;

        GetComponent<SwipeRight>().SpeedCount = 0;
        GetComponent<SwipeRight>().ElbowCount = 0;

        GetComponent<SwipeUp>().SpeedCount = 0;
        GetComponent<SwipeUp>().HeadCount = 0;

        GetComponent<Run>().RunningCount++;
        GetComponent<Run>().TimeSpan = 0;

        GetComponent<SwipeDown>().SpeedCount = 0;
        GetComponent<SwipeDown>().HipCount = 0;
    }
    public bool StopScript {
        get
        {
            return this.stopScript;
        }
        set
        {
            this.stopScript = value;
        }
    }
	void Start () {
        stopScript = true;
    }

    public IEnumerator Timer()
    {
        stopScript = false;
        yield return new WaitForSecondsRealtime(2);
        stopScript = true;
        GameObject.Find("GestureRecognition").GetComponent<Text>().text = "Waiting...";
        GameObject.Find("GestureRecognition").GetComponent<Text>().color = Color.white;
    }
	// Update is called once per frame
}
