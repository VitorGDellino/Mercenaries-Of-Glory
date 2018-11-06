using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour{

    public static CanvasManager instance;
   
    public GameObject[] canvas;
    public Character[] scripts;
    public Enemy scriptEnemy;

    void Init(){
        canvas = new GameObject[MainMenuController.instance.nPlayers];
        scripts = new Character[MainMenuController.instance.nPlayers];
        for(int i = 0; i < 4; i++){
            if(MainMenuController.instance.classesChosen[i] != -1){
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
        Debug.Log("ENTROU AQUI AS DUAS VEZES");
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
                var aux = canvas[i].transform.GetChild(2);
                var temp = aux.localScale;
                var hp  = scripts[i].GetHp();
                if(hp <= 0){
                    hp = 0;
                }
                temp[0] = hp*2;
                aux.localScale = temp;
            }
        }

        var auxEnemy = GameManager.instance.kahal.transform.GetChild(0);
        var tempEnemy = auxEnemy.localScale;
        tempEnemy[0] = scriptEnemy.status.GetHp()*0.2f;
        auxEnemy.localScale = tempEnemy;
    }

    private void updateSkill(int i, int skill){
        var aux = canvas[i].transform.GetChild(skill);
        int val = 0;
        if(skill == 0){
            val = (int)Mathf.Round(scripts[i].GetCd1());
        }else if(skill == 1){
            val = (int)Mathf.Round(scripts[i].GetCd2());
        }else if(skill == 5){
            val = (int)Mathf.Round(scripts[i].GetCd3());
        }

        aux.GetComponent<Text>().text = val.ToString(); 
    }

    private void SetCds(){
        for(int i = 0; i < 4; i++){
            if(MainMenuController.instance.classesChosen[i] != -1){
                updateSkill(i, 0);
                updateSkill(i, 1);
            }
        }
    }
}