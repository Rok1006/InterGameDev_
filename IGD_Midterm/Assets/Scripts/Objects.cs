using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public int boxLife;
    //public static Objects Instance;
    public GameObject BoxBreak;
    public GameObject EmitSpot;
    public bool emit;
    public Animator anim;
    public GameObject Leaf;  //leaf prefab
    // void Awake(){
    //     Instance = this;
    // }
    // Start is called before the first frame update
    void Start()
    {
        emit = false;
        boxLife=4;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(boxLife);

        if(emit){
            this.GetComponent<SpriteRenderer>().enabled = false;
            GameObject c = Instantiate(BoxBreak,EmitSpot.transform.position, Quaternion.identity);
            //Destroy(EmitSpot);
            GameObject l = Instantiate(Leaf,EmitSpot.transform.position, Quaternion.identity);
            Leaf.SetActive(true);
            emit = false;
                  Destroy(c, 1.7f);
                  Destroy(this.gameObject,1.7f);
            
       
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
    
    }
}
