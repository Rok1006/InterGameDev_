using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public bool isLeaf;
    public bool isLife;

    public int leafPlus;
    public int lifePlus;
    // Start is called before the first frame update
    void Start()
    {
        leafPlus = 0;
        lifePlus = 0;  //add one heart
        isLeaf = false;
        isLife = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.tag == "YellowLeaf"){
            // Debug.Log("yep");
            // isLeaf = true;
        }
        if(this.gameObject.tag == "Life"){
            // Debug.Log("yep");
            // isLife = true;
        }
    }

    void OnCollisionEnter(Collision col) {
        // if(col.gameObject.tag == "Player"){
        //     if(isLeaf){
        //         //add value
        //         Destroy(this.gameObject);
        //     }
        //     if(isLife){
        //         //add value
        //         Destroy(this.gameObject);
        //     }
        // }
    }

    void OnTriggerEnter(Collider col) {
        // if(col.gameObject.tag == "Player"){
        //     if(isLeaf){
        //         //add value
        //         Destroy(this.gameObject);
        //     }
        //     if(isLife){
        //         //add value
        //         Destroy(this.gameObject);
        //     }
        // }
    }

}
