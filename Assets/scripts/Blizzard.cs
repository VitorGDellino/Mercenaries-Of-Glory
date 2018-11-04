﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blizzard : MonoBehaviour {

	public int damage = 5;
	public float stun = 2.0f;

	private Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log("Colidi");
		if(col.gameObject.CompareTag("Player1")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			col.gameObject.SendMessageUpwards("takeStun", this.stun);
		}
		if(col.gameObject.CompareTag("Player2")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			col.gameObject.SendMessageUpwards("takeStun", this.stun);
		}
		if(col.gameObject.CompareTag("Player3")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			col.gameObject.SendMessageUpwards("takeStun", this.stun);
		}
		if(col.gameObject.CompareTag("Player4")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			col.gameObject.SendMessageUpwards("takeStun", this.stun);
		}
		if(col.gameObject.CompareTag("Enemy")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
		}
	}
}
