using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NYCManager2 : MonoBehaviour
{
    public GameObject Manager;  //the script that start dots generating
    public GameObject MenuCam;
    public GameObject PlayerCam;
    public GameObject Playing;  //player ui
    public GameObject Menu;   //menu ui
    public GameObject End;
    public NYCMOvement moveS;
    void Start()
    {
        MenuCam.SetActive(true);
        End.SetActive(false);
        PlayerCam.SetActive(false);
        //Manager.SetActive(false);
        NYCManager.Instance.startG = false;
        Playing.SetActive(false);
        Menu.SetActive(true);
         moveS = GameObject.Find("Player").GetComponent<NYCMOvement>();
         moveS.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
         if(NYCManager.Instance.seconds < 1){
              NYCManager.Instance.startG = false;
             Playing.SetActive(false);
             End.SetActive(true);
             moveS.enabled = false;
         }
         if(NYCMOvement.Instance.health < 1){
              NYCManager.Instance.startG = false;
             Playing.SetActive(false);
             End.SetActive(true);
             moveS.enabled = false;
         }
    }

    public void ClickStart(){
        MenuCam.SetActive(false);
        PlayerCam.SetActive(true);
        //Manager.SetActive(true);
        NYCManager.Instance.startG = true;
        Playing.SetActive(true);
        Menu.SetActive(false);
        moveS.enabled = true;
    }
    public void ClickRestart(){
        //reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
