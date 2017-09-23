using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody rigidBody;
    private bool onGround = false;
    private bool onLeft = false;
    private bool onRight = false;

    private SpriteRenderer sprRend;
    public float speedMultiplier = 66.0f;
    public float jumpForce = 400f;
    public float maxSpeed = 8.5f;
    public float groundFriction = 0.97f;
    public float airFriction = 0.97f;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        sprRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        onGround = true;
        anim.SetBool("onGround", true);
    }

    private void OnTriggerExit(Collider other)
    {
        onGround = false;
        anim.SetBool("onGround", false);
    }


    // Update is called once per frame
    void Update()
    {

        //if (onGround)



        anim.SetFloat("speed", rigidBody.velocity.x);
        if (rigidBody.velocity.x < 0)
        {
            sprRend.flipX = true;
        }
        if (rigidBody.velocity.x > 0)
        {
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
        Vector3 belowOrigin = new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z);
        Vector3 aboveOrigin = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);


        if (Physics.Raycast(transform.position, left, 0.5f) || Physics.Raycast(belowOrigin, left, 0.5f) || Physics.Raycast(aboveOrigin, left, 0.5f))
        {
            onLeft = true;
        }
        else
            onLeft = false;

        if (Physics.Raycast(transform.position, right, 0.5f) || Physics.Raycast(belowOrigin, right, 0.5f) || Physics.Raycast(aboveOrigin, right, 0.5f))
        {
            onRight = true;
        }
        else
            onRight = false;


        if (onLeft && Input.GetAxis("Horizontal") < 1)
        {
            if (rigidBody.velocity.x <= 1.0f)
            {
                rigidBody.velocity = new Vector3(0.0f, -2.0f, rigidBody.velocity.z);
                if (rigidBody.velocity.y < -5.0f)
                    rigidBody.velocity = new Vector3(rigidBody.velocity.x, -5.0f, 0.0f);
            }

            if (Input.GetKeyDown("space"))
            {
                rigidBody.AddForce(Vector3.up * jumpForce * 1);
                rigidBody.AddForce(Vector3.right * jumpForce * 2);
            }
        }
        else if (onRight && Input.GetAxis("Horizontal") > -1)
        {
            if (rigidBody.velocity.x >= -1.0f)
            {
                rigidBody.velocity = new Vector3(0.0f, -2.0f, rigidBody.velocity.z);
                if (rigidBody.velocity.y < -5.0f)
                    rigidBody.velocity = new Vector3(rigidBody.velocity.x, -5.0f, 0.0f);
            }

            if (Input.GetKeyDown("space"))
            {
                rigidBody.AddForce(Vector3.up * jumpForce * 1);
                rigidBody.AddForce(Vector3.left * jumpForce * 2);
            }
        }
        else
        {
            rigidBody.AddForce(new Vector3(Input.GetAxis("Horizontal") * speedMultiplier, 0.0f, 0.0f));
        }


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
