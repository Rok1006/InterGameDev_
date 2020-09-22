using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    Vector2 movement;

    public KeyCode leftKey;
    public KeyCode rightKey;
     public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode jumpKey;


    // public Transform groundPos;  //feetpos
    // private bool isGrounded;
    // public float checkRadius;
    // public LayerMask whatIsGround;

    Animator playeranim;
    // Start is called before the first frame update
    void Start()
    {
        playeranim = GetComponent<Animator>();
           rb = GetComponent<Rigidbody2D>();
    }

       void FixedUpdate() //!
    {
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed); 
    }

    void Update()
    {
         movement = Vector2.zero;
        if (Input.GetKey(rightKey))
        {
            movement += Vector2.right;
        }

        if (Input.GetKey(leftKey))
        {
            movement += Vector2.left;
        }
        //   if (Input.GetKey(upKey))
        // {
        //     movement += Vector2.up;
        // }
        //   if (Input.GetKey(downKey))
        // {
        //     movement += Vector2.down;
        // }

         if (movement.x == 0 )   //for animation just check the teacher sample
        {
            playeranim.SetBool("isWalking", false);
            playeranim.SetBool("isIDLE", true);
        }
        else
        {
            playeranim.SetBool("isWalking", true);
            playeranim.SetBool("isIDLE", false);
        }
         if (movement.y == 0)   //for animation just check the teacher sample
        {
            // playeranim.SetBool("isWalking", false);
            // playeranim.SetBool("isIDLE", true);
        }
        else
        {
            playeranim.SetBool("isWalking", true);
            playeranim.SetBool("isIDLE", false);
        }


        if (movement.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (movement.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    

        
    }
}
