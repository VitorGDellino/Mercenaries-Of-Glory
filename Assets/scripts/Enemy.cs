using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject meteor;
	public GameObject vulcan;
	public GameObject acid;

	private float TimEarthquake;
	private float TimeVulcan;
	private float TimeMeteor;
	private float TimeAcid;

	private float cdEarthquake = 5.0f;
	private float cdVulcan = 5.0f;
	private float cdMeteor = 5.0f;
	private float cdAcid = 5.0f;

    protected Status status;        //Status do personagem

	private GameObject[] Players;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private Vector3 rotation;

	// Use this for initialization
	void Start () {
		this.status = new Status(100, 10, 10, 1.5f, 10.0f); //hp, attack, def, speed, respawn time
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.Z) && TimEarthquake <= 0){
			TimEarthquake = cdEarthquake;
			Earthquake ();
		}

		if(Input.GetKey(KeyCode.X) && TimeVulcan <= 0){
			TimeVulcan = cdVulcan;
			Vulcan ();
		}

		if(Input.GetKey(KeyCode.C) && TimeMeteor <= 0){
			TimeMeteor = cdMeteor;
			Meteor ();
		}

		if(Input.GetKey(KeyCode.V) && TimeAcid <= 0){
			TimeAcid = cdAcid;
			Acid ();
		}
		
		TimEarthquake -= Time.deltaTime;
		TimeVulcan -= Time.deltaTime;
		TimeMeteor -= Time.deltaTime;
		TimeAcid -= Time.deltaTime;
	}

	//Metodo que implementa a habilidade terremoto
	void Earthquake(){
		Players = GameObject.FindGameObjectsWithTag("Player");

		for(int i=0; i<Players.Length; i++){
			if(Players[i].GetComponent<Character>().getOnTheFloor()){
				Players[i].SendMessageUpwards("takeDamage", 10);
			}
		}
	}

	//Metodo que implementa o ataque vulcao
	void Vulcan(){
		startPosition = new Vector3(Random.Range(-5.0f, -4.0f), -10, 0);
		for(int i=0; i<10; i++){
			Instantiate (vulcan, startPosition, Quaternion.Euler (0, 0, 0));
			startPosition.x += 2.0f;
		}
	}

	//Metodo que implementa a habilidade meteoro
	void Meteor(){
		for(int i=0; i<10; i++){
			startPosition = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(3.0f, 4.0f), 0);
			endPosition = new Vector3(Random.Range(-3.5f, 3.5f), 0, 0);
			Vector3 diference = endPosition - startPosition;
			Vector3 frente = new Vector3(1, 0, 0);
       		float angle = Vector3.Angle(diference, frente);
			Instantiate (meteor, startPosition, Quaternion.Euler (0, 0, -angle));
		}
	}

	//Metodo que implementa o golpe acido
	void Acid(){
		startPosition = transform.position;
		endPosition = new Vector3(Random.Range(0.0f, 7.0f), 0, 0);
		Vector3 diference = endPosition - startPosition;
		Vector3 frente = new Vector3(1, 0, 0);
		float angle = Vector3.Angle(diference, frente);
		Instantiate (meteor, startPosition, Quaternion.Euler (0, 0, -angle));
	}
}