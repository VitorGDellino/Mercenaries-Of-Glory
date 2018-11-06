using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character{

    private float cdBasicAtk;
    private float cdScream;
    private float cdSmash;
    private float cdGale;

    private bool ScreamBuff;
    private bool screaming;


    private float timeBasicAtk;
    private float timeSmash;
    private float timeScream;
    private float timeGale;


    public Collider2D attack;
    public Collider2D smash;
    public Collider2D gale;

    public GameObject attackObject;
    public GameObject sharpGale;
    public GameObject clone;


    public Warrior(string name, Status status, Weapon weapon, Armor armor)
        : base(name, status, weapon, armor){
    }

    void Awake(){
        this.status = new Status(10, 10, 10, 3f, 10.0f);
		this.weapon = new Weapon("Long Sword", 5, "Melee", "A common sword", 4);
		this.armor = new Armor("Chain Mail", 5, "Hard Armor", "Heavy armor, but powerful", 4);
		this.totalAtk = this.weapon.GetAtk() + this.status.GetAtk();
		this.totalDef = this.armor.GetDef() + this.status.GetDef();
        attack.enabled = false;
        smash.enabled = false;
        gale.enabled = false;

        inputGamepad = this.GetComponent<PlayerInput>();

    }

    void Start(){
        cdBasicAtk = 1.0f;
        cdSmash = 5.0f;
        cdScream = 10.0f;
        cdGale = 15.0f;

        ScreamBuff = false;
        screaming = false;

        timeBasicAtk = 0.0f;
        //Time1 = timeSmash = 0.0f;
        Time1 = timeScream = 0.0f;
        Time2 = timeGale = 0.0f;

        setDirection(1);
        
		tempoStun = 0.0f;

		RespawnTime = 10.0f;

        this.rb = GetComponent<Rigidbody2D>();
        this.sprite = GetComponent<SpriteRenderer>();
        this.t = GetComponent<Transform>();

        attackObject.tag = gameObject.tag;
    }

    void Update(){
        //InputManager.prevState = InputManager.state;
        if(!screaming && tempoStun<=0.0f && !status.IsDead()){
            this.Movement();

            if(inputGamepad.GetAttack() && timeBasicAtk <= 0){
                timeBasicAtk = cdBasicAtk;
                BasicAtk();
            }

            if(inputGamepad.GetSkill1() && timeSmash <= 0){
                timeSmash = cdSmash;
                Smash();
            }

            if(inputGamepad.GetSkill2()  && timeScream <= 0){
                timeScream = cdScream;
                Scream();
            }

            if(inputGamepad.GetSkill3() && timeGale <= 0){
                timeGale = cdGale;
                Gale();
            }
        }
        

        timeBasicAtk -= Time.deltaTime;
        timeSmash -= Time.deltaTime;
        timeScream -= Time.deltaTime;
        timeGale -= Time.deltaTime;

        if(timeSmash <= 0){
            timeSmash = 0;
        }

        if(timeScream <= 0){
            timeScream = 0;
        }

        if(timeGale <= 0){
            timeGale = 0;
        }

        if(timeBasicAtk <= 0.5f){
            attack.enabled = false;
        }

        if(timeSmash <= 4.5f){
            smash.enabled = false;
        }

        if(timeScream <= 8.5f){
            screaming = false;
        }

        if(timeScream <= 5.0f && ScreamBuff){
            setAtk(getAtk() - 15);
            ScreamBuff = false;
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

        //Time1 = timeSmash;
		Time1 = timeScream;
		Time2 = timeGale;

    }

    void BasicAtk(){
        attack.enabled = true;

        timeBasicAtk = cdBasicAtk;
    }                                                                                                                                                                                                                                                                                                                                                                                                                           

    void Smash(){
        smash.enabled = true;
        timeSmash = cdSmash;
    }

    void Scream(){
        screaming = true;
        ScreamBuff = true;
        setAtk(getAtk() + 15);
    }

    void Gale(){
        Vector3 temp = transform.position;
        if(getDirection() == 1){
            temp.x += 0.4f;
            clone = Instantiate(sharpGale, temp, Quaternion.Euler (0, 0, 0));
        }else if(getDirection() == -1){
            temp.x -= 0.4f;
            clone = Instantiate(sharpGale, temp, Quaternion.Euler (0, 0, 180));
        }
        clone.tag = gameObject.tag;
    }

}