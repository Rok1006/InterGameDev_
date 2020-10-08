using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NYCManager : MonoBehaviour
{
    public GameObject LPos;
    public GameObject RPos;
    public GameObject Ldot;
    public GameObject Rdot;
    public GameObject[] pos;
    public GameObject diaPrefab;
    private int num;
    public bool startG;
    public Text Timeleft;
    public float seconds;
    public Text totalCount;

    public int DiaNum = 0;  //num of collect diamond
    public static NYCManager Instance;
    void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        seconds = 120;
        startG = false;
        InvokeRepeating ("GenerateL", 2 , 4f);
        InvokeRepeating ("GenerateR", 2 , 4f);
        RanLoca();
         for(int i = 0; i<1; i++){
             GameObject s = Instantiate(diaPrefab, pos[num].transform.position, Quaternion.identity)  as GameObject; 
         }
    }

    // Update is called once per frame
    void Update()
    {
        totalCount.text = DiaNum.ToString();
        Timeleft.text = Mathf.Round(seconds).ToString()+ " seconds left";
        GameObject[] d = GameObject.FindGameObjectsWithTag("Diamond");
        int numofdia = d.Length;
        //Debug.Log(numofdia);
        if(numofdia<1){
         RanLoca();
         for(int i = 0; i<1; i++){
             GameObject s = Instantiate(diaPrefab, pos[num].transform.position, Quaternion.identity)  as GameObject; 
         }
         }
     if(startG){
             seconds -= Time.deltaTime;
         }

        
        
    }
    void GenerateL(){
        if(startG){
            for(int i = 0; i<1; i++){
             GameObject D = Instantiate(Ldot, LPos.transform.position, Quaternion.identity)  as GameObject; 
         } 
        }
        
    }
     void GenerateR(){
         if(startG){
           for(int i = 0; i<1; i++){
             GameObject D = Instantiate(Rdot, RPos.transform.position, Quaternion.identity)  as GameObject; 
         }  
         }
         
    }
    void RanLoca(){
        num = Random.Range(0,9);
    }

    
}
