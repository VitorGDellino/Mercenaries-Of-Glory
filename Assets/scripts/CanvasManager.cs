using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour{

    public static CanvasManager instance;
   
    public GameObject[] canvas;
    public Character[] scripts;

    void Init(){
        canvas = new GameObject[MainMenuController.instance.nPlayers];
        scripts = new Character[MainMenuController.instance.nPlayers];
        for(int i = 0; i < MainMenuController.instance.nPlayers; i++){
            Debug.Log(GameManager.instance.players[i].name + "Canvas");
            canvas[i] = GameObject.Find(GameManager.instance.players[i].name + "Canvas");
            if(MainMenuController.instance.classesChosen[i] == 0){
                scripts[i] = GameManager.instance.players[i].GetComponent<Warrior>();
            }else if(MainMenuController.instance.classesChosen[i] == 1){
                scripts[i] = GameManager.instance.players[i].GetComponent<Wizard>();
            }else if(MainMenuController.instance.classesChosen[i] == 2){
                scripts[i] = GameManager.instance.players[i].GetComponent<Ranger>();
            }   
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
            temp[0] = scripts[i].GetHp()*2;
            aux.localScale = temp;
        }
    }

    private void updateSkill(int i, int skill){
        var aux = canvas[i].transform.GetChild(skill);
        int val = 0;
        if(skill == 3){
            val = (int)Mathf.Round(scripts[i].GetCd1());
        }else if(skill == 4){
            val = (int)Mathf.Round(scripts[i].GetCd2());
        }else if(skill == 5){
            val = (int)Mathf.Round(scripts[i].GetCd3());
        }

        aux.GetComponent<Text>().text = val.ToString(); 
    }

    private void SetCds(){
        for(int i = 0; i < MainMenuController.instance.nPlayers; i++){
            updateSkill(i, 3);
            updateSkill(i, 4);
            updateSkill(i, 5);
        }

    }
}