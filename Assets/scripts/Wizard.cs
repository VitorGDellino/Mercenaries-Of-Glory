using System.Collections;
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

	public GameObject blizzard;

	public Collider2D player;

	public GameObject fireBall;
	public GameObject clone;


    public Wizard(string name, Status status, Weapon weapon, Armor armor)
        : base(name, status, weapon, armor){
    }

	void Awake(){
		this.status = new Status(10, 10, 10, 3f, 10.0f);
		this.weapon = new Weapon("Long Sword", 5, "Melee", "A common sword", 4);
		this.armor = new Armor("Chain Mail", 5, "Hard Armor", "Heavy armor, but powerful", 4);
		this.totalAtk = this.weapon.GetAtk() + this.status.GetAtk();
		this.totalDef = this.armor.GetDef() + this.status.GetDef();
		blizzard.SetActive(false);

		inputGamepad = this.GetComponent<PlayerInput>();
	}
    // Use this for initialization
    void Start () {
		this.rb = GetComponent<Rigidbody2D>();
        this.sprite = GetComponent<SpriteRenderer>();
        this.t = GetComponent<Transform>();
		this.anim = GetComponent<Animator>();


		jumping = jumpCheckpoint = attacking = false;

		anC = anim.runtimeAnimatorController;

		cdBasicAtk = 1.0f;
		cdBarrier = 15.0f;
		cdBlizzard = 10.0f;

		timeBasicAtk = 0.0f;
		Time1 = timeBarrier = 0.0f;
        //Time2 = timeThunder = 0.0f;
        Time2 = timeBlizzard = 0.0f;

		barrier = false;

		setDirection(1);

		tempoStun = 0.0f;

		RespawnTime = 10.0f;

        
		blizzard = t.Find("Blizzard").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(tempoStun<=0.0f && !status.IsDead()){
			this.Movement();

			if(inputGamepad.GetAttack() && timeBasicAtk <= 0){
				timeBasicAtk = cdBasicAtk;
				BasicAtk();
			}

			if(inputGamepad.GetSkill1() && timeBarrier <= 0){
				timeBarrier = cdBarrier;
				Barrier();
			}

			if(inputGamepad.GetSkill3() && timeBlizzard <= 0){
				timeBlizzard = cdBlizzard;
				Blizzard();
			}
		}

		timeBasicAtk -= Time.deltaTime;
		timeBlizzard -= Time.deltaTime;

		if(!barrier){
			timeBarrier -= Time.deltaTime;
		}

		if(timeBarrier <= 0) timeBarrier = 0;
		if(timeThunder <= 0) timeThunder = 0;
		if(timeBlizzard <= 0) timeBlizzard = 0;

		if(timeBlizzard <= cdBlizzard/2.0f){
			blizzard.SetActive(false);
		}

		if(invincibleTime<0.0f)
			invincible = false;

		if(cdRespawn<0.0f && status.IsDead()){
			status.SetHp(10);
			this.t.position = new Vector3(Random.Range(-3.0f, 10.0f), 0.0f, -0.05448645f);
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
            
		}

		tempoStun -= Time.deltaTime;
		invincibleTime -= Time.deltaTime;
		cdRespawn -= Time.deltaTime;

		Time1 = timeBarrier;
		//Time2 = timeThunder;
		Time2 = timeBlizzard;
	}

	//Metodo que implementa a habilidade Nevasca
	void Blizzard(){
		timeBlizzard = cdBlizzard;
		blizzard.tag = gameObject.tag;
		blizzard.SetActive(true);
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
            clone = Instantiate(fireBall, temp, Quaternion.Euler (0, 0, 0));
        }else if(getDirection() == -1){
            temp.x -= 0.4f;
            clone = Instantiate(fireBall, temp, Quaternion.Euler (0, 0, 180));
        }
		clone.tag = gameObject.tag;
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
		if(!barrier && !invincible && !status.IsDead()){
			SetHp(GetHp()-damage);
            if(GetHp()<=0){
                this.t.position = new Vector3(Random.Range(-3.0f, 10.0f), -4.0f, 0.0f);
                cdRespawn = RespawnTime;
            }
            //Debug.Log(damage);
            invincible = true;
            invincibleTime = 0.5f;
		}
		
		barrier = false;
	}
}
