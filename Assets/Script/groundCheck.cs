using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour {
    private playerMove player;
	// Use this for initialization
	void Start () {
        player = gameObject.GetComponentInParent<playerMove>();
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        player.grounded = true;
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        player.grounded = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
    }
}
