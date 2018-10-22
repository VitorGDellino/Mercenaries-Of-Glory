using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guerreiro : Character{

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

    public GameObject sharpGale;

    public Guerreiro(string name, Status status, Weapon weapon, Armor armor)
        : base(name, status, weapon, armor){
    }

    void Awake(){
        attack.enabled = false;
        smash.enabled = false;
        gale.enabled = false;

    }

    void Start(){
        cdBasicAtk = 1.0f;
        cdSmash = 5.0f;
        cdScream = 10.0f;
        cdGale = 15.0f;

        ScreamBuff = false;
        screaming = false;

        timeBasicAtk = 0.0f;
        timeSmash = 0.0f;
        timeScream = 0.0f;
        timeGale = 0.0f;

        setDirection(1);

        this.status = new Status(10, 10, 10, 1.5f, 10.0f);
		this.weapon = new Weapon("Long Sword", 5, "Melee", "A common sword", 4);
		this.armor = new Armor("Chain Mail", 5, "Hard Armor", "Heavy armor, but powerful", 4);
		this.totalAtk = this.weapon.GetAtk() + this.status.GetAtk();
		this.totalDef = this.armor.GetDef() + this.status.GetDef();

        this.rb = GetComponent<Rigidbody2D>();
        this.sprite = GetComponent<SpriteRenderer>();
        this.t = GetComponent<Transform>();

    }

    void Update(){
        if(!screaming){
            this.Movement();

            if(Input.GetKey(KeyCode.Q) && timeBasicAtk <= 0){
                timeBasicAtk = cdBasicAtk;
                BasicAtk();
            }

            if(Input.GetKey(KeyCode.W) && timeSmash <= 0){
                timeSmash = cdSmash;
                Smash();
            }

            if(Input.GetKey(KeyCode.E)  && timeScream <= 0){
                timeScream = cdScream;
                Scream();
            }

            if(Input.GetKey(KeyCode.R)  && timeGale <= 0){
                timeGale = cdGale;
                Gale();
            }
        }
        

        timeBasicAtk -= Time.deltaTime;
        timeSmash -= Time.deltaTime;
        timeScream -= Time.deltaTime;
        timeGale -= Time.deltaTime;

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
            Instantiate(sharpGale, temp, Quaternion.Euler (0, 0, 0));
        }else if(getDirection() == -1){
            temp.x -= 0.4f;
            Instantiate(sharpGale, temp, Quaternion.Euler (0, 0, 180));
        }
    }
}