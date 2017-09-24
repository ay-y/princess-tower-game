using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public int health;
    private float timer = 0.0f;
    // Use this for initialization
    void Start()
    {
        health = 3;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bat" && timer < 0.0f)
        {
            health--;
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
        if (health <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
