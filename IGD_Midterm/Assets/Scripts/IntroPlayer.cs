using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroPlayer : MonoBehaviour
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
    public Animator animator;
      public AudioSource land;
    public string sceneName;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
           AudioSource[] audios = GetComponents<AudioSource>();
        land = audios[0];

    }
       public void Land(){
        land.Play();
    }

    void FixedUpdate() //!
    {
        Vector2 velocity = rb.velocity;
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
            if(!LampController.Instance.lampOut){
            animator.SetBool("isIDLE", true);
            animator.SetBool("isJumping", false);
            //
            animator.SetBool("isIDLEwLamp", false);
            animator.SetBool("isJumpingwLamp", false);
            animator.SetBool("isWalkingwLamp", false);
            }
            if(LampController.Instance.lampOut){
            animator.SetBool("isIDLEwLamp", true);
            animator.SetBool("isJumpingwLamp", false);
            //
            animator.SetBool("isIDLE", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isWalking", false);
            }
        }
        else
        {
            if(!LampController.Instance.lampOut){
            animator.SetBool("isIDLE", false);
            animator.SetBool("isJumping", true);
            //
             animator.SetBool("isIDLEwLamp", false);
            animator.SetBool("isJumpingwLamp", false);
            animator.SetBool("isWalkingwLamp", false);
            }
             if(LampController.Instance.lampOut){
            animator.SetBool("isIDLEwLamp", false);
            animator.SetBool("isJumpingwLamp", true);
            //
            animator.SetBool("isIDLE", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isWalking", false);
            }
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
            if(!LampController.Instance.lampOut){
            animator.SetBool("isWalking", false);
            //
            animator.SetBool("isIDLEwLamp", false);
            animator.SetBool("isJumpingwLamp", false);
            animator.SetBool("isWalkingwLamp", false);
            }
           // animator.SetBool("isIDLE", true);
            if(LampController.Instance.lampOut){
            animator.SetBool("isWalkingwLamp", false);
            //
            animator.SetBool("isIDLE", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isWalking", false);
            }
        }
        else
        {
             if(!LampController.Instance.lampOut){
            animator.SetBool("isWalking", true);
            animator.SetBool("isIDLE", false);
            //
            animator.SetBool("isIDLEwLamp", false);
            animator.SetBool("isJumpingwLamp", false);
            animator.SetBool("isWalkingwLamp", false);
             }
              if(LampController.Instance.lampOut){
            animator.SetBool("isWalkingwLamp", true);
            animator.SetBool("isIDLEwLamp", false);
            //
            animator.SetBool("isIDLE", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isWalking", false);
             }
        }

        if (movement.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (movement.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        //movement Ends
}
   // }
    void OnTriggerEnter2D(Collider2D col) {
     if(col.gameObject.tag == "Object"){
         IntroManager.Instance.ObjCount+=1;
         SoundEvent.Instance.pickup.Play();
         Destroy(col.gameObject);
     }
     if(col.gameObject.tag == "Leaf"){
         IntroManager.Instance.ObjCount+=1;
         SoundEvent.Instance.pickup.Play();
         Destroy(col.gameObject);
     }
     if(col.gameObject.tag == "EnterWell"){
          SceneManager.LoadScene(sceneName);
     }

       
    }
    void OnCollisionEnter2D(Collision2D col)
    {

    }
}
