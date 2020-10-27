using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lamp : MonoBehaviour
{
    public GameObject Player;
    public Slider Shower;
    public float showerValue;
    public bool valueMove = false;
    public GameObject Button;
    public GameObject Slider;
    public GameObject Light;
    public PlayerController PC;
    private bool interactable = true;
    Animator lampAnim;
    void Awake()
    {
        PC = GameObject.Find("YellowPlayer").GetComponent<PlayerController>();
    }

    void Start()
    {
        showerValue = 0;
        Shower.value = showerValue;
        Shower.maxValue = 10;
        Button.SetActive(false);
        Slider.SetActive(false);
        Light.SetActive(false);
        lampAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Shower.value = showerValue;
        if(valueMove){
            if(showerValue<10.01){
            showerValue+=0.02f; 
            }
        }
        if(showerValue>10){
            Slider.SetActive(false);
            Light.SetActive(true);
            PC.enabled = true;
            this.enabled = false;
            interactable = false;
            lampAnim.SetTrigger("LampOn");
        }
    }

    public void ClickButton(){
        valueMove = true;
        Button.SetActive(false);
        Slider.SetActive(true);
        PC.enabled = false;
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
            if(interactable){
            Button.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.tag == "Player"){
            Button.SetActive(false);
        }
        
    }
}
