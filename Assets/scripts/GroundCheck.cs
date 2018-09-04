using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour{
    private Character player;

    void Start(){
        this.player = GetComponentInParent<Character>();
    }

    void OnTriggerEnter2D(Collider2D col){
        this.player.setOnTheFloor(true);
    }

    void OnTriggerExit2D(Collider2D col){
        this.player.setOnTheFloor(false);
    }
}