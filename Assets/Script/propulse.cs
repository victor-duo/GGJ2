using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propulse : MonoBehaviour {
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<playerMove>().plateforme=true;
        }
        
    }
    // Use this for initialization
    void Start () {

    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<playerMove>().grounded = false;
            col.gameObject.GetComponent<playerMove>().speed = Mathf.Abs(col.gameObject.GetComponent<Rigidbody2D>().velocity.x);
        }
    }
    // Update is called once per frame
    void Update () {
    }
}
