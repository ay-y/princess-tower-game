using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{

    public AudioSource audioSource;
    public Player player;


    // Use this for initialization
    void Start()
    {
        audioSource.Play();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.alive == false)
        {
            audioSource.mute = true;
        }
    }
}
