using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour{

    public static MainMenuController instance;

    public int nPlayers = 0;
    public int[] classesChosen;
    public int[] status;
    public GameObject[] classes; 

    public int winner = -1;
    
    void Awake(){
        MakeSingleton();
    }
    
    public void MakeSingleton(){
        if(instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}