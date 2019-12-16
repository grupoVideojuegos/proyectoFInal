using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    //variables 
    private int facingDirection = 1;
    [SerializeField] public float velocidad = 1.0f;
    [SerializeField] float maxVelocidad = 5.0f;
    [SerializeField] public bool tocaPiso;
    [SerializeField] float fuerzaSalto = 6.4f;
    public float wallHopForce;
    public float wallJumpForce;

    public Vector2 wallHopDirection;
    public Vector2 wallJumpDirection;

    private Rigidbody2D rbd2D;
    private Animator anim;
    private bool salto;
    
    // Start is called before the first frame update
    void Start()
    {
        rbd2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        wallHopDirection.Normalize();
        wallJumpDirection.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Velocidad",Mathf.Abs(rbd2D.velocity.x));
        anim.SetBool("TocaPiso", tocaPiso);
        if (Input.GetKeyDown(KeyCode.UpArrow) && tocaPiso){
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rbd2D.AddForce(Vector2.right * velocidad*horizontal);

        float velLimite = Mathf.Clamp(rbd2D.velocity.x, -maxVelocidad, maxVelocidad);
        rbd2D.velocity = new Vector2(velLimite, rbd2D.velocity.y);

        if(horizontal > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if(horizontal < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (salto)
        {
            rbd2D.AddForce(Vector2.up*fuerzaSalto,ForceMode2D.Impulse);
            salto = false; 
        }
    }

    public void OnBecameInvisible()
    {
        transform.position = new Vector3(-20,-6, 0);
    }

}
