using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    private float horizontal;
    private float horizontalMove;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 20f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private Vector2 dashDir;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    private void Start() {
        tr.emitting = false;
    }


    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        horizontalMove = horizontal * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        

       

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("IsJumping", true);
        }

         if (Input.GetButtonUp("Jump")){
            animator.SetBool("IsJumping", false);

         }

       


        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
           StartCoroutine(Dash());
        }

        Flip();
    }

    // /// <summary>
    // /// OnCollisionEnter is called when this collider/rigidbody has begun
    // /// touching another rigidbody/collider.
    // /// </summary>
    // /// <param name="other">The Collision data associated with this collision.</param>
    // private void OnCollisionEnter2D(Collision other)
    // {   
    //     Single platform = other.GetComponent<Single>();

    //     if(platform != null) {

    //         if(other.GetComponent<SpriteRenderer>().color == Color.blue) {
    //             speed = speed*2;
    //         }
    //     }
      

      
    // }
    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180, 0f);
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
        tr.emitting = true;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 1f;

        dashDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(dashDir == Vector2.zero){
            dashDir = new Vector2(transform.localScale.x, 0f);

        }

        
        rb.velocity = dashDir.normalized * dashingPower;

    
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;

        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}