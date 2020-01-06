using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hormiga : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] float velocidad;
    [SerializeField] Transform limLeft;
    [SerializeField] Transform limRight;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        var vel = rb.velocity;
        vel.x = Mathf.Abs(velocidad);
        rb.velocity = vel;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x < 0)
        {
            var vel = rb.velocity;
            vel.x = velocidad;
            rb.velocity = vel;
        }
        else
        {
            var vel = rb.velocity;
            vel.x = -velocidad;
            rb.velocity = vel;
        }
        if (transform.position.x == limLeft.position.x )
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            
        }
        if (transform.position.x == limRight.position.x )
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
           
        }
    }
    private void FixedUpdate()
    {
        
    }
}
