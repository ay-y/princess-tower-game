using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public int health;
    private float timer = 0.0f;
    private float timer2 = 4.0f;
    private bool flash = false;
    private SpriteRenderer sprRend;
    private Transform transfrom;
    public AudioClip dead;
    AudioSource audioSource;
    private bool notplayed = true;

    // Use this for initialization
    void Start()
    {
        health = 3;
        sprRend = GetComponent<SpriteRenderer>();
        transfrom = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
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


        if (timer >= 0.0f)
        {
            if (flash)
            {
                flash = false;
                sprRend.material.color = new Color(1, 1, 1, 1);
            }
            else
            {
                flash = true;
                sprRend.material.color = new Color(1, 1, 1, 0);
            }
        }
        else
        { 
              flash = false;
              sprRend.material.color = new Color(1, 1, 1, 1);
        }
        if (health <= 0)
        {
            timer2 -= Time.deltaTime;
            if (notplayed)
            {
                audioSource.PlayOneShot(dead, 1.0f);
                notplayed = false;
            }
            transfrom.transform.position = new Vector3(transfrom.transform.position.x, transfrom.transform.position.y, 1.0f);
            if (timer2 <= 0.0f)
                Application.LoadLevel(Application.loadedLevel);
        }
    }
}
