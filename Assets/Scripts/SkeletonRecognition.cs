using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonRecognition : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private GameObject head;
    [SerializeField]
    private GameObject text;
    private Vector3 previousHeadPosition;
	void Start () {
        previousHeadPosition = head.transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
		if (head.transform.position != previousHeadPosition)
        {
            text.GetComponent<Text>().text = "Skeleton recognized";
            text.GetComponent<Text>().color = Color.green;
        }
        if (head.transform.position == previousHeadPosition)
        {
            text.GetComponent<Text>().text = "Skeleton not recognized";
            text.GetComponent<Text>().color = Color.red;
        }
        previousHeadPosition = head.transform.position;
    }
}
