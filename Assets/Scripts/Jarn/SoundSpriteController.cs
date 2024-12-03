using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSprite : MonoBehaviour
{
    public AudioSource MaiAroi;
    public AudioSource Aroi;

    public void PlayMaiAroiSound(){
        MaiAroi.Play();
    }

    public void PlayAroiSound(){
        Aroi.Play();
    }
}

