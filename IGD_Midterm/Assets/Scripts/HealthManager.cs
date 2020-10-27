using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject[] slot;
    public GameObject heart;  //prefab
    public bool[] full;
    public bool addHeart;
    public List<GameObject> GeneratedHeart = new List<GameObject>();
    public int n;
    public bool addHeartAgain;
    int index;
    int num;
   

    // Start is called before the first frame update
    void Start()
    {
        ToStart();
        n = 1;
        addHeartAgain = false;
    }
    public void ToStart()
    {
        // addHeart = true;
        for (int i = 0; i < slot.Length; i++)
            {
                if (full[i] == false)
                {
                    GameObject h = Instantiate(heart, slot[i].transform, false) as GameObject;
                    GeneratedHeart.Add(h);
                    full[i] = true;
                    //break;
                }
            
            }
   
        }

    void Update()
    {

        if(addHeartAgain){
            for (int i = 0; i < GeneratedHeart.Count; i++){
            //if (GeneratedHeart[i] == null){  //this destroy all heart
            //index = GeneratedHeart.IndexOf(GeneratedHeart[i]);
            //Debug.Log(index);
             if (full[i] == false)
                {
                    full[i] = true;
                    GeneratedHeart[i] = Instantiate(heart, slot[i].transform, false) as GameObject;
                    //GeneratedHeart.Add(h);
                    break;  //very important to put this, so it will only instan 1 at a time
                }


            }
           // }
            addHeartAgain = false;
        }

//destroy heart when losing
    if(Input.GetKeyDown(KeyCode.B)){

         for (int i = 0; i < GeneratedHeart.Count; i++){
            if (GeneratedHeart[i] != null){  //this destroy all hearts
            Destroy(GeneratedHeart[GeneratedHeart.Count-n]);
            index = GeneratedHeart.IndexOf(GeneratedHeart[GeneratedHeart.Count-n]);
            //GeneratedHeart[GeneratedHeart.Count-n] = null;
            Debug.Log(index);
            full[GeneratedHeart.Count-n] = false;
                    
         }  
    }
    n++;

    }
    //add heart back
  if(Input.GetKeyDown(KeyCode.V)){
  addHeartAgain = true;
     if(n>1){
     n--;
     }


  }
}

}

