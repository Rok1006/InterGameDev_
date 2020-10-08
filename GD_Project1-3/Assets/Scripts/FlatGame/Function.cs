using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Function : MonoBehaviour
{
     public string sceneName;
     public GameObject Instruct;
    // Start is called before the first frame update
    void Start()
    {
        Instruct.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickRed(){
        SceneManager.LoadScene(sceneName);
    }
    public void ClickWhite(){
        Instruct.SetActive(true);
    }
     public void ClickBack(){
        Instruct.SetActive(false);
    }
}
