using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {
    public float maxSpeed = 3f;
    public float speed = 30f;
    public float jump = 1000f;
    public float force = 40f;
    public bool grounded;
    public bool plateforme;
    private Rigidbody2D rb;
    private Animator anim;
    private bool facingRight = true;
    [HideInInspector] public float estEnPente;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Grounded",grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        // changer la direction
        if (Input.GetAxis("Horizontal") < 0f && facingRight)
        {
            Flip();
        }
        if (Input.GetAxis("Horizontal") > 0f && !facingRight)
        {
            Flip();
        }
    }
    private void FixedUpdate()
    {
        Vector3 easeVelocity = rb.velocity;
        transform.rotation = Quaternion.Euler(0, 0, estEnPente);
        
        if (estEnPente != 0)
        {
            
            if (estEnPente < 0)
            {
                
                if (facingRight)
                {
                    rb.AddForce(Vector2.right * speed * 0.1f);
                }
                else
                {
                    rb.AddForce(Vector2.right * speed * 0.1f);
                }
            }
            else
            {
                
                if (facingRight)
                {
                    rb.AddForce(Vector2.right * speed * -0.1f);
                }
                else
                {
                    rb.AddForce(Vector2.right * speed * -0.1f);
                }
            }
        }
        


        //easeVelocity.y = rb.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;
        // h vaut 1 si on appuie a droite et -1 a gauche
        float h = Input.GetAxis("Horizontal");
        

        //creation de la friction
        if (grounded == true)
        {
            rb.velocity = easeVelocity;
        }


        //limite vitesse
        if (rb.velocity.x == maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.x < maxSpeed && rb.velocity.x > -maxSpeed)
        {
            rb.AddForce((Vector2.right * speed) * h);
        }
        if (rb.velocity.x == -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded == true)
        {
            rb.AddForce(Vector2.up * jump);
        }

        if (!grounded)
        {
            Vector3 vel = rb.velocity;
            vel.y -= 5 * Time.deltaTime;
            rb.velocity = vel;
        } 
        if (plateforme)
        {
            rb.AddForce(new Vector2(-1, 3) *15*force);
            plateforme = false;
        }
     }
    
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
