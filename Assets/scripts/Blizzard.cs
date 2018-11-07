using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blizzard : MonoBehaviour {

	public int damage = 5;
	public float stun = 2.0f;

	private Transform myTransform;
    public InfAtk atkInfo;

	// Use this for initialization
	void Start () {
		myTransform = transform;
        atkInfo = new InfAtk(damage, gameObject.tag);
	}
	
	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log("Colidi");
		if(gameObject.tag != col.tag){
			Debug.Log(gameObject.tag);
			Debug.Log(col.tag);
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
				col.gameObject.SendMessageUpwards("takeDamage", this.atkInfo);
			}
		}
	}
}
