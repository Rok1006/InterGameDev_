using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
     public float PlayerHealth;
     public static PlayerController Instance;
    public GameObject PlayerCam;
    public GameObject MiddleCam;
    public GameObject TreeCam;
    Animator camAnim;
    Animator middlecamAnim;
    Animator treecamAnim;
    public Text numofLeaf;
    public int NumLeaf;
    public GameObject Text;
    Animator textAnim;
    public Slider healthBar;
    public bool canMove;
    public GameObject heart;
    Animator heartAnim;
    public AudioSource land;
    public AudioSource attack;
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
        textAnim = Text.GetComponent<Animator>();
        PlayerHealth = 50;  //change to larger later
        camAnim = PlayerCam.GetComponent<Animator>();
        middlecamAnim = MiddleCam.GetComponent<Animator>();
        treecamAnim = TreeCam.GetComponent<Animator>();
        heartAnim = heart.GetComponent<Animator>();
        healthBar.value = PlayerHealth;
        AudioSource[] audios = GetComponents<AudioSource>();
        land = audios[0];
        attack = audios[1];
        

    }

    void FixedUpdate() //!
    {
        Vector2 velocity = rb.velocity;
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);  
    }
    public void Land(){
        land.Play();
    }
    public void Slash(){
        attack.Play();
    }

    void Update()
    {
        healthBar.value = PlayerHealth;
        numofLeaf.text = NumLeaf.ToString();
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
if(canMove){
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
            //footstep.Play();
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
    }
    void OnTriggerEnter2D(Collider2D col) {
        // if(col.gameObject.tag == "TreeLamp"){
        //     SceneManager1.Instance.treeLampZone = true;

        // }

        if(col.gameObject.tag == "NormalScene"){
            Cam[0].SetActive(true);
            Cam[1].SetActive(false);
            Cam[2].SetActive(false);
        }
      
        if(col.gameObject.tag == "MiddleScene"){
            Cam[1].SetActive(true);
             Cam[0].SetActive(false);
            Cam[2].SetActive(false);
        }
  
        if(col.gameObject.tag == "TreeScene"){
            if(!SceneManager1.Instance.revived){
            Cam[2].SetActive(true);
            }
             Cam[1].SetActive(false);
            Cam[0].SetActive(false);
        }
        //DESTROYING OBJECT
       if(col.gameObject.tag == "Object"){
           var sc = col.gameObject.GetComponent<Objects>();
             if(attacking){
             sc.boxLife-=1;
             sc.anim.SetTrigger("Hit");
             }
             if(sc.boxLife<1){
                 sc.emit=true;
                   if(sc.num==2){
                Debug.Log("yes");
                 sc.emitLife=true;
             }
             }
           

         }
         if(col.gameObject.tag == "GhostSpider"){
             var sc1 = col.gameObject.GetComponent<GhostSpider>();  //the script is not on this gameobject
             if(attacking){
                 sc1.BeingHit();
                 sc1.gsAnim.SetBool("IDLE",false);  
                 sc1.gsAnim.SetTrigger("BeingHit");
                 sc1.emit=true;
                 sc1.gsHealth-=1;

            if(col.gameObject.transform.eulerAngles.y == 180){
            col.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }else{
                col.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
            }
             }
         }
         if(col.gameObject.tag == "GSAttackSpot"){ //injured
         heartAnim.SetTrigger("HeartShake");
            PlayerHealth-=1;  
         }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
      if(col.gameObject.tag == "YellowLeaf"){
          NumLeaf+=1;
          SoundEvent.Instance.PickUp();
          textAnim.SetTrigger("Shake");
        camAnim.SetTrigger("Shake");
        middlecamAnim.SetTrigger("Shake");
        treecamAnim.SetTrigger("Shake");
          Destroy(col.gameObject);
      }
        if(col.gameObject.tag == "Life"){
            SoundEvent.Instance.PickUp();
            if(PlayerHealth<50){
                PlayerHealth+=0.5f;
                heartAnim.SetTrigger("HeartShake");
            }
        camAnim.SetTrigger("Shake");
        middlecamAnim.SetTrigger("Shake");
        treecamAnim.SetTrigger("Shake");
        Destroy(col.gameObject);
      }
    }
    
}


