using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{

    AudioSource audioSource;
    public GameObject ay;


    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ay.GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ay.GetComponent<Player>().alive == false)
        {
            audioSource.mute = true;
        }
    }
}
