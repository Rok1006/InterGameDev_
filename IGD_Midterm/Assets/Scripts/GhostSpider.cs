using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpider : MonoBehaviour
{
    public Animator gsAnim;
    public float innerRayLength;
    public float outerRayLength;
    Rigidbody2D rb;
    public GameObject Target;  //Player
    public float speed;
    public bool detected;
    private bool isAttacking;
    private bool isChasing;
    public bool detectL;
    public bool detectR;
    public bool getHit;
    public bool emit;
    public GameObject whiteBlood;
    public GameObject EmitSpot;
    public int gsHealth;
    public bool dead;
    public GameObject body;
    public GameObject Leaf;
    public GameObject Life;
    public GameObject AttackBox;
    public GameObject PlayerCam;
       public GameObject MiddleCam;
          public GameObject TreeCam;
   public Animator camAnim;
    public Animator middlecamAnim;
    public Animator treecamAnim;
    public bool alive;
    public int damageToPlayer;
    AudioSource dying;
    AudioSource s;
    AudioSource monsterS;
    AudioSource beinghit;
    public AudioSource attack;

    public static GhostSpider Instance;
  void Awake() {
    Instance = this;
}
    void Start()
    {
        gsAnim = GetComponent<Animator>();
        detected = false;
        isAttacking = false;
        isChasing = false;
        detectL = false;
        detectR = false;
        getHit = false;
        dead = false;
        emit = false;
        gsHealth = 3;  //change to bigger number
        body.SetActive(true);
        AttackBox.SetActive(false);
        camAnim = PlayerCam.GetComponent<Animator>();
        middlecamAnim = MiddleCam.GetComponent<Animator>();
        treecamAnim = TreeCam.GetComponent<Animator>();
        alive = true;
          this.gameObject.name = "GS";

        AudioSource[] audios1 = GetComponents<AudioSource>();
        s = audios1[0];
        monsterS= audios1[1];
        beinghit = audios1[2];
        attack = audios1[3];
        dying = audios1[4];
        
    }

    public void Steps(){
        s.Play();
        monsterS.Play();
    }
     public void BeingHit(){
        beinghit.Play();
    }
     public void Attack(){
        //attack.Play();
    }
     public void Dying(){
        dying.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Target = GameObject.FindGameObjectWithTag("Player");
        //facing left
           if(transform.eulerAngles.y == 0){
               detectL = true;
               detectR = false;
           }
               if(detectL){
        int layerMask = LayerMask.GetMask("Player");
        Vector3 rayStartPos = new Vector3(transform.position.x, transform.position.y+0.89f,transform.position.z);
        Vector3 rayStartPos2 = new Vector3(transform.position.x-innerRayLength, transform.position.y+0.89f,transform.position.z);

//innerZone ray: Attack
        RaycastHit2D hit = Physics2D.Raycast(rayStartPos, Vector2.left, innerRayLength,layerMask );  //Vector3.forward
        if(hit.collider != null){  //DETECT PLAYER
        Debug.DrawRay(rayStartPos, new Vector3(-innerRayLength,0,0), Color.green);
        detected = false;
        isAttacking = true;
        }else{
            isAttacking=false;
        }
         Debug.DrawRay(rayStartPos, new Vector3(-innerRayLength,0,0), Color.red);
//outerZone ray: Chase
        RaycastHit2D hit2 = Physics2D.Raycast(rayStartPos2, Vector2.left, outerRayLength,layerMask );  //Vector3.forward
        if(hit2.collider != null){
        Debug.DrawRay(rayStartPos2, new Vector3(-outerRayLength,0,0), Color.green);
        transform.eulerAngles = new Vector3(0, 0, 0);
        isChasing = true;
        if(!dead){
                 detected = true; 
        }
  
        }else{
            isChasing = false;
            detected = false; 
            if(!isAttacking){
            gsAnim.SetBool("Chase",false);
            gsAnim.SetBool("Attack",false);
            gsAnim.SetBool("IDLE",true);  
            }
        }
         Debug.DrawRay(rayStartPos2, new Vector3(-outerRayLength,0,0), Color.white);
               }
   //}
    //facing right
//innerZone ray: Attack
    if(transform.eulerAngles.y == 180){
        detectL = false;
        detectR = true;
    }
        if(detectR){
        int layerMask = LayerMask.GetMask("Player");
        Vector3 rayStartPos = new Vector3(transform.position.x, transform.position.y+0.89f,transform.position.z);
        Vector3 rayStartPos3 = new Vector3(transform.position.x+innerRayLength, transform.position.y+0.89f,transform.position.z);

        RaycastHit2D hit3 = Physics2D.Raycast(rayStartPos, Vector2.right, innerRayLength,layerMask );  //Vector3.forward
        if(hit3.collider != null){
        Debug.DrawRay(rayStartPos, new Vector3(innerRayLength,0,0), Color.green);
        detected = false;
        isAttacking= true;
        }else{
            isAttacking=false;
        }
         Debug.DrawRay(rayStartPos, new Vector3(innerRayLength,0,0), Color.red);
         
//outerZone ray : Chase
        RaycastHit2D hit4 = Physics2D.Raycast(rayStartPos3, Vector2.right, outerRayLength,layerMask );  //Vector3.forward
        if(hit4.collider != null){
        Debug.DrawRay(rayStartPos3, new Vector3(-outerRayLength,0,0), Color.green);
        transform.eulerAngles = new Vector3(0, 180, 0);
        isChasing = true;
         if(!dead){
        detected = true;
         }
        }else{
            isChasing = false;
            detected = false;
             if(!isAttacking){
            gsAnim.SetBool("Chase",false);
            gsAnim.SetBool("Attack",false);
            gsAnim.SetBool("IDLE",true);  
            }
        }
         Debug.DrawRay(rayStartPos3, new Vector3(-outerRayLength,0,0), Color.white);
        }

    }
    void Update(){
        if(detected){
            float step = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, Target.transform.position, step);

        }
        if(isAttacking){
        gsAnim.SetBool("Chase",false);
        gsAnim.SetBool("IDLE",false);
        gsAnim.SetBool("Attack",true);
        AttackBox.SetActive(true);
        }else{
            AttackBox.SetActive(false);
        }
        if(isChasing){
        gsAnim.SetBool("Chase",true);
        gsAnim.SetBool("IDLE",false);
        gsAnim.SetBool("Attack",false);
        }

        if(emit){
        GameObject w = Instantiate(whiteBlood,EmitSpot.transform.position, Quaternion.identity);
        if(gsHealth<1){
        GameObject l = Instantiate(Leaf,EmitSpot.transform.position, Quaternion.identity);
        GameObject li = Instantiate(Life,EmitSpot.transform.position, Quaternion.identity);
        }
        emit = false;
        Destroy(w, 1.7f);
        //Destroy(this.gameObject,1.7f);
        }
        if(gsHealth<1){
        gsAnim.SetBool("Die",true);
        gsAnim.SetBool("Chase",false);
        gsAnim.SetBool("IDLE",false);
        gsAnim.SetBool("Attack",false);
        detectL = false;
        detectR = false;
        detected = false;
        dead = true;
        body.SetActive(false);
        AttackBox.SetActive(false);
        alive = false;

        }
     
    }
      void OnCollisionEnter2D(Collision2D col)
    {
    //   if(col.gameObject.tag == "Player"){
    //       PlayerController.Instance.PlayerHealth-=1;

    //   }
    }
    // void OnTriggerEnter2D(Collider2D col) {
    //     if(col.gameObject.tag == "Player"){
    //       //PlayerController.Instance.PlayerHealth-=2;   
    //       if(alive){
    //           attack.Play();
    //     camAnim.SetTrigger("Shake");
    //     middlecamAnim.SetTrigger("Shake");
    //     treecamAnim.SetTrigger("Shake");
     
    //       }
        

    //   }
    // }
}
