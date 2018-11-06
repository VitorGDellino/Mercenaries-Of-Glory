using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour{

    public static CanvasManager instance;
   
    public GameObject[] canvas;
    public Character[] scripts;
    public GameObject canvasEnemy;
    public Enemy scriptEnemy;

    void Init(){
        canvas = new GameObject[4];
        scripts = new Character[4];
        for(int i = 0; i < 4; i++){
            if(MainMenuController.instance.classesChosen[i] != -1){
                //Debug.Log(GameManager.instance.players[i].name + "Canvas");
                canvas[i] = GameObject.Find(GameManager.instance.players[i].name + "Canvas");
                if(MainMenuController.instance.classesChosen[i] == 0){
                    scripts[i] = GameManager.instance.players[i].GetComponent<Warrior>();
                }else if(MainMenuController.instance.classesChosen[i] == 1){
                    scripts[i] = GameManager.instance.players[i].GetComponent<Wizard>();
                }else if(MainMenuController.instance.classesChosen[i] == 2){
                    scripts[i] = GameManager.instance.players[i].GetComponent<Ranger>();
                }

                scripts[i].inputGamepad.nPlayer = i + 1;
            }
            
        }
        scriptEnemy = GameObject.Find("KaHal").GetComponent<Enemy>();
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
        for(int i = 0; i < 4; i++){
            if(MainMenuController.instance.classesChosen[i] != -1){
                var aux = canvas[i].transform.GetChild(6);
                var temp = aux.localScale;
                temp[0] = scripts[i].GetHp()*2;
                aux.localScale = temp;
            }
           
        }

        /*var auxEnemy = canvasEnemy.transform.GetChild(0);
        var tempEnemy = auxEnemy.localScale;
        tempEnemy[0] = scriptEnemy.status.GetHp()*0.5f;
        auxEnemy.localScale = tempEnemy;*/
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
        for(int i = 0; i < 4; i++){
            if(MainMenuController.instance.classesChosen[i] != -1){
                updateSkill(i, 3);
                updateSkill(i, 4);
                updateSkill(i, 5);
            }    
        }

    }
}