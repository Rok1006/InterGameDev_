using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public int ObjCount;
    public GameObject Block;
    public static IntroManager Instance;
      void Awake() {
    Instance = this;
}
    void Start()
    {
        Block.SetActive(true);
        ObjCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(ObjCount>1){
            Block.SetActive(false);
        }
    }
}
