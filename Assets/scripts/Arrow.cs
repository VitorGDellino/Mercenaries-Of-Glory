using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	private int damage = 10;
	public float rotationSpeed = 100;
	public float arrowSpeed;

	private Transform myTransform;
    public InfAtk atkInfo;

	private Character player;
	SpriteRenderer sprite;


	void Awake(){
		this.player = GetComponentInParent<Character>();
	}

	// Use this for initialization
	void Start () {
		damage = 25;
		arrowSpeed = 15;
		myTransform = transform;
		rotationSpeed = -100;
		sprite = GetComponent<SpriteRenderer>();
        atkInfo = new InfAtk(damage, gameObject.tag);
		arrowSpeed = 15.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		myTransform.Translate (new Vector3 (-1, 0, 0) * arrowSpeed * Time.deltaTime);

	}

	void OnTriggerEnter2D(Collider2D col){
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
        if(col.gameObject.CompareTag("Enemy")){
			col.gameObject.SendMessageUpwards("takeDamage", this.atkInfo);
			Destroy (gameObject);
		}
		if(col.gameObject.CompareTag("Plataform") || col.gameObject.CompareTag("LastGround")){
			Destroy (gameObject);
		}
		if(col.gameObject.CompareTag("Parede")){
			Destroy (gameObject);
		}
	}
}