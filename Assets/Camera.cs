using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    private Rigidbody rigidBody;
    public float cameraSpeed;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        rigidBody.velocity = new Vector3(0.0f, cameraSpeed, 0.0f);

    }
}
