using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Player {
	
	private double blizzardcd;		//Cooldown da habilidade Nevasca
	private double thundercd;		//Cooldown da habilidade Trovão
	private double barriercd;		//Cooldown da habilidade Barreira

	// Use this for initialization
	void Start () {
		this.rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		this.Movement();
	}

	//Metodo que implementa a habilidade Nevasca
	void Blizzard(){

	}

	//Metodo que implementa a habilidade Trovão
	void Thunder(){

	}

	//Metodo que implementa a habilidade Barreira
	void Barrier(){

	}

	//Metodo que implementa o ataque básico da arqueira
	void BasicAtk(){

	}
	
}
