<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	public float damage = 5;

	private Transform myTransform;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D col){

		if(col.gameObject.tag == "Player"){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			Destroy (gameObject);
		}else if(col.gameObject.tag == "Enemy"){
			//collider2D.gameObject.GetComponent<Enemy> ().takeDamage (damage);
			Destroy (gameObject);
		}


	}
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	public float damage = 5;

	private Transform myTransform;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D col){

		if(col.gameObject.tag == "Player"){
			//collider2D.gameObject.GetComponent<
			Destroy (gameObject);
		}else if(col.gameObject.tag == "Enemy"){
			//collider2D.gameObject.GetComponent<Enemy> ().takeDamage (damage);
			Destroy (gameObject);
		}


	}
}
>>>>>>> pm
