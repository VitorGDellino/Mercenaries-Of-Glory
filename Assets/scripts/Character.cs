using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour{
    // Atributos e Equipamentos
    protected string name;          //Nome do Personagem
    protected int totalAtk;         //Ataque total do personagem
    protected int totalDef;			//Defesa total do personagem
    protected Status status;        //Status do personagem
    protected Weapon weapon;        //Arma do personagem
    protected Armor armor;          //Armadura do personagem

    protected Rigidbody2D rb;   //Referencia o Personagem
    protected SpriteRenderer sprite;
    protected Transform t;
    public Transform GroundCheck;
    protected Animator anim;

    // Auxiliam na movimentação
    protected bool onthefloor;  //Indica se o personagem está ou nao sobr eo chão
	protected bool doublejump;  //Indica se o personagem pode ou nao realizar o pulo duplo
	protected bool candash;		//Indica se o personagem pode ou nao realizar um dash
	protected bool canairdash;	//Indica se o personagem pode ou nao realizar um dash aéreo

	public float dashspeed;		//Velocidade do dash
    private bool dashing;
    private int direction;
    public float dashTime;
    public float tempoStun;
    public bool invincible = false;
    public float invincibleTime = 0.0f;

	public float jumpstr;		//Força de salto
	public float dashcooldown = 5.0f;	//Cooldown do dash

    public PlayerInput inputGamepad;
   
    // Cd generico

    protected float Time1;
    protected float Time2;
    protected float Time3;

    public Character(string name, Status status, Weapon weapon, Armor armor) {
        this.name = name;
        this.totalAtk = status.GetAtk() + weapon.GetAtk();
        this.totalDef = status.GetDef() + armor.GetDef();
        this.weapon = weapon;
        this.armor = armor;
        this.status = status;
    }

    private void HorizontalMove(){
        float move = inputGamepad.GetHorizontal();
        Vector3 temp;
        if (move < -0.1f && this.direction == 1){
            temp = this.t.localScale;
            temp[0] = temp[0]*(-1);
            this.t.localScale = temp;
            //this.sprite.flipX = true;
            this.direction = -1;
        } else if (move > 0.1f && this.direction == -1){
            temp = this.t.localScale;
            temp[0] = temp[0]*(-1);
            this.t.localScale = temp;
           // this.sprite.flipX = false;
            this.direction = 1;
        }

        if (move != 0){
            this.rb.velocity = new Vector2(move * this.status.GetSpeed(), this.rb.velocity.y);
        }
    }

    private void DashMove() {
        //Dash e Dash aéreo
        if(inputGamepad.GetDash()){
            if(this.candash || this.canairdash){
                this.rb.velocity = new Vector2(this.dashspeed * this.direction, 0);
                this.dashing = true;
                this.dashTime = 1.0f;
                this.candash = false;
                this.canairdash = false;
            }
        }

        //Finalizando o cooldown da habilidade de dash
        if (this.dashcooldown <= 0.0f && this.onthefloor){
            this.candash = true;
            this.dashcooldown = 5.0f;
        }

        //Atualiza cooldown do dash
        this.dashcooldown -= 0.1f;
    }

    private void JumpMove(){
        if(inputGamepad.GetJump()){
            if(onthefloor){
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, jumpstr));
                this.doublejump = true;
                this.canairdash = true;
            }else if(doublejump){
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, jumpstr));
                this.doublejump = false;
            }
        }
    }

	protected void Movement(){
        if (this.dashing){
            this.rb.gravityScale = 0;
            this.rb.velocity = new Vector2(this.rb.velocity.x, 0);
        }else {
            this.rb.gravityScale = 1;
            this.HorizontalMove();
            this.DashMove();
            this.JumpMove();
        }
        if (this.dashTime <= 0) this.dashing = false;
        this.dashTime -= 0.05f;
     
	}

	public void setAtk(int atk){ this.totalAtk = atk; }
	public void setDef(int def) { this.totalDef = def; }
    public void setOnTheFloor(bool onTheFloor) { this.onthefloor = onTheFloor;  }

    public void EquipWeapon(Weapon weapon){
        this.weapon = weapon;
    }

    public void EquipArmor(Armor armor){
        this.armor = armor;
    }

    //Getters
    public int getAtk(){ return this.totalAtk; }
	public int getDef(){ return this.totalDef; }
    public int getDirection(){ return this.direction; }
    public bool getOnTheFloor(){ return this.onthefloor; }

    public void setDirection(int direction){ this.direction =  direction; }

    //Método para auxiliar quando um personagem toma dano
    public virtual void takeDamage(int damage){
        if(!invincible){
            SetHp(GetHp()-damage);
            //Debug.Log(damage);
            invincible = true;
            invincibleTime = 0.5f;
        }
	}

    public virtual void takeStun(int time){
        tempoStun = time;
        //Debug.Log(tempoStun);
	}

    public int GetHp(){
        return this.status.GetHp();
    }

    public void SetHp(int hp){
        this.status.SetHp(hp);
    }

    public void SetDoubleJump(){
        this.doublejump = true;
    }

    public float GetCd1(){ return this.Time1; }
    public float GetCd2(){ return this.Time2; }
    public float GetCd3(){ return this.Time3; }
}
