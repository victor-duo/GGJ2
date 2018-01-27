using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour {



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<playerMove>().estEnPente = transform.rotation.z*100;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
