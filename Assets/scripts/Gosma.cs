using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gosma : MonoBehaviour {

	private int damage = 20;
	private float time = 3.0f;

	private Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(time <= 0.0f){
			Destroy(gameObject);
		}
		time -= Time.deltaTime;
	}
	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log("Colidi");
		if(col.gameObject.CompareTag("Player1")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
		}
		if(col.gameObject.CompareTag("Player2")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
		}
		if(col.gameObject.CompareTag("Player3")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
		}
		if(col.gameObject.CompareTag("Player4")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
		}
	}
}