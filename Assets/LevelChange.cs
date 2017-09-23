using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour {

    private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
    private void OnTriggerEnter(Collider other)
    {

        Application.LoadLevel("Tower2");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
