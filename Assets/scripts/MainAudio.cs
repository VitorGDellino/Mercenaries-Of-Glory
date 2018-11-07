using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainAudio : MonoBehaviour {
    public AudioSource source;
    public AudioClip mainTheme;
    //public AudioClip fanfare;
    void Start(){
        source = GetComponent<AudioSource>();
    }
}