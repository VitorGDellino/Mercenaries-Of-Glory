using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonecoTeste : Character {

	public BonecoTeste(string name, Status status, Weapon weapon, Armor armor)
        : base(name, status, weapon, armor){
    }

	// Use this for initialization
	void Start () {
		this.status = new Status(100, 10, 10, 1.5f, 10.0f);		//hp, atk, def, speed, respawnTime
		this.weapon = new Weapon("Long Sword", 5, "Melee", "A common sword", 4);
		this.armor = new Armor("Chain Mail", 5, "Hard Armor", "Heavy armor, but powerful", 4);
		this.totalAtk = this.weapon.GetAtk() + this.status.GetAtk();
		this.totalDef = this.armor.GetDef() + this.status.GetDef();

		this.rb = GetComponent<Rigidbody2D>();
		this.sprite = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
