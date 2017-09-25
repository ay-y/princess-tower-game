using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlatformMoveLeftRight : MonoBehaviour
{
    private float timer; private bool direction; private Rigidbody rigidBody; public float speed;
    public float duration = 4;
    
    // Use this for initialization  
    void Start() {
        direction = false;
        timer = duration;
        rigidBody = GetComponent<Rigidbody>();
        
    }
    
    // Update is called once per frame  
    void Update() {
        timer -= Time.deltaTime;
        if (timer > 0.0f)
        {
            rigidBody.velocity = Vector3.right * speed;
        }
        else if (timer > -duration)
        {
            rigidBody.velocity = Vector3.left * speed;
        }
        else
        {
            timer = duration;
        }
    }
}