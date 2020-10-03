using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//player script
public class NYCMOvement : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;
    public float speed;
    //private float moveInput; 
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
    Animator animator;
    public NYCManager manager;
    public float health;
     public static NYCMOvement Instance;
     public Slider healthBar;
     public Text count;
        public AudioSource first;
    public AudioSource second;
    void Awake() {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
           AudioSource[] audios = GetComponents<AudioSource>();
        first = audios[0];
        second = audios[1];
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        manager= GameObject.Find("Manager").GetComponent<NYCManager>();
        health = 100;
        healthBar.value = health;

    }

    void FixedUpdate() //!
    {
        Vector2 velocity = rb.velocity;
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);  //wont lerp
    }

    void Update()
    {
        healthBar.value = health;
        count.text = "x " + manager.DiaNum.ToString();
/////
        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKey(jumpKey))  //jump
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isGrounded == true)
        {
            animator.SetBool("isIDLE", true);

        }
        else
        {
         animator.SetBool("isIDLE", false);
          
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
    
        if (movement.x == 0)   //for animation just check the teacher sample
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIDLE", false);
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

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Diamond"){
            Destroy(col.gameObject);
            manager.DiaNum+=1;
            first.Play();
            //sound
        }
    }
    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Left"){
           health-=4f;
           second.Play();
        }
         if(col.gameObject.tag == "Right"){
           health-=1f;
            second.Play();
        }
    }
}
