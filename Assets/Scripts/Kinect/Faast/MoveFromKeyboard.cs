using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFromKeyboard : MonoBehaviour {

    // Use this for initialization

    private Vector3 position;

    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
        set
        {
            transform.position = value;
        }
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x + 0.1f, gameObject.GetComponent<Transform>().position.y, gameObject.GetComponent<Transform>().position.z);
        }
	}
}
