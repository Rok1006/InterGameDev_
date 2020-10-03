using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackDots : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(this.gameObject.tag == "Left"){
           transform.Translate(new Vector2(0.5f, 0) * speed * Time.deltaTime);
       }
       if(this.gameObject.tag == "Right"){
           transform.Translate(new Vector2(-0.5f, 0) * speed * Time.deltaTime);
       }

    
 
    }
     void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.tag == "DeadZone"){
            Destroy(this.gameObject);
        }
       
    }
}
