using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacementHautBas : MonoBehaviour {
    Vector3 deplacement;
    public float speed = 3f;
    public bool init = false;
    public float iniY;
    // Use this for initialization
    void Start () {
        iniY = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        if (init == false)
        {
            deplacement = new Vector3(0, speed,0);
        }
        transform.position += deplacement*Time.deltaTime;
        if (transform.position.y > iniY+10f)
        {
            init = true;
            deplacement = new Vector3(0, -speed, 0);
        }
        if (transform.position.y < iniY-10f)
        {
            deplacement = new Vector3(0, speed, 0);
        }
	}
}
