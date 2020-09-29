using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RubeGoldBergManager : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject Bucket;
    public GameObject b;
    public GameObject bBase;
    Animator bucketAnim;
    public GameObject Cart;
    Animator cartAnim;
    public GameObject machine;
    Animator machineAnim;
    public float force;
    public float Timer;
    public int Speed;
    public bool gen = false;
    public GameObject LD;
    public GameObject C1;
    public GameObject C2;
    public GameObject C3;
    public GameObject holder;
    public GameObject ControlText;
    public GameObject EndText;
    public GameObject Canvas;
    public bool end = false;
     public string sceneName;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bucketAnim = Bucket.GetComponent<Animator>();
        bBase.SetActive(true);
        cartAnim= Cart.GetComponent<Animator>();
        machineAnim= machine.GetComponent<Animator>();
        Timer = 0;
        C1.SetActive(true);
        C2.SetActive(false);
        C3.SetActive(false);
        // this.transform.parent = holder.transform;
        Canvas.SetActive(true);
        ControlText.SetActive(true);
        EndText.SetActive(false);
        end = false;
        holder.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(gen){
            Timer+=Time.deltaTime;
        }
       
        if(Timer>2f){
            LD.transform.Translate(new Vector2(0.5f, 0) * Speed * Time.deltaTime);
            this.transform.position = LD.transform.position;
            gen = false;
            //LD comes out
        }
        if(Input.GetKey(KeyCode.A)){
            C1.SetActive(true);
            C2.SetActive(false);
            C3.SetActive(false);
        }
         if(Input.GetKey(KeyCode.S)){
            C1.SetActive(false);
            C2.SetActive(true);
            C3.SetActive(false);
        }
         if(Input.GetKey(KeyCode.D)){
            C1.SetActive(false);
            C2.SetActive(false);
            C3.SetActive(true);
        }
        if(end){
            Canvas.SetActive(true);
            EndText.SetActive(true);
            if(Input.GetKey(KeyCode.Space)){
            //reload scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }else{
             if(Input.GetKey(KeyCode.Space)){
            holder.SetActive(false);
            Canvas.SetActive(false);
            ControlText.SetActive(false);
            EndText.SetActive(false);
        }
        }
       

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Cup")){
            this.transform.position = new Vector2(-15.09f,5.83f);
            rb.AddForce(transform.right * force, ForceMode2D.Impulse);
        }
        if(col.gameObject.CompareTag("Bucket")){
            this.transform.parent = b.transform ;
            bucketAnim.SetTrigger("Move");
        }
         if(col.gameObject.CompareTag("EnterPC")){
            this.transform.parent = null ;
            bBase.SetActive(false);
        }
        if(col.gameObject.CompareTag("PC")){
            this.transform.position = new Vector2(14.03f,3.14f);
        }
        if(col.gameObject.CompareTag("Cart")){
            this.transform.parent = Cart.transform ;
            cartAnim.SetTrigger("Move");
        }
        if(col.gameObject.CompareTag("LD")){
          machineAnim.SetTrigger("Generate");
          gen = true;
          
        }
            if(col.gameObject.CompareTag("End")){
         end = true;
          
        }
    }

    
}
