﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushUp : MonoBehaviour
{

    public Player player;
    public Rigidbody rig;
    private float timer = 0.0f;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rig = player.GetComponent<Rigidbody>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && timer < 0.0f)
        {
            rig.velocity = new Vector3(rig.velocity.x, 0.0f, 0.0f);
            rig.AddForce(Vector3.up * 400f);
            timer = 1.0f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (timer >= -0.1f)
        {
            timer -= Time.deltaTime;
        }

    }
}
