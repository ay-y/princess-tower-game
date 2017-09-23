using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody rigidBody;
    private bool onGround = false;
    private bool onLeft = false;
    private bool onRight = false;

	private SpriteRenderer sprRend;
    public float speedMultiplier;
    public float jumpForce;
    public float maxSpeed;
    public float groundFriction;
    public float airFriction;

    private Animator anim;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        sprRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
       // if (other.name == "player")
            onGround = true;

    }

    private void OnTriggerExit(Collider other)
    {
       // if (other.name == "player")
            onGround = false;
    }


    // Update is called once per frame
    void Update () {

        //if (onGround)
        rigidBody.AddForce(new Vector3(Input.GetAxis("Horizontal") * speedMultiplier, 0.0f, 0.0f));


        anim.SetFloat("speed", rigidBody.velocity.x);
        if (rigidBody.velocity.x < 0) {
			sprRend.flipX = true;
		}
		if (rigidBody.velocity.x > 0) {
			sprRend.flipX = false;
		}
        if (onGround && Input.GetKeyDown("space"))
            rigidBody.AddForce(Vector3.up * jumpForce);



        if (onGround)
            rigidBody.velocity = new Vector3(rigidBody.velocity.x * groundFriction, rigidBody.velocity.y, rigidBody.velocity.z);
        else
            rigidBody.velocity = new Vector3(rigidBody.velocity.x * airFriction, rigidBody.velocity.y, rigidBody.velocity.z);

    }
    void FixedUpdate()
    {
        Vector3 left = transform.TransformDirection(Vector3.left);
        Vector3 right = transform.TransformDirection(Vector3.right);


        if (rigidBody.velocity.x > maxSpeed)
        {
            rigidBody.velocity = new Vector3(maxSpeed, rigidBody.velocity.y, 0.0f);
        }
        if (rigidBody.velocity.x < -maxSpeed)
        {
            rigidBody.velocity = new Vector3(-maxSpeed, rigidBody.velocity.y, 0.0f);
        }

    }
}
