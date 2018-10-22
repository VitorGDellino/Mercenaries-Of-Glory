using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour{

    public static CanvasManager instance;
   
    public GameObject[] canvas;

    void Init(){
        canvas = new GameObject[MainMenuController.instance.nPlayers];
        for(int i = 0; i < MainMenuController.instance.nPlayers; i++){
            canvas[i] = GameObject.Find(GameManager.instance.players[i].name + "Canvas");
        }
    }
    void Start(){
        Init();
        SetHpBar();
        SetCds();
    }

    void Update(){
        SetHpBar();
        SetCds();
    }

    private void SetHpBar(){
        for(int i = 0; i < MainMenuController.instance.nPlayers; i++){
            var aux = canvas[i].transform.GetChild(6);
            var temp = aux.localScale;
            temp[0] = 40f*2;
            aux.localScale = temp;
        }
    }

    private void SetCds(){

    }
}