using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour{

    public static MainMenuController instance;

    public int nPlayers;
    public int[] classesChosen;
    public GameObject[] classes; 

    public int winner = -1;
    
    void Awake(){
        MakeSingleton();
    }
    
    private void MakeSingleton(){
        if(instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}