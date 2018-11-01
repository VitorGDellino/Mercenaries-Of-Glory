using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

	public int damage = 20;
	public float meteorSpeed = 5;

	private Transform myTransform;

	private Character player;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		myTransform.Translate (new Vector3 (1, 0, 0) * meteorSpeed * Time.deltaTime);
	}

	
	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log("Colidi");
		//Destroy (gameObject);
		if(col.gameObject.CompareTag("Player1")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			Destroy (gameObject);
		}
		if(col.gameObject.CompareTag("Player2")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			Destroy (gameObject);
		}
		if(col.gameObject.CompareTag("Player3")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			Destroy (gameObject);
		}
		if(col.gameObject.CompareTag("Player4")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			Destroy (gameObject);
		}
		if(col.gameObject.CompareTag("LastGround")){
			Destroy (gameObject);
		}
	}
}