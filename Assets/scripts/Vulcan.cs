using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulcan : MonoBehaviour {

	public int damage = 5;
	public float vulcanSpeed = 1;
	private float time = 3.0f;

	private Transform myTransform;

	private Character player;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(time > 2.0f){
			myTransform.localScale += (new Vector3 (0, 1, 0) * vulcanSpeed * Time.deltaTime);
			myTransform.Translate (new Vector3 (0.0f, 0.5f, 0.0f) * vulcanSpeed * Time.deltaTime);
		}
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