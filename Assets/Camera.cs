using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform target;
    public GameObject ay;

    void Start()
    {
        ay.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ay.GetComponent<Player>().alive == true)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
    }

}