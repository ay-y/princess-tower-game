using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {


    public int hp;
	// Use this for initialization
	void Start () {
        hp = 3;
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bat")
        {
            hp--;
        }
    }
    // Update is called once per frame
    void Update () {
		if (hp == 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
	}
}
