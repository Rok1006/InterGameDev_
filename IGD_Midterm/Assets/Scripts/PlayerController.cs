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
    public Animator animator;
    public bool lampOut;
    public int lamp;
    public GameObject LampLight;
    public GameObject LampLight2;
    public GameObject[] Cam;
    public GameObject hitBox;
    private bool attacking;
     public Objects obj;
     public GhostSpider gs;
     public GameObject GS;
     public int PlayerHealth;
     public static PlayerController Instance;
void Awake() {
    Instance = this;
}
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lampOut = false;
        // lamp = 0;
        LampLight.SetActive(false);
        LampLight2.SetActive(false);
        hitBox.SetActive(false);
        attacking = false;
          obj = GameObject.Find("Box").GetComponent<Objects>();
          gs = GameObject.Find("GS").GetComponent<GhostSpider>();
          //PlayerHealth = 5;  //change to larger later

    }

    void FixedUpdate() //!
    {
        Vector2 velocity = rb.velocity;
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);  
    }

    void Update()
    {
        // if(lamp ==0){
    //     if(Input.GetKey(KeyCode.Z)){
    //         lampOut = true;
    //         //lamp = 1; //change to 1
    //         LampLight.SetActive(true);
    //         LampLight2.SetActive(true);
    //     }
    //    //}
    //     // if(lamp ==1){
    //     if(Input.GetKey(KeyCode.X)){
    //         lampOut = false;
    //         //lamp = 0;
    //         LampLight.SetActive(false);
    //         LampLight2.SetActive(false);
    //         }
    //   // }
    //    if(lampOut){
    //    if(Input.GetKeyDown(KeyCode.F)){
    //        animator.SetTrigger("isAttackingwLamp");
    //        animator.SetBool("isIDLEwLamp", false);
    //    }
    if(LampController.Instance.lampOut){
       if(Input.GetKey(KeyCode.F)){   //playerhit
        hitBox.SetActive(true);
        attacking = true;
       }else{
            hitBox.SetActive(false);
            attacking = false;
       }
    }
       

    //    if(Input.GetKeyDown(KeyCode.G)){
    //        animator.SetTrigger("LightLamp");
    //    }
        
        //Movement Starts
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
    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "NormalScene"){
            Cam[0].SetActive(true);
            Cam[1].SetActive(false);
            Cam[2].SetActive(false);
        }
        // else{
        //     Cam[0].SetActive(false);
        // }
        if(col.gameObject.tag == "MiddleScene"){
            Cam[1].SetActive(true);
             Cam[0].SetActive(false);
            Cam[2].SetActive(false);
        }
        // else{
        //     Cam[1].SetActive(false);
        // }
        if(col.gameObject.tag == "TreeScene"){
            Cam[2].SetActive(true);
             Cam[1].SetActive(false);
            Cam[0].SetActive(false);
        }
        //DESTROYING OBJECT
       if(col.gameObject.tag == "Object"){
             if(attacking){
             obj.boxLife-=1;
             obj.anim.SetTrigger("Hit");
             }
             if(obj.boxLife<1){
                 obj.emit=true;
             }

         }
         if(col.gameObject.tag == "GSHitBox"){
             if(attacking){
                 gs.gsAnim.SetBool("IDLE",false);  
                 gs.gsAnim.SetTrigger("BeingHit");
                 gs.emit=true;
                 gs.gsHealth-=1;

            if(GS.transform.eulerAngles.y == 180){
            GS.transform.eulerAngles = new Vector3(0, 0, 0);
            }else{
                GS.transform.eulerAngles = new Vector3(0, 180, 0);
            }
             }
                if(gs.gsHealth<1){
                 obj.emit=true;
             }
     

         }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
      
    }
    
}


