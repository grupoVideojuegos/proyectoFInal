using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFalling : MonoBehaviour
{
    // Start is called before the first frame update
    public float fallDelay = 0.5f;
    public float respawnDelay = 3.0f;

    private Rigidbody2D rb;
    private BoxCollider2D bx;
    private Vector3 start;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bx = GetComponent<BoxCollider2D>();
        start = transform.position;
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
            Invoke("Respawn", fallDelay + respawnDelay);
        }
    }
    void Fall()
    {
        rb.isKinematic = false;
        bx.isTrigger = true;
    }
    void Respawn()
    {
        transform.position = start;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        bx.isTrigger = false;
    }
}
