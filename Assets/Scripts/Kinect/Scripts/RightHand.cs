using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand : MonoBehaviour {

    // Use this for initialization
    public KinectPointController kpc;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (kpc)
        {
            transform.position = kpc.transform.position;
        }
	}
}
