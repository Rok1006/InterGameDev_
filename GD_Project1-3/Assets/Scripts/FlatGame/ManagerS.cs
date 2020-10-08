using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class ManagerS : MonoBehaviour
{
    public Sprite c1;
    public Sprite c2;
    public Text whitenum;
    public Text rednum;
    public int white;
    public int red;
    public GameObject End;
    public static ManagerS Instance;
        private void Awake() {
        Instance = this;
    }
    void Start()
    {
        white = 0;
        red = 0;
        //Cursor.SetCursor(c1,Vector2.zero, CursorMode.ForceSoftware);
                     var pc = GameObject.FindGameObjectWithTag("PlayerCam");
       var confiner = pc.GetComponent<CinemachineVirtualCamera>();
            confiner.m_Lens.OrthographicSize = 31;
            End.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

         GameObject[] ld = GameObject.FindGameObjectsWithTag("LD");
        int ldc = ld.Length;
         GameObject[] rd = GameObject.FindGameObjectsWithTag("RD");
        int rdc = rd.Length;
        if(ldc<4){
            End.SetActive(true);
        }


        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
              if (Input.GetMouseButtonDown(0))
        {
            GetComponent<SpriteRenderer>().sprite = c2;  //changing sprite when click    
        }
         if (Input.GetMouseButtonUp(0))
        {
             GetComponent<SpriteRenderer>().sprite = c1;
        }

        // UI
        whitenum.text = ldc.ToString();
        rednum.text = rdc.ToString();

        if(Input.GetKey(KeyCode.X)){
              var pc = GameObject.FindGameObjectWithTag("PlayerCam");
       var confiner = pc.GetComponent<CinemachineVirtualCamera>();
       if(confiner.m_Lens.OrthographicSize <31){
            confiner.m_Lens.OrthographicSize+=0.1f; 
        }
    }
         if(Input.GetKey(KeyCode.Z)){
              var pc = GameObject.FindGameObjectWithTag("PlayerCam");
       var confiner = pc.GetComponent<CinemachineVirtualCamera>();
       if(confiner.m_Lens.OrthographicSize >9){
            confiner.m_Lens.OrthographicSize-=0.1f; 
        }
    }
    void OnMouseEnter(){
       //GetComponent<SpriteRenderer>().sprite = c2;
    }
    void OnMouseExit(){
        //Cursor.SetCursor(c1,Vector2.zero, CursorMode.ForceSoftware);
    }
    }
}
