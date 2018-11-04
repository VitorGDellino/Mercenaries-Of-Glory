﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : Character {

	public GameObject Arrow;
	public GameObject trap;

	private float TimeBasicAtk;
	private float TimeTrap;
	private float TimeReinforceArrow;
	private float TimeLightFeet;

	private bool LightFeetBuff;
	private bool facingRight;

	private float cdBasicAtk;
	private float cdTrap;
	private float cdReinforceArrow;	//Cooldown da habilidade Reforçar flecha
	private float cdLightFeet;      //Cooldown da habilidade Pés leves

	public GameObject clone;

	private Vector3 temp;

	float h;

    public Ranger(string name, Status status, Weapon weapon, Armor armor)
        : base(name, status, weapon, armor){
    }
    // Use this for initialization

	void Awake(){
		this.status = new Status(100, 10, 10, 1.5f, 10.0f);
		this.weapon = new Weapon("Long Sword", 5, "Melee", "A common sword", 4);
		this.armor = new Armor("Chain Mail", 5, "Hard Armor", "Heavy armor, but powerful", 4);
		this.totalAtk = this.weapon.GetAtk() + this.status.GetAtk();
		this.totalDef = this.armor.GetDef() + this.status.GetDef();

		inputGamepad = this.GetComponent<PlayerInput>();
	}
	void Start () {

		facingRight = true;

		cdBasicAtk = 1.0f;
		cdTrap = 5.0f;
		cdReinforceArrow = 5.0f;	//Cooldown da habilidade Reforçar flecha
		cdLightFeet = 10.0f;

		LightFeetBuff = false;

		TimeBasicAtk = 0.0f;
		Time1 = TimeTrap = 0.0f;
		Time2 = TimeReinforceArrow = 0.0f;
		Time3 = TimeLightFeet = 0.0f;

		tempoStun = 0.0f;
		RespawnTime = 10.0f;

		setDirection(1);

		this.rb = GetComponent<Rigidbody2D>();
		this.sprite = GetComponentInChildren<SpriteRenderer>();
		this.t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(tempoStun<=0.0f || !status.IsDead()){
			this.Movement();

			//h = Input.GetAxisRaw ("Horizontal");

			//Debug.Log (h);

			if(inputGamepad.GetAttack() && TimeBasicAtk <= 0){
				TimeBasicAtk = cdBasicAtk;
				BasicAtk ();
			}

			if(inputGamepad.GetSkill1() && TimeTrap <= 0){
				TimeTrap = cdTrap;
				Trap ();
			}

			if(inputGamepad.GetSkill2() && TimeLightFeet <= 0){
				TimeLightFeet = cdLightFeet;
				LightFeet ();
			}

			if(inputGamepad.GetSkill3() && TimeReinforceArrow <= 0){
				TimeReinforceArrow = cdReinforceArrow;
				ReinforceArrow ();
			}
		}
		
		if (Input.GetAxisRaw ("Horizontal") == 1) {
			facingRight = true;
		}if(Input.GetAxisRaw ("Horizontal") == -1){
			facingRight = false;
		}
		TimeBasicAtk -= Time.deltaTime;
		TimeTrap -= Time.deltaTime;
		TimeLightFeet -= Time.deltaTime;
		TimeReinforceArrow -= Time.deltaTime;

		if(TimeTrap <= 0) TimeTrap = 0;
		if(TimeLightFeet <= 0) TimeLightFeet = 0;
		if(TimeReinforceArrow <= 0) TimeReinforceArrow = 0;

		if(LightFeetBuff && TimeLightFeet<=cdLightFeet/2){
			this.status.SetSpeed (1.5f);
			LightFeetBuff = false;
		}

		if(invincibleTime<0.0f)
			invincible = false;

		if(cdRespawn<0.0f && status.IsDead()){
			Debug.Log("Reviveu");
			status.SetHp(10);
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
            this.t.position = new Vector3(Random.Range(-3.0f, 10.0f), 0.0f, -0.05448645f);
		}

		tempoStun -= Time.deltaTime;
		invincibleTime -= Time.deltaTime;
		cdRespawn -= Time.deltaTime;

		Time1 = TimeTrap;
		Time2 = TimeLightFeet;
		Time3 = TimeReinforceArrow;
	}

	//Metodo que implementa a habilidade reforçar flecha
	void ReinforceArrow(){

	}

	//Metodo que implementa o ataque com suas adagas
	void Trap(){
		temp = transform.position;
		if(!facingRight){
			temp.x -= 0.5f;
			clone = Instantiate (trap, temp, transform.localRotation);
		}else if(facingRight){
			temp.x += 0.5f;
			clone = Instantiate (trap, temp, transform.localRotation);
		}
		clone.tag = gameObject.tag;
	}

	//Metodo que implementa a habilidade aumentar velocidade
	void LightFeet(){
		this.status.SetSpeed (3.0f);
		LightFeetBuff = true;
	}

	//Metodo que implementa o ataque básico da arqueira
	void BasicAtk(){
		temp = transform.position;
		if(!facingRight){
			temp.x -= 0.5f;
			clone = Instantiate (Arrow, temp, Quaternion.Euler (0, 0, 0));
		}else if(facingRight){
			temp.x += 0.5f;
			clone = Instantiate (Arrow, temp, Quaternion.Euler (0, 0, 180));
		}
		clone.tag = gameObject.tag;
	}
}
