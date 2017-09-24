using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] HeartSprites;
    public Image HeartUI;
    public Player player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

	}
	
	// Update is called once per frame
	void Update () {
        if (player.health >= 0)
        {
            HeartUI.sprite = HeartSprites[player.health];
        }
	}
}
