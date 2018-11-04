﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject meteor;
	public GameObject vulcan;
	public GameObject acid;
	public GameObject KahalHead;
	public GameObject KahalLHand;
	public GameObject KahalRHand;

	private float timeEarthquake;
	private float TimeVulcan;
	private float TimeMeteor;
	private float TimeAcid;
	private float TimeHead;
	private float timeHands;

	private float SkillTime = 1.0f;
	private float Timer = 2.0f;

	private float cdEarthquake = 2.0f;
	private float cdVulcan = 2.0f;
	private float cdMeteor = 2.0f;
	private float cdAcid = 2.0f;
	private float cdHead = 2.0f;
	public float handSpeed = 1.0f;

    public Status status;        //Status do personagem

	private GameObject[] Players;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private Vector3 leftHandDiference;
	private Vector3 rightHandDiference;
	private Vector3 rotation;
	private bool headPos;

	private int ataque;
	private int maxHP = 100;

	// Use this for initialization
	void Start () {
		this.status = new Status(maxHP, 10, 10, 1.5f, 10.0f); //hp, attack, def, speed, respawn time
		headPos = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(Timer<=0){
			ataque = Random.Range(7,8);
			//Debug.Log(ataque);

			if(ataque==0 && timeEarthquake <= 0){
				timeEarthquake = cdEarthquake;
				Earthquake ();
			}

			if(ataque==1 && TimeVulcan <= 0){
				TimeVulcan = cdVulcan;
				Vulcan ();
			}

			if(ataque==2 && TimeMeteor <= 0){
				TimeMeteor = cdMeteor;
				Meteor ();
			}

			if(ataque==3 && TimeAcid <= 0){
				TimeAcid = cdAcid;
				Acid ();
			}

			if(ataque==4 && TimeHead <= 0){
				TimeHead = cdHead;
				if(headPos){
					TeleportHead (3.5f, 0.0f);
					headPos = false;
				}else{
					TeleportHead (3.5f, 3.5f);
					headPos = true;
				}
			}

			if(ataque==5){
				leftHandDiference = MoveHand(KahalLHand);
				rightHandDiference = MoveHand(KahalRHand);
				timeHands = 0.0f;
			}
			if((status.GetHp() - maxHP)/maxHP < 0.3){
				Timer = SkillTime;
			}else if((status.GetHp() - maxHP)/maxHP < 0.6){
				Timer = SkillTime - 2;
			}else{
				Timer = SkillTime - 4;
			}

		}

		if(timeHands <= 1.0f){
			KahalLHand.transform.Translate(leftHandDiference * Time.deltaTime * handSpeed);
			KahalRHand.transform.Translate(rightHandDiference * Time.deltaTime * handSpeed);
			timeHands += Time.deltaTime;
		}

		Timer -= Time.deltaTime;
		timeEarthquake -= Time.deltaTime;
		TimeVulcan -= Time.deltaTime;
		TimeMeteor -= Time.deltaTime;
		TimeAcid -= Time.deltaTime;
		TimeHead -= Time.deltaTime;
	}

	//Metodo que implementa a habilidade terremoto
	void Earthquake(){
		Players = GameObject.FindGameObjectsWithTag("Player");

		for(int i=0; i<Players.Length; i++){
			if(Players[i].GetComponent<Character>().getOnTheFloor()){
				Players[i].SendMessageUpwards("takeDamage", 10);
				Players[i].SendMessageUpwards("takeStun", 2);
			}
		}
	}

	//Metodo que implementa o ataque vulcao
	void Vulcan(){
		startPosition = new Vector3(Random.Range(-5.0f, -4.0f), -1.0f, 0.0f);
		for(int i=0; i<10; i++){
			Instantiate (vulcan, startPosition, Quaternion.Euler (0, 0, 0));
			startPosition.x += 2.0f;
		}
	}

	//Metodo que implementa a habilidade meteoro
	void Meteor(){
		for(int i=0; i<10; i++){
			startPosition = new Vector3(Random.Range(-7.0f, 14.0f), Random.Range(6.0f, 8.0f), 0);
			endPosition = new Vector3(Random.Range(-3.5f, 10.5f), -1, 0);
			Vector3 diference = endPosition - startPosition;
			Vector3 frente = new Vector3(1, 0, 0);
       		float angle = Vector3.Angle(diference, frente);
			Instantiate (meteor, startPosition, Quaternion.Euler (0, 0, -angle));
		}
	}

	//Metodo que implementa o golpe acido
	void Acid(){
		startPosition = KahalHead.transform.position;
		int platform = Random.Range(0,5);

		if(platform==0){
			endPosition = new Vector3(0.2f, 2.5f, 0.0f);
		}else if(platform==1){
			endPosition = new Vector3(6.7f, 2.5f, 0.0f);
		}else if(platform==2){
			endPosition = new Vector3(3.6f, 1.3f, 0.0f);
		}else if(platform==3){
			endPosition = new Vector3(0.2f, 0.0f, 0.0f);
		}else if(platform==4){
			endPosition = new Vector3(6.7f, 0.0f, 0.0f);
		}else{
			endPosition = new Vector3(3.6f, 1.3f, 0.0f);
		}
		Vector3 diference = endPosition - startPosition;
		Vector3 frente = new Vector3(1, 0, 0);
		float angle = Vector3.Angle(diference, frente);
		Instantiate (acid, startPosition, Quaternion.Euler (0, 0, -angle));
	}

	void TeleportHead(float x, float y){
		startPosition = new Vector3(x, y, 0);
		KahalHead.transform.position = startPosition;
	}
	Vector3 MoveHand(GameObject hand){
		startPosition = hand.transform.position;
		endPosition = new Vector3(Random.Range(-1.0f, 8.0f), Random.Range(-1.0f, 4.0f), 0);
		Vector3 diference = endPosition - startPosition;
		return diference;
	}

	public virtual void takeDamage(int damage){
        status.SetHp(status.GetHp()-damage);
        Debug.Log("INIMIGOTOMOUDANO");
    }
}