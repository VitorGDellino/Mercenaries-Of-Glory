using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Character {

    private float cdBasicAtk;
	private float cdBlizzard;		//Cooldown da habilidade Nevasca
	private float cdThunder;		//Cooldown da habilidade Trovão
	private float cdBarrier;		//Cooldown da habilidade Barreira


    public Wizard(string name, Status status, Weapon weapon, Armor armor)
        : base(name, status, weapon, armor){
    }
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

    public float GetCdBasicAtk() { return this.cdBasicAtk; }
    public float GetCdBlizzard() { return this.cdBlizzard; }
    public float GetCdThunder() { return this.cdThunder; }
    public float GetCdBarrier() { return this.cdBarrier; }

    public void SetCdBasicAtk(float cdBasicAtk) { this.cdBasicAtk = cdBasicAtk; }
    public void SetCdBlizzard(float cdBlizzard) { this.cdBlizzard = cdBlizzard; }
    public void SetCdThunder(float cdThunder) { this.cdThunder = cdThunder; }
    public void SetCdBarrier(float cdBarrier) { this.cdBarrier = cdBarrier; }


}
