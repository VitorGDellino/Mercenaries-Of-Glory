﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Character {

    private float cdBasicAtk;
	private float cdBlizzard;		//Cooldown da habilidade Nevasca
	private float cdThunder;		//Cooldown da habilidade Trovão
	private float cdBarrier;		//Cooldown da habilidade Barreira

	private float timeBasicAtk;
	private float timeBlizzard;
	private float timeThunder;
	private float timeBarrier;

	private bool barrier;

	public Collider2D blizzard;
	public Collider2D player;

	public GameObject fireBall;


    public Wizard(string name, Status status, Weapon weapon, Armor armor)
        : base(name, status, weapon, armor){
    }

	void Awake(){
		blizzard.enabled = false;
	}
    // Use this for initialization
    void Start () {
		cdBasicAtk = 1.0f;
		cdBarrier = 15.0f;
		cdBlizzard = 30.0f;

		timeBasicAtk = 0.0f;

		barrier = false;

		setDirection(1);

        this.status = new Status(10, 10, 10, 1.5f, 10.0f);
		this.weapon = new Weapon("Long Sword", 5, "Melee", "A common sword", 4);
		this.armor = new Armor("Chain Mail", 5, "Hard Armor", "Heavy armor, but powerful", 4);
		this.totalAtk = this.weapon.GetAtk() + this.status.GetAtk();
		this.totalDef = this.armor.GetDef() + this.status.GetDef();

        this.rb = GetComponent<Rigidbody2D>();
        this.sprite = GetComponent<SpriteRenderer>();
        this.t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		this.Movement();

		if(Input.GetKey(KeyCode.Q) && timeBasicAtk <= 0){
            timeBasicAtk = cdBasicAtk;
            BasicAtk();
        }

		if(Input.GetKey(KeyCode.W) && timeBarrier <= 0){
			timeBarrier = cdBarrier;
			Barrier();
		}

		if(Input.GetKey(KeyCode.R) && timeBlizzard <= 0){
			timeBlizzard = cdBlizzard;
			Blizzard();
		}

		timeBasicAtk -= Time.deltaTime;
		timeBlizzard -= Time.deltaTime;

		if(!barrier){
			timeBarrier -= Time.deltaTime;
		}

		if(timeBlizzard <= 18.0f){
			blizzard.enabled = false;
		}
	}

	//Metodo que implementa a habilidade Nevasca
	void Blizzard(){
		timeBlizzard = cdBlizzard;
		blizzard.enabled = true;
	}

	//Metodo que implementa a habilidade Trovão
	void Thunder(){

	}

	//Metodo que implementa a habilidade Barreira
	void Barrier(){
		timeBarrier = cdBarrier;
		barrier = true;
	}

	//Metodo que implementa o ataque básico da arqueira
	void BasicAtk(){
		Vector3 temp = transform.position;
		if(getDirection() == 1){
            temp.x += 0.4f;
            Instantiate(fireBall, temp, Quaternion.Euler (0, 0, 0));
        }else if(getDirection() == -1){
            temp.x -= 0.4f;
            Instantiate(fireBall, temp, Quaternion.Euler (0, 0, 180));
        }
	}

    public float GetCdBasicAtk() { return this.cdBasicAtk; }
    public float GetCdBlizzard() { return this.cdBlizzard; }
    public float GetCdThunder() { return this.cdThunder; }
    public float GetCdBarrier() { return this.cdBarrier; }

    public void SetCdBasicAtk(float cdBasicAtk) { this.cdBasicAtk = cdBasicAtk; }
    public void SetCdBlizzard(float cdBlizzard) { this.cdBlizzard = cdBlizzard; }
    public void SetCdThunder(float cdThunder) { this.cdThunder = cdThunder; }
    public void SetCdBarrier(float cdBarrier) { this.cdBarrier = cdBarrier; }

	public override void takeDamage(int damage){
		if(!barrier){
			//take damage
		}
		
		barrier = false;
	}

}
