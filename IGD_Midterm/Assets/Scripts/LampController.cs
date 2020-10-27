using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    Animator animator;
    public GameObject LampLight;
    public GameObject LampLight2;
    public bool lampOut;
    public static LampController Instance;

    void Awake() {
        Instance= this;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        lampOut = false;
        // lamp = 0;
        LampLight.SetActive(false);
        LampLight2.SetActive(false);
         this.GetComponent<PlayerController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z)){
            lampOut = true;
            //lamp = 1; //change to 1
            LampLight.SetActive(true);
            LampLight2.SetActive(true);
            this.GetComponent<PlayerController>().enabled = true;
        }
       //}
        // if(lamp ==1){
        if(Input.GetKey(KeyCode.X)){  //if light out
            lampOut = false;
            //lamp = 0;
            LampLight.SetActive(false);
            LampLight2.SetActive(false);
            this.GetComponent<PlayerController>().enabled = false;
            }
      // }
       if(lampOut){
       if(Input.GetKeyDown(KeyCode.F)){
           animator.SetTrigger("isAttackingwLamp");
           animator.SetBool("isIDLEwLamp", false);
       }
    }
}
}
