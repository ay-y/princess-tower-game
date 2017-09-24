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
    private bool jumpOn = false;

    private float jumpTimer = 0.0f;

    private SpriteRenderer sprRend;
    public float speedMultiplier = 40.0f;
    public float airMultiplier = 10.0f;
    public float jumpForce = 400f;
    public float maxSpeed = 8.5f;
    public float maxUpSpeed = 10.0f;
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
        if (jumpTimer > 0.0f)
            jumpTimer -= Time.deltaTime;
        else
            jumpOn = false;

        if (Input.GetKeyDown("space") || Input.GetKeyDown("up") || Input.GetKeyDown("w"))
        {
            jumpOn = true;
            jumpTimer = 0.1f;
        }

        //if (onGround)

        if (onRight || onLeft)
        {
            anim.SetBool("onWall", true);
        }
        else
            anim.SetBool("onWall", false);

        anim.SetFloat("speed", rigidBody.velocity.x);
        if (rigidBody.velocity.x < 0)
        {
            sprRend.flipX = true;
        }
        if (rigidBody.velocity.x > 0)
        {
            sprRend.flipX = false;
        }
        if (onGround && jumpOn)
        {
            rigidBody.AddForce(Vector3.up * jumpForce);
            jumpOn = false;
        }



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


        if (Physics.Raycast(transform.position, left, 0.5f, 9) || Physics.Raycast(belowOrigin, left, 0.5f, 9) || Physics.Raycast(aboveOrigin, left, 0.5f, 9))
        {
            onLeft = true;
        }
        else
            onLeft = false;

        if (Physics.Raycast(transform.position, right, 0.5f, 9) || Physics.Raycast(belowOrigin, right, 0.5f, 9) || Physics.Raycast(aboveOrigin, right, 0.5f, 9))
        {
            onRight = true;
        }
        else
            onRight = false;

        if (onLeft && Input.GetAxis("Horizontal") < 1)
        {
            if (rigidBody.velocity.x <= 1.0f)
            {
                rigidBody.velocity = new Vector3(0.0f, rigidBody.velocity.y, rigidBody.velocity.z);
                if (rigidBody.velocity.y < -2.0f)
                    rigidBody.velocity = new Vector3(rigidBody.velocity.x, -2.0f, 0.0f);
            }

            if (jumpOn)
            {
                rigidBody.AddForce(Vector3.up * jumpForce * 1);
                rigidBody.AddForce(Vector3.right * jumpForce * 4);
                jumpOn = false;
            }
        }
        else if (onRight && Input.GetAxis("Horizontal") > -1)
        {
            if (rigidBody.velocity.x >= -1.0f)
            {
                rigidBody.velocity = new Vector3(0.0f, rigidBody.velocity.y, rigidBody.velocity.z);
                if (rigidBody.velocity.y < -2.0f)
                    rigidBody.velocity = new Vector3(rigidBody.velocity.x, -2.0f, 0.0f);
            }
            if (jumpOn)
            {
                rigidBody.AddForce(Vector3.up * jumpForce * 1);
                rigidBody.AddForce(Vector3.left * jumpForce * 4);
                jumpOn = false;
            }
        }
        else if (onGround)
        {
            rigidBody.AddForce(new Vector3(Input.GetAxis("Horizontal") * speedMultiplier, 0.0f, 0.0f));
        }
        else
            rigidBody.AddForce(new Vector3(Input.GetAxis("Horizontal") * airMultiplier, 0.0f, 0.0f));



        if (rigidBody.velocity.x > maxSpeed)
        {
            rigidBody.velocity = new Vector3(maxSpeed, rigidBody.velocity.y, 0.0f);
        }
        if (rigidBody.velocity.x < -maxSpeed)
        {
            rigidBody.velocity = new Vector3(-maxSpeed, rigidBody.velocity.y, 0.0f);
        }

        if (rigidBody.velocity.y > maxUpSpeed)
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, maxUpSpeed, 0.0f);
        }
        if (rigidBody.velocity.y < (-maxUpSpeed *2))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, (-maxUpSpeed * 2), 0.0f);
        }
    }
}
