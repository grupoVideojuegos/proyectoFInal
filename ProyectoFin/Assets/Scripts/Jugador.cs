using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    //variables 
    private float movementInputDirection;
    private int facingDirection = 1;
    [SerializeField] public float velocidad = 1.0f;
    [SerializeField] float maxVelocidad = 5.0f;
    [SerializeField] public bool tocaPiso;
    [SerializeField] float fuerzaSalto = 6.4f;
    public float wallHopForce;
    public float wallJumpForce;

    public Vector2 wallHopDirection;
    public Vector2 wallJumpDirection;
    private bool isTouchingWall;
    private bool isWallSliding;
    private Rigidbody2D rbd2D;
    private Animator anim;
    private bool salto;
    public Transform groundCheck;
    public Transform wallCheck;
    public float groundCheckRadius;
    public float wallCheckDistance;
    public LayerMask whatIsGround;
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
        CheckInput();
        CheckMovementDirection();
 
        CheckIfWallSliding();

        anim.SetFloat("Velocidad",Mathf.Abs(rbd2D.velocity.x));
        anim.SetBool("TocaPiso", tocaPiso);
        if (Input.GetKeyDown(KeyCode.UpArrow) && tocaPiso){
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
        
    }
    private void CheckIfWallSliding()
    {
        if (isTouchingWall && !tocaPiso && rbd2D.velocity.y < 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }
    private void CheckSurroundings()
    {
        tocaPiso = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
    }

   
    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonUp("Jump"))
        {
            rbd2D.velocity = new Vector2(rbd2D.velocity.x, rbd2D.velocity.y * variableJumpHeightMultiplier);
        }

    }
    private void Jump()
    {
        if (canJump && !isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            amountOfJumpsLeft--;
        }
        else if (isWallSliding && movementInputDirection == 0 && canJump) //Wall hop
        {
            isWallSliding = false;
            amountOfJumpsLeft--;
            Vector2 forceToAdd = new Vector2(wallHopForce * wallHopDirection.x * -facingDirection, wallHopForce * wallHopDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
        }
        else if ((isWallSliding || isTouchingWall) && movementInputDirection != 0 && canJump)
        {
            isWallSliding = false;
            amountOfJumpsLeft--;
            Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirection.x * movementInputDirection, wallJumpForce * wallJumpDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
        }
    }


    private void CheckMovementDirection()
    {
        if (isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if (!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }

        if (rbd2D.velocity.x != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }
   

    public void OnBecameInvisible()
    {
        transform.position = new Vector3(-20,-6, 0);
    }
    private void ApplyMovement()
    {

        if (tocaPiso)
        {
            rbd2D.velocity = new Vector2(movementSpeed * movementInputDirection, rbd2D.velocity.y);
        }
        else if (!tocaPiso && !isWallSliding && movementInputDirection != 0)
        {
            Vector2 forceToAdd = new Vector2(movementForceInAir * movementInputDirection, 0);
            rbd2D.AddForce(forceToAdd);

            if (Mathf.Abs(rbd2D.velocity.x) > movementSpeed)
            {
                rbd2D.velocity = new Vector2(movementSpeed * movementInputDirection, rbd2D.velocity.y);
            }
        }
        else if (!tocaPiso && !isWallSliding && movementInputDirection == 0)
        {
            rbd2D.velocity = new Vector2(rbd2D.velocity.x * airDragMultiplier, rbd2D.velocity.y);
        }

        if (isWallSliding)
        {
            if (rbd2D.velocity.y < -wallSlideSpeed)
            {
                rbd2D.velocity = new Vector2(rbd2D.velocity.x, -wallSlideSpeed);
            }
        }
    }

    private void Flip()
    {
        if (!isWallSliding)
        {
            facingDirection *= -1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }
}
