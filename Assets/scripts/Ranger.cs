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


	private Vector3 temp;

	float h;

    public Ranger(string name, Status status, Weapon weapon, Armor armor)
        : base(name, status, weapon, armor){
    }
    // Use this for initialization
	void Start () {

		facingRight = true;

		cdBasicAtk = 1.0f;
		cdTrap = 5.0f;
		cdReinforceArrow = 5.0f;	//Cooldown da habilidade Reforçar flecha
		cdLightFeet = 10.0f;

		LightFeetBuff = false;

		TimeBasicAtk = 0.0f;
		TimeTrap = 0.0f;
		TimeReinforceArrow = 0.0f;
		TimeLightFeet = 0.0f;

<<<<<<< HEAD
		this.status = new Status(100, 10, 10, 1.5f, 10.0f);
=======
		

		this.status = new Status(10, 10, 10, 1.5f, 10.0f);
>>>>>>> pm
		this.weapon = new Weapon("Long Sword", 5, "Melee", "A common sword", 4);
		this.armor = new Armor("Chain Mail", 5, "Hard Armor", "Heavy armor, but powerful", 4);
		this.totalAtk = this.weapon.GetAtk() + this.status.GetAtk();
		this.totalDef = this.armor.GetDef() + this.status.GetDef();

		this.rb = GetComponent<Rigidbody2D>();
		this.sprite = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.Movement();

		h = Input.GetAxisRaw ("Horizontal");

		//Debug.Log (h);

		if(Input.GetKey(KeyCode.Q) && TimeBasicAtk <= 0){
			TimeBasicAtk = cdBasicAtk;
			BasicAtk ();
		}

		if(Input.GetKey(KeyCode.W) && TimeTrap <= 0){
			TimeTrap = cdTrap;
			Trap ();
		}

		if(Input.GetKey(KeyCode.E) && TimeLightFeet <= 0){
			TimeLightFeet = cdLightFeet;
			LightFeet ();
		}

		if(Input.GetKey(KeyCode.R) && TimeReinforceArrow <= 0){
			TimeReinforceArrow = cdReinforceArrow;
			ReinforceArrow ();
		}
<<<<<<< HEAD
		
		if (Input.GetAxisRaw ("Horizontal") == 1) {
			facingRight = true;
		}if(Input.GetAxisRaw ("Horizontal") == -1){
			facingRight = false;
		}
=======

>>>>>>> pm
		TimeBasicAtk -= Time.deltaTime;
		TimeTrap -= Time.deltaTime;
		TimeLightFeet -= Time.deltaTime;
		TimeReinforceArrow -= Time.deltaTime;
		if(LightFeetBuff && TimeLightFeet<=cdLightFeet/2){
			this.status.SetSpeed (1.5f);
			LightFeetBuff = false;
		}
<<<<<<< HEAD
=======

		if (h == 1) {
      		facingRight = true;
    	}
		
		if(h == -1){
      		facingRight = false;
    	}

>>>>>>> pm
	}

	//Metodo que implementa a habilidade reforçar flecha
	void ReinforceArrow(){

	}

	//Metodo que implementa o ataque com suas adagas
	void Trap(){
		temp = transform.position;
		if(!facingRight){
			temp.x -= 0.3f;
			Instantiate (trap, temp, transform.localRotation);
		}else if(facingRight){
			temp.x += 0.3f;
			Instantiate (trap, temp, transform.localRotation);
		}
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
			temp.x -= 0.3f;
			Instantiate (Arrow, temp, Quaternion.Euler (0, 0, 0));
		}else if(facingRight){
			temp.x += 0.3f;
			Instantiate (Arrow, temp, Quaternion.Euler (0, 0, 180));
		}
	}
}
