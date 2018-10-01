using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTest : MonoBehaviour{
    private Test player;

    void Start(){
        this.player = GetComponentInParent<Test>();
        this.player.setOnTheFloor(true);
    }

    void OnTriggerEnter2D(Collider2D col){
        this.player.setOnTheFloor(true);
    }

    void OnTriggerExit2D(Collider2D col){
        //this.player.setOnTheFloor(false);
    }
}