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
			Debug.Log(col.gameObject.name);
			if(col.gameObject.name == "Plataform1"){
				gosmaSpawn = new Vector3(0.143f, 0.008f, 0.1879883f);
			}else if(col.gameObject.name == "Plataform2"){
				gosmaSpawn = new Vector3(6.748f, 0.009f, 0.1879883f);
			}else if(col.gameObject.name == "Plataform4"){
				gosmaSpawn = new Vector3(0.295f, 2.537f, 0.1879883f);
			}else if(col.gameObject.name == "Plataform5"){
				gosmaSpawn = new Vector3(6.741f, 2.556f, 0.1879883f);
			}else{
				gosmaSpawn = new Vector3(3.524f, 1.276f, 0.1879883f);
			}
			//Debug.Log("BateuNaPlataforma");
			//gosmaSpawn = myTransform.position;
			gosmaSpawn.y += 0.48f;
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
