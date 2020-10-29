using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvent : MonoBehaviour
{
    public GameObject CollectiblesSound;
    public AudioSource pickup;
    //public GameObject EnemySound;
  
    
  public static SoundEvent Instance;
  void Awake() {
    Instance = this;
}
    void Start()
    {
        AudioSource[] audios = CollectiblesSound.GetComponents<AudioSource>();
        pickup = audios[0];

    
    }

    void Update()
    {
        
    }
    public void PickUp(){
        pickup.Play();
    }

    
}
