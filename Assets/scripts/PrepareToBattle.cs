using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrepareToBattle : MonoBehaviour {

    public Text timer;
    public float time = 4f;
    public float finalTime = 0.5f;
    void Update() {
        
        if(time >= 1){
             timer.text = ((int)time).ToString();
        }
       
        if(time <=1 && finalTime >= 0){
            timer.text = "Battle!";
            finalTime -= Time.deltaTime;
        }

        if(finalTime <= 0){
            SceneManager.LoadScene("BossLairFinal");
        }

        time -= Time.deltaTime;   
    }
}