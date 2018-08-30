using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Player {

	private double smashcd;			//Cooldown da habilidade Esmagar
	private double warscreamcd;		//Cooldown da habilidade Grito de Guerra
	private double galecd;		//Cooldown da habilidade Ventania Cortante

	// Use this for initialization
	void Start () {
		this.rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		this.Movement();
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


}
