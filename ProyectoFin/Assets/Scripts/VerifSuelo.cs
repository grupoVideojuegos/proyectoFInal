using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifSuelo : MonoBehaviour
{

    private Jugador player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Jugador>();

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            player.isGrounded = true;
        }
        
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            player.isGrounded = false;
        }
    }
}
