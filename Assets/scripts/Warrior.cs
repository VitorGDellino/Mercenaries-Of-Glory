using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character {

    private float cdBasicAtk;
	private float cdSmash;			//Cooldown da habilidade Esmagar
	private float cdWarScream;		//Cooldown da habilidade Grito de Guerra
	private float cdGale;		//Cooldown da habilidade Ventania Cortante
    

    public Warrior(string name, Status status, Weapon weapon, Armor armor) 
        : base(name, status, weapon, armor){
    }

	// Use this for initialization
	void Start () {
        this.status = new Status(10, 10, 10, 1.5f, 10.0f);
        this.weapon = new Weapon("Long Sword", 5, "Melee", "A common sword", 4);
        this.armor = new Armor("Chain Mail", 5, "Hard Armor", "Heavy armor, but powerful", 4);
        this.totalAtk = this.weapon.GetAtk() + this.status.GetAtk();
        this.totalDef = this.armor.GetDef() + this.status.GetDef();
 
		this.rb = GetComponent<Rigidbody2D>();
        this.sprite = GetComponentInChildren<SpriteRenderer>();
        this.anim = GetComponent<Animator>();
	}

    void Update(){
        this.anim.SetBool("Grounded", this.onthefloor);
        this.anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        this.Movement();
        
    }
    void FixedUpdate(){
        
    }

    //Metodo que implementa a habilidade Esmagar
    void Smash(){

	}

	//Metodo que implementa a habilidade Grito de Guerra
	void WarScream(){

	}

	//Metodo que implementa a habilidade Ventania Cortante
	void Gale(){

	}


	//Metodo que implementa o ataque básico do guerreiro
	void BasicAtk(){

	}

    public float GetCdBasicAtk() { return this.cdBasicAtk; }
    public float GetCdSmash() { return this.cdSmash; }
    public float GetCdWarScream() { return this.cdWarScream; }
    public float GetCdGale() { return this.cdGale; }

    public void SetCdBasicAtk(float cdBasicAtk) { this.cdBasicAtk = cdBasicAtk; }
    public void SetCdSmash(float cdSmash) { this.cdSmash = cdSmash; }
    public void SetCdWarScream(float cdWarScream) { this.cdWarScream = cdWarScream; }
    public void SetCdGale(float cdGale) { this.cdGale = cdGale; }


}
