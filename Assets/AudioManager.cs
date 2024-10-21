using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource musicSource;
    public AudioSource SFXSource;

    public AudioClip music;


    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = music;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
