using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public float damage = 5;
	public float rotationSpeed;
	public float arrowSpeed = 5;

	private Transform myTransform;

	private Character player;

	/*private Vector3 mousePoint;

	private bool canTranslate = true;
	private bool canRotate = false;*/

	void Awake(){
		this.player = GetComponentInParent<Character>();
	}

	// Use this for initialization
	void Start () {
		myTransform = transform;

		/*mousePoint = v;

		if(mousePoint.y > 200){
			myTransform.rotation = Quaternion.Euler (0, 150, 0);
			rotationSpeed = Random.Range (2.5f, 5f);
			StartCoroutine ("CanRotate", Random.Range (0.25f, 0.5f));
		}

		if(mousePoint.y > 100 && mousePoint.y < 200){
			myTransform.rotation = Quaternion.Euler (0, 170, 0);
			rotationSpeed = Random.Range (4f, 8f);
			StartCoroutine ("CanRotate", Random.Range (0.15f, 0.3f));
		}

		if(mousePoint.y < 100){
			myTransform.rotation = Quaternion.Euler (0, 200, 0);
			rotationSpeed = Random.Range (20f, 40f);
			StartCoroutine ("CanRotate", Random.Range (0.05f, 0.1f));
		}*/
	}
	
	// Update is called once per frame
	void Update () {

		myTransform.Translate (new Vector3 (-1, 0, 0) * arrowSpeed * Time.deltaTime);


		//if(){

		//}


		/*if (canRotate = true) {
			myTransform.Rotate (0, (mousePoint.y / 10) * Time.deltaTime * rotationSpeed, 0);
		}
		if(canTranslate = true){
			myTransform.Translate (new Vector3 (-1, 0, 0) * arrowSpeed * Time.deltaTime);
		}
		if(myTransform.position.z <= - 2.2f){
			StartCoroutine ("Destroy");
		}*/
	}
	/*
	IEnumerator Destroy(){
		canTranslate = false;
		canRotate = false;
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}

	IEnumerator CanRotate (float f){
		yield return new WaitForSeconds (f);
		canRotate = true;

		yield return new WaitForSeconds (f * 2);
		canRotate = false;
	}*/

	/*void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Player" && player.gameObject != other.gameObject){
			Debug.Log(other.gameObject.name);
			Debug.Log("Apanhei");
			other.gameObject.SendMessageUpwards("takeDamage", this.player.getAtk());
		}    

		Destroy (gameObject);

	}*/

	void OnCollisionEnter2D(Collision2D col){
/* 
		if (col.gameObject.tag == "Player" && player.gameObject != col.gameObject){
			Debug.Log(col.gameObject.name);
			Debug.Log("Apanhei");
			col.gameObject.SendMessageUpwards("takeDamage", this.player.getAtk());
		}   */ 

		Destroy (gameObject);

	}
}