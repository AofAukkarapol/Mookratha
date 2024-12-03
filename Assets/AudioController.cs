using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioController : MonoBehaviour
{
    public AudioSource BoomSoundPlus;
    public void OnEnable(){
        FoodBoomController.BoomSoundSend += EventSound;
    }
    public void OnDisable(){
        FoodBoomController.BoomSoundSend -= EventSound;
    }
    
    public void EventSound(){
        if(!BoomSoundPlus.isPlaying){
            BoomSoundPlus.Play();
        }
        
    }
}
