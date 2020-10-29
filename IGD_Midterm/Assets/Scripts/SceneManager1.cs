using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.Experimental.Rendering.Universal;
 using UnityEngine.SceneManagement;

public class SceneManager1 : MonoBehaviour
{
    public float lightJuice;
    public GameObject Lamp;   //Lamplight of player
    public Slider RemainJuice;
    Light2D lampLight;
    public GameObject Player;
    public static SceneManager1 Instance;
    public GameObject LampInfo;
    Animator liAnim;
    public bool infoUp;
     public GameObject TreeCam;
      public GameObject TreeFocusCam;

    public bool treeLampZone;
    public int treeLamp;
    public GameObject Bloodwick;
    public GameObject revive;
    public bool revived;
    public Rigidbody2D rb1;
    public Rigidbody2D rb2;
    public Rigidbody2D rb3;
    public GameObject End;
    public float timer;
    public string sceneName;

  void Awake() {
    Instance = this;
}
    void Start()
    {
        lampLight = Lamp.GetComponent<Light2D>();
        liAnim = LampInfo.GetComponent<Animator>();
        lampLight.intensity = 1;
        lightJuice = 1;
        //RemainJuice.value = lampLight.intensity;
        RemainJuice.value = lightJuice;
        infoUp = false;
        treeLampZone = false;
        Bloodwick.SetActive(false);
        revive.SetActive(false);
        rb1.isKinematic = true;
        rb2.isKinematic = true;
        rb3.isKinematic = true;
        revived = false; 
        End.SetActive(false);
        timer=0;
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        if(treeLamp>3){
            TreeFocusCam.SetActive(true);
            TreeCam.SetActive(false);
        rb1.isKinematic = false;
        rb2.isKinematic = false;
        rb3.isKinematic = false;
        Bloodwick.SetActive(true);
        revive.SetActive(true);
        timer += Time.deltaTime;
        }
        if(timer>10){
            End.SetActive(true);
        }
        if(End.active){
            if(Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene(sceneName);
            }
        }


        if(!infoUp){
        if(Input.GetKeyDown(KeyCode.X)){
            liAnim.SetTrigger("InfoUp");
            infoUp = true;
            //liAnim.SetTrigger("InfoDown");
        }
        }else{
             if(Input.GetKeyDown(KeyCode.X)){
            //liAnim.SetTrigger("InfoUp");
            liAnim.SetTrigger("InfoDown");
            infoUp = false;
        } 
        }

        if(LampController.Instance.lampOut){
          lightJuice-=0.0002f;  //howfast is fuel fading
        }
        

        RemainJuice.value = lightJuice;
        lampLight.intensity = RemainJuice.value;   //the value affect the light intensity

        if(PlayerController.Instance.NumLeaf>0){
        if(Input.GetKeyDown(KeyCode.Space)){  //add fuel
            if(lightJuice<1){
            lightJuice+=0.4f;  //the amount of fuel in leaf
            }
            PlayerController.Instance.NumLeaf-=1;

        }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // if(col.gameObject.tag == "Player"){
        //     Hidden.SetActive(false);
        // }
    }
}
