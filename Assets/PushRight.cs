using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRight : MonoBehaviour
{

    public Player player;
    public Rigidbody rig;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rig = player.GetComponent<Rigidbody>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rig.AddForce(Vector3.right * 1000f);
            rig.AddForce(Vector3.up * 500f);
        }
    }
    // Update is called once per frame
    void Update()
    {


    }
}
