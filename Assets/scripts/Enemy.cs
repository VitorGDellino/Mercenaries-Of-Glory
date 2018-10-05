<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    protected Status status;        //Status do personagem

	private float TimeEarthquake;
	private float TimeVulcan;
	private float TimeMeteor;
	private float TimeAcid;

	private float cdEarthquake;
	private float cdVulcan;
	private float cdMeteor;
	private float cdAcid;

	/*Terremotos de magnitude 10.666;	Porrada com as duas maos q treme o chao, dano e atordoa
	Erupções vulcânicas;		Sobe sobre o chão
	Meteoros do Apocalipse;		Cair meteoros aleatorios pelo mapa
	Chuva de Ácido Sulfúrico;	Cuspir acido, lentidao e dano	*/

	// Use this for initialization
	void Start () {
		this.status = new Status(300, 10, 10, 1.5f, 10.0f); //hp, attack, def, speed, respawn time
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log (h);

		if(Input.GetKey(KeyCode.Q) && TimeEarthquake <= 0){
			TimeEarthquake = cdEarthquake;
			Earthquake ();
		}

		if(Input.GetKey(KeyCode.W) && TimeVulcan <= 0){
			TimeVulcan = cdVulcan;
			Vulcan ();
		}

		if(Input.GetKey(KeyCode.E) && TimeMeteor <= 0){
			TimeMeteor = cdMeteor;
			Meteor ();
		}

		if(Input.GetKey(KeyCode.R) && TimeAcid <= 0){
			TimeAcid = cdAcid;
			Acid ();
		}

		TimeEarthquake -= Time.deltaTime;
		TimeVulcan -= Time.deltaTime;
		TimeMeteor -= Time.deltaTime;
		TimeAcid -= Time.deltaTime;
	}

	void Earthquake(){
		//Animacao das maos
		//
	}

	void Vulcan(){

	}

	void Meteor(){

	}

	void Acid(){
		
	}

	/*Terremotos de magnitude 10.666;	Porrada com as duas maos q treme o chao, dano e atordoa
	Erupções vulcânicas;		Sobe sobre o chão
	Meteoros do Apocalipse;		Cair meteoros aleatorios pelo mapa
	Chuva de Ácido Sulfúrico;	Cuspir acido, lentidao e dano	*/

	public void takeDamage(int damage){
        status.SetHp(status.GetHp()-damage);
        Debug.Log("Vida: " + status.GetHp());
	}

}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	// Use this for initialization
	void Start () {
		//this.status = new Status(10, 10, 10, 1.5f, 10.0f); //hp, attack, def, speed, respawn time
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
>>>>>>> acc70a96a27582c9545e3f7ec8eff68dded37726
