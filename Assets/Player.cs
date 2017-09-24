using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public int health;
    // Use this for initialization
    void Start()
    {
        health = 3;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bat")
        {
            health--;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
