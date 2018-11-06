using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour{
    public CharSelectionMenuInput input;
    void Update() {
        if(input.GetStart()){
            Restart();
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void Restart(){
        for(int i = 0; i < 4; i++){
            GameplayController.instance.MakeInstance();
            MainMenuController.instance.MakeSingleton();   
            GameManager.instance.MakeSingleton();
            InputManager.instance.MakeSingleton(); 
        }  
    }
}