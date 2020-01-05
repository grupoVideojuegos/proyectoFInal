using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFalling : MonoBehaviour
{
    // Start is called before the first frame update
    public float fallDelay = 1.0f;

    private Rigidbody2D rb;
    private BoxCollider2D bx;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bx = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("Fall",fallDelay);
        }
    }
    void Fall()
    {
        rb.isKinematic = false;
        bx.isTrigger = true;
    }
}
