using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	public float damage = 5.0f;
	public float stun = 2.0f;

	private Transform myTransform;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("Player1")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			col.gameObject.SendMessageUpwards("takeStun", this.stun);
			Destroy (gameObject);
		}
		if(col.gameObject.CompareTag("Player2")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			col.gameObject.SendMessageUpwards("takeStun", this.stun);
			Destroy (gameObject);
		}
		if(col.gameObject.CompareTag("Player3")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			col.gameObject.SendMessageUpwards("takeStun", this.stun);
			Destroy (gameObject);
		}
		if(col.gameObject.CompareTag("Player4")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			col.gameObject.SendMessageUpwards("takeStun", this.stun);
			Destroy (gameObject);
		}
        if(col.gameObject.CompareTag("Enemy")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			Destroy (gameObject);
		}
	}
}