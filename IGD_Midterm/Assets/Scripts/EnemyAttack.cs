using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player"){
          //PlayerController.Instance.PlayerHealth-=2;   
          if(GhostSpider.Instance.alive){
              GhostSpider.Instance.attack.Play();
        GhostSpider.Instance.camAnim.SetTrigger("Shake");
        GhostSpider.Instance.middlecamAnim.SetTrigger("Shake");
        GhostSpider.Instance.treecamAnim.SetTrigger("Shake");
     
          }
        

      }
    }
}
