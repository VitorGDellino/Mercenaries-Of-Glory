using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour {

	public int damage = 5;
	public float acidSpeed = 5;

	private Transform myTransform;

	private Character player;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		myTransform.Translate (new Vector3 (1, 0, 0) * acidSpeed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col){

		Debug.Log("Colidi");
		if(col.gameObject.CompareTag("Player")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			Destroy (gameObject);
		}
		if(col.gameObject.CompareTag("Plataform")){
			Debug.Log("BateuNaPlataforma");
			Destroy (gameObject);	
		}
	}
}
