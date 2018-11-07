using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour {

	public int damage = 5;
	public float acidSpeed = 5;

	public GameObject gosma;
	private Transform myTransform;
	private Vector3 gosmaSpawn;

	private Character player;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		myTransform.Translate (new Vector3 (1, 0, 0) * acidSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Plataform")){
			//Debug.Log("BateuNaPlataforma");
			gosmaSpawn = myTransform.position;
			gosmaSpawn.y += 0.45f;
			Instantiate (gosma, gosmaSpawn, Quaternion.Euler (0, 0, 0));
			Destroy (gameObject);
		}
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
