using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlideSound : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip slide;
    public Player player;
    private float timer;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        bool onRight = GameObject.FindWithTag("Player").GetComponent<Movement>().onRight;
        bool onLeft = GameObject.FindWithTag("Player").GetComponent<Movement>().onLeft;
        bool onWall = onRight || onLeft;

        if (onWall)
        {
            audioSource.enabled = true;
            if (timer < 0.001f)
            {
                audioSource.Play();
                timer += Time.deltaTime;
            } else if (timer < 1.0f && timer > 0.001f)
            {
                timer += Time.deltaTime;
            } else if (timer < 1.0f)
            {
                timer = 0.0f;
            }
        }
        else
        {
            audioSource.enabled = false;
            timer = 0.0f;
        }


    }
}

