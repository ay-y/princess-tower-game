using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLevel3 : MonoBehaviour
{

    private Rigidbody rigidBody;
    public bool started = false;
    private float timer = 4.0f;

    public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!started)
        {
            audioSource.Play();
            started = true;
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0.0f)
        {
            Application.LoadLevel("Tower1");
        }
    }
}
