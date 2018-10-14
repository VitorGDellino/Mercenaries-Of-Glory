using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulcan : MonoBehaviour {

	public int damage = 5;
	public float vulcanSpeed = 5;

	private Transform myTransform;

	private Character player;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		myTransform.Translate (new Vector3 (0, 1, 0) * vulcanSpeed * Time.deltaTime);

	}


	void OnCollisionEnter2D(Collision2D col){

		Debug.Log("Colidi");
		if(col.gameObject.tag == "Player"){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
		}
	}
}