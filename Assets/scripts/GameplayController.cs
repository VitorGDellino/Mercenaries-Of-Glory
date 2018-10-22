using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameplayController : MonoBehaviour{

    public static GameplayController instance;
    public GameObject canvas1;
    public GameObject canvas2;

    void Awake(){
        MakeInstance();
    }

    void OnEnable(){
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    void LevelFinishedLoading(Scene scene, LoadSceneMode mode){
        if(scene.name == "BossLair"){
            if(MainMenuController.instance.winner == -1){
                Vector3[] pos = new [] { new Vector3(0f,5f,0f), new Vector3(5f,5f,0f), new Vector3(0f,-1f,0f), new Vector3(5f,0f,0f) };
                
                for(int i = 0; i < MainMenuController.instance.nPlayers; i++){
                    GameManager.instance.players[i] = Instantiate(MainMenuController.instance.classes[MainMenuController.instance.classesChosen[i]], new Vector3(i*2, 0, 0),  Quaternion.Euler (0, 0, 0)) as GameObject;
                    if(i % 2 == 0){
                        GameManager.instance.playersUI[i] = Instantiate(canvas1, pos[i],  Quaternion.Euler (0, 0, 0)) as GameObject;
                    }else{
                        GameManager.instance.playersUI[i] = Instantiate(canvas2, pos[i],  Quaternion.Euler (0, 0, 0)) as GameObject; 
                    } 
                    GameManager.instance.players[i].name = "Player" + (i+1);
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