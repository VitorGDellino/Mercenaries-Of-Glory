using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameplayController : MonoBehaviour{

    public static GameplayController instance;
    public GameObject canvas1;
    public GameObject canvas2;

    public GameObject kahalCanvas;

    void Awake(){
        MakeInstance();
    }

    void OnEnable(){
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    void LevelFinishedLoading(Scene scene, LoadSceneMode mode){
        if(scene.name == "BossLairTeste"){
            if(MainMenuController.instance.winner == -1){
                Instantiate(kahalCanvas, new Vector3(3.5f, 5.2f, 0f),  Quaternion.Euler (0, 0, 0));
                Vector3[] pos = new [] { new Vector3(-2.5f,5.3f,0f), new Vector3(9.5f,5.3f,0f), new Vector3(-2.5f,-1.9f,0f), new Vector3(9.5f,-1.9f,0f) };
                
                for(int i = 0; i < MainMenuController.instance.nPlayers; i++){
                    GameManager.instance.players[i] = Instantiate(MainMenuController.instance.classes[MainMenuController.instance.classesChosen[i]], new Vector3(i*2.5f, 0, 0),  Quaternion.Euler (0, 0, 0)) as GameObject;
                    if(i % 2 == 0){
                        GameManager.instance.playersUI[i] = Instantiate(canvas1, pos[i],  Quaternion.Euler (0, 0, 0)) as GameObject;
                    }else{
                        GameManager.instance.playersUI[i] = Instantiate(canvas2, pos[i],  Quaternion.Euler (0, 0, 0)) as GameObject; 
                    } 
                    GameManager.instance.players[i].name = "Player" + (i+1);
                    GameManager.instance.players[i].tag = "Player" + (i+1);
                    GameManager.instance.playersUI[i].name = "Player"+ (i+1) + "Canvas";

                }
            }
        }
    }

    private void InitUI(int index){
        //GameManager.instance.playersUI[index]. 
    }
    private void MakeInstance(){
        if(instance != null){
            instance = this;
        }
    }
}