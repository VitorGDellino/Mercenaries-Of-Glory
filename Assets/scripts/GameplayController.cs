using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameplayController : MonoBehaviour{

    public static GameplayController instance;

    public GameObject canvasWaR;
    public GameObject canvasWaL;

    public GameObject canvasWiR;
    public GameObject canvasWiL;

    public GameObject canvasRR;
    public GameObject canvasRL;
    public GameObject kahalCanvas;

    public GameObject[] playerNum;




    void Awake(){
        MakeInstance();
    }

    void OnEnable(){
        //SceneManager.sceneLoaded += LevelFinishedLoading;
        LevelFinishedLoading();
    }



    void LevelFinishedLoading(){
        //if(scene.name == "BossLairFinal"){
            if(MainMenuController.instance.winner == -1){
                GameManager.instance.kahal = Instantiate(kahalCanvas, new Vector3(3.5f, 5.2f, 0f),  Quaternion.Euler (0, 0, 0));
                GameManager.instance.kahal.name = "KahalCanvas";
                Vector3[] pos = new [] { new Vector3(-1.624391f,5.05922f,0f), new Vector3(8.756165f,5.105769f,0f), new Vector3(-1.7f,-1.67f,0f), new Vector3(8.76f,-1.72f,0f) };
                
                for(int i = 0; i < 4; i++){
                    if(MainMenuController.instance.classesChosen[i] != -1){
                        GameManager.instance.players[i] = Instantiate(MainMenuController.instance.classes[MainMenuController.instance.classesChosen[i]], new Vector3(i*2.5f, 0, 0),  Quaternion.Euler (0, 0, 0)) as GameObject;
                        if(i % 2 == 0){
                            if(MainMenuController.instance.classesChosen[i] == 0){
                                GameManager.instance.playersUI[i] = Instantiate(canvasWaL, pos[i],  Quaternion.Euler (0, 0, 0)) as GameObject;
                            }else if(MainMenuController.instance.classesChosen[i] == 1){
                                GameManager.instance.playersUI[i] = Instantiate(canvasWiL, pos[i],  Quaternion.Euler (0, 0, 0)) as GameObject;
                            }else if(MainMenuController.instance.classesChosen[i] == 2){
                                GameManager.instance.playersUI[i] = Instantiate(canvasRL, pos[i],  Quaternion.Euler (0, 0, 0)) as GameObject;
                            }
                        }else{
                            if(MainMenuController.instance.classesChosen[i] == 0){
                                GameManager.instance.playersUI[i] = Instantiate(canvasWaR, pos[i],  Quaternion.Euler (0, 0, 0)) as GameObject;
                            }else if(MainMenuController.instance.classesChosen[i] == 1){
                                GameManager.instance.playersUI[i] = Instantiate(canvasWiR, pos[i],  Quaternion.Euler (0, 0, 0)) as GameObject;
                            }else if(MainMenuController.instance.classesChosen[i] == 2){
                                GameManager.instance.playersUI[i] = Instantiate(canvasRR, pos[i],  Quaternion.Euler (0, 0, 0)) as GameObject;
                            } 
                        } 
                        GameManager.instance.players[i].name = "Player" + (i+1);
                        GameManager.instance.players[i].tag = "Player" + (i+1);
                        GameManager.instance.playersUI[i].name = "Player"+ (i+1) + "Canvas";
                        Vector3 posAux = GameManager.instance.players[i].transform.position;
                        posAux.y += 0.8f;
                        GameObject aux =  Instantiate(playerNum[i], posAux, Quaternion.Euler (0, 0, 0)) as GameObject;
                        aux.transform.parent = GameManager.instance.players[i].transform;
                    }
                    
                }
            }
        //}
    }

    public void MakeInstance(){
        if(instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}