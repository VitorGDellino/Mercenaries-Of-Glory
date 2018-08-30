using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : Player {

	private double reinforcearrowcd;	//Cooldown da habilidade Reforçar flecha
	private double lightfeetcd;		//Cooldown da habilidade Pés leves

	// Use this for initialization
	void Start () {
		this.rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		this.Movement();
	}

	//Metodo que implementa a habilidade reforçar flecha
	void ReinforceArrow(){

	}

	//Metodo que implementa o ataque com suas adagas
	void TwoDaggersAtk(){

	}

	//Metodo que implementa a habilidade aumentar velocidade
	void LightFeet(){

	}

	//Metodo que implementa o ataque básico da arqueira
	void BasicAtk(){

	}
}
