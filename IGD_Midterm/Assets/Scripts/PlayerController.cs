using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public float jumpForce;
    private Rigidbody2D rb;
    public float speed;
    Vector2 movement;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;
    public Transform groundPos;  //feetpos
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    //private bool doubleJump;
    Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() //!
    {
        //moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = rb.velocity;
        //velocity.x += movement.x * speed * Time.fixedDeltaTime;
        //rb.velocity = velocity;
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);  
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKey(jumpKey))  //jump
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (isGrounded == false && Input.GetKey(jumpKey))  //jump
        {
            isJumping = false;
        }
        
        if (isGrounded == true)
        {
            animator.SetBool("isIDLE", true);
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isIDLE", false);
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKey(jumpKey) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }

            if (Input.GetKeyUp(jumpKey))
            {
                isJumping = false;
            }
        }
        // left and right movement
        movement = Vector2.zero;
        if (Input.GetKey(rightKey))
        {
            movement += Vector2.right;
        }

        if (Input.GetKey(leftKey))
        {
            movement += Vector2.left;
        }
        //if (Input.GetKey(jumpKey))
        //{
        //    animator.SetBool("isJumping", true);
        //}
        //else
        //{
        //    animator.SetBool("isJumping", false);
        //}

        if (movement.x == 0)   //for animation just check the teacher sample
        {
            animator.SetBool("isWalking", false);
           // animator.SetBool("isIDLE", true);
        }
        else
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIDLE", false);

        }

        if (movement.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);



        }
        else if (movement.x < 0)
        {
            
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
    }
}


