using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacementGaucheDroite : MonoBehaviour
{
    Vector3 deplacement;
    public float speed = 3f;
    public bool init = false;
    public float iniX;
    // Use this for initialization
    void Start()
    {
        iniX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (init == false)
        {
            deplacement = new Vector3(speed,0, 0);
        }
        transform.position += deplacement * Time.deltaTime;
        if (transform.position.x > iniX+10f)
        {
            init = true;
            deplacement = new Vector3(-speed, 0, 0);
        }
        if (transform.position.x < iniX-10f)
        {
            deplacement = new Vector3(speed, 0, 0);
        }
    }
}
