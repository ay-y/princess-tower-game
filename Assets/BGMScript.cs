using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{

    public AudioSource audioSource;
    public Player player;
    public changeLevel finish;


    // Use this for initialization
    void Start()
    {
        audioSource.Play();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<changeLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.alive == false || finish.started == true)
        {
            audioSource.mute = true;
        }
    }
}
