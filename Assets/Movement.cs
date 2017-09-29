using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody rigidBody;
    private bool onGround = false;
    public bool onLeft = false;
    public bool onRight = false;
    private bool jumpOn = false;
    AudioSource audioSource;
    public AudioClip jump;
    public AudioClip slide;
    public AudioClip land;
    public AudioClip hit;
    private float jumpTimer = 0.0f;
    private float slideSoundTimer = 0.0f;

    private SpriteRenderer sprRend;
    public float speedMultiplier = 40.0f;
    public float airMultiplier = 10.0f;
    public float jumpForce = 400f;
    public float maxSpeed = 8.5f;
    public float maxUpSpeed = 10.0f;
    public float groundFriction = 0.97f;
    public float airFriction = 0.97f;
    public bool alive;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        alive = GetComponent<Player>().alive;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bat") 
            audioSource.PlayOneShot(hit, 2.5f);
        else
           audioSource.PlayOneShot(land, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
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
            {
                anim.SetBool("onWall", false);
                
            }
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
                audioSource.PlayOneShot(jump, 1.5f);
            }



            if (onGround)
                rigidBody.velocity = new Vector3(rigidBody.velocity.x * groundFriction, rigidBody.velocity.y, rigidBody.velocity.z);
            else
                rigidBody.velocity = new Vector3(rigidBody.velocity.x * airFriction, rigidBody.velocity.y, rigidBody.velocity.z);
        }
    }
    void FixedUpdate()
    {
        if (alive) {

            Vector3 down = transform.TransformDirection(Vector3.down);
            Vector3 leftOrigin = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
            Vector3 rightOrigin = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);


            if (Physics.Raycast(transform.position, down, 1.0f, 9) || Physics.Raycast(leftOrigin, down, 1.0f, 9) || Physics.Raycast(rightOrigin, down, 1.0f, 9))
        {
            onGround = true;
            anim.SetBool("onGround", true);
        }
        else
        {
            onGround = false;
            anim.SetBool("onGround", false);
        }

        Vector3 left = transform.TransformDirection(Vector3.left);
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 belowOrigin = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        Vector3 aboveOrigin = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);


        if ((Physics.Raycast(transform.position, left, 0.5f, 9) || Physics.Raycast(belowOrigin, left, 0.5f, 9) || Physics.Raycast(aboveOrigin, left, 0.5f, 9)) && !onGround)
        {
            onLeft = true;
        }
        else
            onLeft = false;

        if ((Physics.Raycast(transform.position, right, 0.5f, 9) || Physics.Raycast(belowOrigin, right, 0.5f, 9) || Physics.Raycast(aboveOrigin, right, 0.5f, 9)) && !onGround)
        {
            onRight = true;
        }
        else
            onRight = false;

        if (onLeft)
        {
            if (rigidBody.velocity.x <= 1.0f)
            {
                rigidBody.velocity = new Vector3(0.0f, rigidBody.velocity.y * 0.99f, rigidBody.velocity.z);
                if (rigidBody.velocity.y < -2.0f && (Input.GetAxis("Vertical") > -1.0f))
                        rigidBody.velocity = new Vector3(rigidBody.velocity.x, -2.0f, 0.0f);
                    else if (rigidBody.velocity.y < -5.0f && (Input.GetAxis("Vertical") <= -1.0f))
                        rigidBody.velocity = new Vector3(rigidBody.velocity.x, -5.0f, 0.0f);
                }

            if (jumpOn)
            {
                rigidBody.AddForce(Vector3.up * jumpForce * 1);
                rigidBody.AddForce(Vector3.right * jumpForce * 4);
                jumpOn = false;
                audioSource.PlayOneShot(jump, 1.5f);
            }
            if (Input.GetAxis("Horizontal") >= 1)
            {
                rigidBody.velocity = new Vector3(5.0f, rigidBody.velocity.y, 0.0f);
            }
        }
        else if (onRight)
        {
            if (rigidBody.velocity.x >= -1.0f)
            {
                rigidBody.velocity = new Vector3(0.0f, rigidBody.velocity.y * 0.99f, rigidBody.velocity.z);
                    if (rigidBody.velocity.y < -2.0f && (Input.GetAxis("Vertical") > -1.0f))
                        rigidBody.velocity = new Vector3(rigidBody.velocity.x, -2.0f, 0.0f);
                    else if (rigidBody.velocity.y < -5.0f && (Input.GetAxis("Vertical") <= -1.0f))
                        rigidBody.velocity = new Vector3(rigidBody.velocity.x, -5.0f, 0.0f);
                }
            if (jumpOn)
            {
                rigidBody.AddForce(Vector3.up * jumpForce * 1);
                rigidBody.AddForce(Vector3.left * jumpForce * 4);
                jumpOn = false;
                audioSource.PlayOneShot(jump, 1.5f);
            }
            if (Input.GetAxis("Horizontal") <= -1)
            {
                rigidBody.velocity = new Vector3(-5.0f, rigidBody.velocity.y, 0.0f);
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

        // set a maximum upward speed
        if (rigidBody.velocity.y > maxUpSpeed)
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, maxUpSpeed, 0.0f);
        }
        // set a maximum downward speed
        if (rigidBody.velocity.y < (-maxUpSpeed *2))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, (-maxUpSpeed * 2), 0.0f);
        }

        // smooth out colliding with ceilings ( stops friction by 
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), 0.65f, 9))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, -0.1f, 0.0f);
        }
        }
        
        }
}