using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LDGenerator : MonoBehaviour
{
    public List<GameObject> GeneratedLD = new List<GameObject>();
    private GameObject LD;
    public GameObject Prefab;
    public GameObject LDHolder;
    public bool reproducing;
    public static LDGenerator Instance;
    //public Text whitenum;
    private void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        reproducing = false;
            //Vector2 pos = new Vector2(Random.Range(-40f, 40f),Random.Range(-50f, 29f));  //try to instan it in the can middle 
            // Vector2 pos = new Vector2(0,0);  //make it to the center of the camera
            // GameObject LD = Instantiate(Prefab, pos, Quaternion.identity)  as GameObject;    //create fishes randomly 
            // GeneratedLD.Add(LD);   //and put in the list
            // LD.transform.parent = LDHolder.transform ;  //gather them under a game Object
            // LD.name = LD.name.Replace("(Clone)", "");
            for(int i = 0; i<20; i++){   
            Vector2 pos = new Vector2(Random.Range(-29f, 29f),Random.Range(-40f, 19f));
            GameObject LD = Instantiate(Prefab, pos, Quaternion.identity)  as GameObject;   
            GeneratedLD.Add(LD);  
            LD.transform.parent = LDHolder.transform ;  
            LD.name = LD.name.Replace("(Clone)", "");
        }


    }

    // Update is called once per frame
    void Update()
    {
        // if(GeneratedLD.Count<20){
        // if(Input.GetKeyDown(KeyCode.X)){   //change it to UI button
        //     //Vector2 pos = new Vector2(Random.Range(-40f, 40f),Random.Range(-50f, 29f)); 
        //     Vector2 pos = new Vector2(0,0);  //the range of the area of origin ocean
        //     GameObject LD = Instantiate(Prefab, pos, Quaternion.identity)  as GameObject;    //create fishes randomly 
        //     GeneratedLD.Add(LD);   
        //     Debug.Log(GeneratedLD.Count);
        //     LD.transform.parent = LDHolder.transform ;  //gather them under a game Object
        //     LD.name = LD.name.Replace("(Clone)", "");
  
        // }
        // }

        // if(reproducing){ //not working
        //     //Vector2 pos = new Vector2(this.transform.position.x+5, this.transform.position.y+5);
        //     GameObject LD = Instantiate(Prefab, LDMovement.Instance.location, Quaternion.identity)  as GameObject;    //create fishes randomly 
        //     GeneratedLD.Add(LD);   
        //     //Debug.Log(GeneratedLD.Count);
        //     LD.transform.parent = LDHolder.transform ;  //gather them under a game Object
        //     LD.name = LD.name.Replace("(Clone)", "");
        //     reproducing = false;
        // }
    }

      void OnTriggerEnter2D(Collider2D col) {
          if(col.gameObject.CompareTag("LD")){
               //Debug.Log("Inside");
           if(col.gameObject.GetComponent<LDMovement>().state == 1){
            ManagerS.Instance.white -=1;
            ManagerS.Instance.red +=1;
           
            }
          }
      }
}
