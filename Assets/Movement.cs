using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody rigidBody;
    private bool onGround = false;
	private SpriteRenderer sprRend;
    public float velocityMultiplier;
    public float jumpForce;
	private Animator anim;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
		sprRend = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator> ();


	}

    private void OnTriggerEnter(Collider other)
    {
		onGround = true;
		anim.SetBool ("onGround", true);
    }

    private void OnTriggerExit(Collider other)
    {
		onGround = false;
		anim.SetBool ("onGround", false);

    }


    // Update is called once per frame
    void Update () {

        rigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * velocityMultiplier, rigidBody.velocity.y, rigidBody.velocity.z);
		anim.SetFloat ("speed", rigidBody.velocity.x);
		if (rigidBody.velocity.x < 0) {
			sprRend.flipX = true;
		}
		if (rigidBody.velocity.x > 0) {
			sprRend.flipX = false;
		}
		if (onGround && Input.GetKeyDown ("space")) {
			rigidBody.AddForce (Vector3.up * jumpForce);
		}
    }
}
