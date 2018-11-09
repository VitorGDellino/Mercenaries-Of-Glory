using System.Collections;
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
    public GameObject KaHal;

	private Vector3 temp;

    public AudioClip shootSound;
    private AudioSource source;

	private SpriteRenderer charSprite;

	float h;

	private int hp;

    public Ranger(string name, Status status, Weapon weapon, Armor armor)
        : base(name, status, weapon, armor){
    }
    // Use this for initialization

	void Awake(){
		this.hp = 50;
		hitted = 0;
		this.status = new Status(50, 10, 10, 3f, 10.0f);
		this.weapon = new Weapon("Long Sword", 5, "Melee", "A common sword", 4);
		this.armor = new Armor("Chain Mail", 5, "Hard Armor", "Heavy armor, but powerful", 4);
		this.totalAtk = this.weapon.GetAtk() + this.status.GetAtk();
		this.totalDef = this.armor.GetDef() + this.status.GetDef();

		inputGamepad = this.GetComponent<PlayerInput>();

		source = GetComponent<AudioSource>();
	}
	void Start () {

		charSprite =  gameObject.GetComponent<SpriteRenderer>();
		this.rb = GetComponent<Rigidbody2D>();
		this.sprite = GetComponentInChildren<SpriteRenderer>();
		this.t = GetComponent<Transform>();
		this.anim = GetComponent<Animator>();

		// Animacoes

		jumping = jumpCheckpoint = attacking = false;
		anim.SetBool("win", false);

		anC = anim.runtimeAnimatorController;

		facingRight = true;

		cdBasicAtk = 1.0f;
		cdTrap = 5.0f;
		cdReinforceArrow = 5.0f;	//Cooldown da habilidade Reforçar flecha
		cdLightFeet = 10.0f;

		LightFeetBuff = false;

		TimeBasicAtk = 0.0f;
		Time1 = TimeTrap = 0.0f;
		//Time2 = TimeReinforceArrow = 0.0f;
		Time2 = TimeLightFeet = 0.0f;

		tempoStun = 0.0f;
		RespawnTime = 10.0f;

		setDirection(1);
		
        KaHal = GameObject.Find("KaHal");

	}

	void Update(){
		if(hitted > 0){
			charSprite.color = Color.red;
			hitted--;
		}else{
			charSprite.color = Color.white;
			hitted = 0;
		}		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(tempoStun<=0.0f && !status.IsDead()){
			this.Movement();


			if(inputGamepad.GetAttack() && TimeBasicAtk <= 0){
				TimeBasicAtk = cdBasicAtk;
				BasicAtk ();
			}

			if(inputGamepad.GetSkill1() && TimeTrap <= 0){
				TimeTrap = cdTrap;
				Trap ();
			}

			if(inputGamepad.GetSkill3() && TimeLightFeet <= 0){
				TimeLightFeet = cdLightFeet;
				LightFeet ();
			}

			/*if(inputGamepad.GetSkill3() && TimeReinforceArrow <= 0){
				TimeReinforceArrow = cdReinforceArrow;
				ReinforceArrow ();
			}*/
		}
		
		if (Input.GetAxisRaw ("Horizontal") > 0) {
			facingRight = true;
		}if(Input.GetAxisRaw ("Horizontal") < 0){
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
			//myAnimation["Archer_Running"].speed = 7; // <---- light feet animation
			this.status.SetSpeed (3f);
			LightFeetBuff = false;
		}

		if(invincibleTime<0.0f)
			invincible = false;

		if(cdRespawn<0.0f && status.IsDead()){
			status.SetHp(this.hp);
			this.t.position = new Vector3(Random.Range(-3.0f, 10.0f), 0.0f, -0.05448645f);
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
            
		}

		if(cdRespawn < 0){
            cdRespawn = 0;
        }

		if(KaHal.GetComponent<Enemy>().status.GetHp()<=0){
			anim.SetBool("win", true);
		}

		tempoStun -= Time.deltaTime;
		invincibleTime -= Time.deltaTime;
		cdRespawn -= Time.deltaTime;

		Time1 = TimeTrap;
		Time2 = TimeLightFeet;
		//Time3 = TimeReinforceArrow;

		updateAnimation();
	}

	//Metodo que implementa a habilidade reforçar flecha
	void ReinforceArrow(){

	}

	//Metodo que implementa o ataque com suas adagas
	void Trap(){
		temp = transform.position;
		temp.y += 0.3f;
		if(this.getDirection() == -1){
			temp.x -= 0.8f;
			clone = Instantiate (trap, temp, transform.localRotation);
		}else if(this.getDirection() == 1){
			temp.x += 0.8f;
			clone = Instantiate (trap, temp, transform.localRotation);
		}
		clone.tag = gameObject.tag;
	}

	//Metodo que implementa a habilidade aumentar velocidade
	void LightFeet(){
		//myAnimation["Archer_Running"].speed = 10; // <---- light feet animation
		this.status.SetSpeed (5.0f);
		LightFeetBuff = true;
	}

	//Metodo que implementa o ataque básico da arqueira
	void BasicAtk(){
		attacking = true;
		anim.SetBool("attacking", true);
		Invoke("stopShootingAnimation", getClipTime("Archer_Shooting"));
		Invoke("ArrowInstantiate", getClipTime("Archer_Shooting") - 0.25f);
		source.clip = shootSound;
		source.PlayOneShot(shootSound, 0.7f);
		//ArrowInstantiate();
	}

	void ArrowInstantiate(){
		temp = transform.position;
		temp.y += 0.4f;
		if(this.getDirection() == -1){
			temp.x -= 0.5f;
			clone = Instantiate (Arrow, temp, Quaternion.Euler (0, 0, 0));
		}else if(this.getDirection() == 1){
			temp.x += 0.5f;
			clone = Instantiate (Arrow, temp, Quaternion.Euler (0, 0, 180));
		}
		clone.tag = gameObject.tag;
	}

}
