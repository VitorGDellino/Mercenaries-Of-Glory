using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour{

    public static GameManager instance;

    public GameObject[] players = new GameObject[4];
    public GameObject[] playersUI = new GameObject[4];
    public GameObject kahal;

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