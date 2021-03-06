﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour{
    private Character player;

    void Start(){
        this.player = GetComponentInParent<Character>();
    }

    void OnTriggerEnter2D(Collider2D col){
        this.player.setOnTheFloor(true);
        player.jumping = false; // animation
        player.jumpCheckpoint = false;
    }

    void OnTriggerExit2D(Collider2D col){
        this.player.setOnTheFloor(false);
        this.player.SetDoubleJump();
    }

    void OnTriggerStay2D(Collider2D other){
        /* if(Input.GetAxis("Vertical") < 0 && Input.GetButtonDown("Jump") && other.CompareTag("Plataform")){
            var parent = transform.parent.gameObject;
            var pos = parent.transform.position;
            pos[1] = pos[1] - 0.35f;
            parent.transform.position = pos;
            Debug.Log("Funcionou");
        }*/
    }
}