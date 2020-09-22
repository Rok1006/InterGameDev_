using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;

public class LDMovement : MonoBehaviour
{
   float x;
    float y;
    float z;
    public LDInfo info;
    public static LDMovement Instance;
    public AIPath aiPath;
     private Vector3 targetPos;
     Animator ldanim;
    public GameObject animHolder;
    [Header("State")]
     public bool Moving = false;
     public bool doingnothing = false;
     public bool socializing;
     public bool makedecistion;
     private int num;
     public bool detected = false;
     public bool evilize = false;
     private bool changeAnim = false;
     public float energy;
     public float satisfaction;
     private bool increase;
    [SerializeField] public Slider e;
    [SerializeField] public Slider s;
    public GameObject en;
    public GameObject st;
    public GameObject Manager;
    public Vector2 location;
    public bool safe;
    public int state;   //0=white, 1=red
    private bool point = false;
           private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        x = this.transform.localScale.x;
        y = this.transform.localScale.y;
        z = this.transform.localScale.z;
        ldanim = animHolder.GetComponent<Animator>();
        InvokeRepeating("DecistionMaker",0,5);  //5 sec?
        makedecistion = true;
        //
        energy = info.defaultEnergy;
        satisfaction = info.defaultSatisfaction;
         en.SetActive(true);
            st.SetActive(true);
            increase = true;
            safe = true;
            ManagerS.Instance.white +=1;
            state = 0;
        
    }
    void Update() {
        s.value = satisfaction;
        e.value = energy;

        if(aiPath.desiredVelocity.x == 0){
            // ldanim.SetTrigger("isIDLE");
            ldanim.SetBool("isWalking", false);
            ldanim.SetBool("isIDLE", true);

        }else{
            //ldanim.SetTrigger("isWalking");
            ldanim.SetBool("isWalking", true);
            ldanim.SetBool("isIDLE", false);
        }
        if(aiPath.desiredVelocity.x>= 0.01f){
             animHolder.transform.eulerAngles = new Vector3(0, 0, 0);
        }else if(aiPath.desiredVelocity.x<= -0.01f){
            animHolder.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        /////// Decistion making
        if(num<=3){ //30%    pausing,charging
            doingnothing = true;
            socializing = false;
            Moving = false;
            this.GetComponent<AIDestinationSetter>().enabled = false;
            //this.GetComponent<AIDestinationSetter>().move = false;
            if(energy<100){
                energy+=0.05f;
            }
            if(satisfaction>0){  //lonely
                satisfaction-=0.02f;
            }

        }else if(num>3 && num <=6){  //30 socializing
            this.GetComponent<AIDestinationSetter>().enabled = true;   //move arounf first
                if(energy>0){
                energy-=0.05f;
            }
            //if(increase){
            if(detected){
                if(safe){
                socializing = true;
                doingnothing = false;
                makedecistion = false;  //action led
                Moving = false;
                 if(energy>0){
                energy-=0.05f;
            }
            this.GetComponent<AIDestinationSetter>().enabled = false; //stop moving
            //this.GetComponent<AIDestinationSetter>().move = false;
            if(satisfaction<100){ //have frds
                satisfaction+=0.5f;
            }else if(satisfaction >= 100){   //leave the group
                socializing = false;
                makedecistion = true;
                detected = false;
            }
            if(satisfaction == 95){  //generate another one
            LDGenerator.Instance.reproducing = true;
            location = new Vector2(this.transform.position.x+5, this.transform.position.y+5);
            }
                }  //safe
            }else{
                //makedecistion = true; // here
                if(satisfaction>0){  //lonely
                satisfaction-=0.02f;
                }
            }
        
        //if satisfaction low evilize
        }else if(num>6 && num <=10){  //40 wandering around
            Moving = true;
            this.GetComponent<AIDestinationSetter>().enabled = true;
                if(energy>0){
                energy-=0.05f;
            }
             if(satisfaction>0){  //lonely
                satisfaction-=0.02f;
            }
        }
        if(satisfaction<10){  //dying// how to do only once
         changeAnim = true;
         evilize = true;
           en.SetActive(false);
            st.SetActive(false);
           makedecistion = false;
         transform.gameObject.tag = "RD";
        //    ManagerS.Instance.white -=1;
        //    ManagerS.Instance.red +=1;
           state = 1;
             this.GetComponent<AIDestinationSetter>().enabled = false;
             //this.GetComponent<AIDestinationSetter>().move = false;
         //clickable and be terminated
         if(satisfaction<9.5f){ 
             changeAnim = false;
        
         }
        }
        if(changeAnim){
          
            ldanim.SetTrigger("Dying");  //constantly playing
            ldanim.SetBool("isWalking", false);
            ldanim.SetBool("isIDLE", false);
        }

    }
    // void OnMouseDown() {
    //     if(this.gameObject.tag == "LD"){
    //         Destroy(gameObject);
    //     }
        
    // }

    void DecistionMaker(){
        if(makedecistion == true){
        num =  Random.Range(0,9);
        //Debug.Log(num);
       }
    }
    public void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("LD") ||col.gameObject.CompareTag("RD")){  //&& RD
            if(col.gameObject.GetComponent<LDMovement>().evilize == true){
                safe = false;
                Debug.Log("infected");
                detected = false;
                //changeAnim = true;
                en.SetActive(false);
            st.SetActive(false);
           makedecistion = false;  //conflicted
           satisfaction = 9.7f;
            }else{
                detected = true;
                safe = true;
            }
                

              
        }
        if(col.gameObject.CompareTag("DeadZone")){ //only work when dot walking
            Destroy(this.gameObject);
            if(evilize){
                ManagerS.Instance.red -=1;
            }else{
                ManagerS.Instance.white -=1;
            }

        }
    }
    public void OnTriggerExit2D(Collider2D col) {
          if(col.gameObject.CompareTag("LD")){
            detected = false;
        }
    }
}
