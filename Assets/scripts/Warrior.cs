using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character {

    private float cdBasicAtk;
    private bool attacking = false;

    private bool gale = false;

    private bool smashing = false;
    private float smashTime;

    private bool galedirection = false;
    private Vector2 galeColPosition;

    private Collider2D attackTriggerRight;
    private Collider2D attackTriggerLeft;
    private Collider2D galeLeft;
    private Collider2D galeRight;

    private Collider2D smashRight;
    private Collider2D smashLeft;

	private float cdSmash;          //Cooldown da habilidade Esmagar

    private float cdWarScream;		//Cooldown da habilidade Grito de Guerra
    private float warScreamTime;
    private bool screaming = false;
    private bool warScreamBonus = false;

    private float cdGale;		//Cooldown da habilidade Ventania Cortante
    

    public Warrior(string name, Status status, Weapon weapon, Armor armor) 
        : base(name, status, weapon, armor){
    }

    void Awake(){
        // Collider do ataque básico pela direita
        GameObject child = transform.Find("AttackTriggerRight").gameObject;
        this.attackTriggerRight = child.GetComponent<BoxCollider2D>();
        this.attackTriggerRight.enabled = false;

        // Collider do ataque básico pela esquerda
        child = transform.Find("AttackTriggerLeft").gameObject;
        this.attackTriggerLeft = child.GetComponent<BoxCollider2D>();
        this.attackTriggerLeft.enabled = false;

        // Collider da Ventania Cortante pela esquerda
        child = transform.Find("GaleLeft").gameObject;
        this.galeLeft = child.GetComponent<BoxCollider2D>();
        this.galeLeft.enabled = false;

        // Collider da Ventania Cortante pela direita
        child = transform.Find("GaleRight").gameObject;
        this.galeRight = child.GetComponent<BoxCollider2D>();
        this.galeRight.enabled = false;

        // Collider de Esmagar pela direita
        child = transform.Find("SmashRight").gameObject;
        this.smashRight = child.GetComponent<BoxCollider2D>();
        this.smashRight.enabled = false;

        // Collider de Esmagar pela esquerda
        child = transform.Find("SmashLeft").gameObject;
        this.smashLeft = child.GetComponent<BoxCollider2D>();
        this.smashLeft.enabled = false;

        // Movimentção basica
		this.rb = GetComponent<Rigidbody2D>();
        this.sprite = GetComponentInChildren<SpriteRenderer>();
        this.anim = GetComponent<Animator>();

    }

    // Use this for initialization
    void Start () {
        this.status = new Status(10, 10, 10, 1.5f, 10.0f);
        this.weapon = new Weapon("Long Sword", 5, "Melee", "A common sword", 4);
        this.armor = new Armor("Chain Mail", 5, "Hard Armor", "Heavy armor, but powerful", 4);
        this.totalAtk = this.weapon.GetAtk() + this.status.GetAtk();
        this.totalDef = this.armor.GetDef() + this.status.GetDef();

        // Ataque Básico
        this.cdBasicAtk = 0.0f;
        this.cdWarScream = 0.0f;
        this.warScreamTime = 5.0f;
        this.cdGale = 0.0f;
        
	}

    void Update(){
        this.anim.SetBool("Grounded", this.onthefloor);
        this.anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        this.anim.SetBool("Attacking", this.attacking);
        
        if (!this.screaming) {
            this.Movement();
            this.BasicAtk();
        }

        this.WarScream();
        this.Gale();
        this.Smash();
        
    }

    void FixedUpdate(){
        
    }

    //Metodo que implementa a habilidade Esmagar
    void Smash(){
        if (Input.GetKeyDown(KeyCode.V) && this.cdSmash <= 0.0f && !this.smashing) {
            this.cdSmash = 5.0f;
            this.smashTime = 0.1f;
            this.smashing = true;
            if(this.getDirection() == 1){
                this.smashRight.enabled = true;
            }else if(this.getDirection() == -1){
                this.smashLeft.enabled = true;
            }     
        }

        if (this.smashing) {
            // Debug.Log("SMASHING");
            if (this.smashTime > 0.0f) {
                this.smashTime -= 0.1f;
            }else{
                // Debug.Log("STOP SMASHING");
                this.smashRight.enabled = false;
                this.smashLeft.enabled = false;
                this.smashing = false;
            }
        }

        if(this.cdSmash <= 5.0f){
            this.cdSmash -= 0.1f;
        }
	}

	//Metodo que implementa a habilidade Grito de Guerra
	void WarScream(){
        if (Input.GetKeyDown(KeyCode.G) && this.cdWarScream <= 0){
            this.cdWarScream = 10.0f;
            this.warScreamTime = 5.0f;
            this.screaming = true;
            this.totalAtk += 5;
            this.rb.velocity = new Vector2(this.rb.velocity.x, 0);
            this.warScreamBonus = true;
        }

        if (this.screaming) {
            this.cdWarScream -= 0.1f;
           /* 
            Apenas para DEBUG
            Debug.Log("CD WAR SCREAM");
            Debug.Log(this.cdWarScream);
            Debug.Log("ATTACK");
            Debug.Log(this.totalAtk);
            Debug.Log("BONUS TIME");
            Debug.Log(this.warScreamTime);
            Debug.Log("BONUS");
            Debug.Log(this.warScreamBonus);*/
            
        }

        // Habilidade já disponivel para usar
        if (this.cdWarScream <= 0){
            this.screaming = false;
        }


        // Tempo que o Buff fica ativo
        if (this.warScreamBonus){
            this.warScreamTime -= 0.1f;
        }

        // Bonus terminado
        if (this.warScreamTime <= 0) {
            this.warScreamBonus = false;
            this.warScreamTime = 5.0f;
            this.totalAtk -= 5;
            Debug.Log("FINISHED");
            Debug.Log(this.totalAtk);
        }

	}

	//Metodo que implementa a habilidade Ventania Cortante
	void Gale(){
        if(Input.GetKeyDown(KeyCode.C) && this.cdGale <= 0.0f){
            // Debug.Log("GALEEEE");
            this.cdGale = 5.0f;
            this.gale = true;
            if(this.getDirection() == 1){
                this.galedirection = true;
                this.galeColPosition = this.galeRight.offset;
                this.galeRight.enabled = true;
            }else if(this.getDirection() == -1){
                this.galeColPosition = this.galeLeft.offset;
                this.galedirection = false;
                this.galeLeft.enabled = true;
            }
        }

        if(this.cdGale <= 5.0f){
            this.cdGale -= 0.1f;
            // Debug.Log(this.cdGale);
        }


        if(this.gale){
            if(this.galedirection){
                this.galeRight.offset = new Vector2(this.galeRight.offset[0] + 0.1f, this.galeRight.offset[1]);
                if(this.galeRight.offset[0] >= this.galeColPosition[0] + 2.0f){
                    this.gale = false;
                    this.galeRight.enabled = false;
                    this.galeRight.offset = this.galeColPosition;
                }
            }else{
                this.galeLeft.offset = new Vector2(this.galeLeft.offset[0] - 0.1f, this.galeLeft.offset[1]);
                if(this.galeLeft.offset[0] <= this.galeColPosition[0] - 2.0f){
                    this.gale = false;
                    this.galeLeft.enabled = false;
                    this.galeLeft.offset = this.galeColPosition;
                }
            }
        }
	}


	//Metodo que implementa o ataque básico do guerreiro
	void BasicAtk(){
        if (Input.GetKeyDown(KeyCode.F) && !this.attacking) {
            this.attacking = true;
            this.cdBasicAtk = 0.1f;
            if(this.getDirection() == 1){
                this.attackTriggerRight.enabled = true;
            }else if(this.getDirection() == -1){
                this.attackTriggerLeft.enabled = true;
            }     
        }

        if (this.attacking) {
            if (this.cdBasicAtk > 0) {
                this.cdBasicAtk -= 0.1f;
            }else{
                this.attackTriggerRight.enabled = false;
                this.attackTriggerLeft.enabled = false;
                this.attacking = false;
            }
        }
	}

    public float GetCdBasicAtk() { return this.cdBasicAtk; }
    public float GetCdSmash() { return this.cdSmash; }
    public float GetCdWarScream() { return this.cdWarScream; }
    public float GetCdGale() { return this.cdGale; }

    public void SetCdBasicAtk(float cdBasicAtk) { this.cdBasicAtk = cdBasicAtk; }
    public void SetCdSmash(float cdSmash) { this.cdSmash = cdSmash; }
    public void SetCdWarScream(float cdWarScream) { this.cdWarScream = cdWarScream; }
    public void SetCdGale(float cdGale) { this.cdGale = cdGale; }


}
