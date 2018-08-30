using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	protected bool onthefloor;  //Indica se o personagem está ou nao sobr eo chão
	protected bool doublejump;  //Indica se o personagem pode ou nao realizar o pulo duplo
	protected bool candash;		//Indica se o personagem pode ou nao realizar um dash
	protected bool canairdash;	//Indica se o personagem pode ou nao realizar um dash aéreo
	protected bool isdead;		//Indica se o personagem está vivo ou morto
	protected Rigidbody2D rb;	//Referencia o Personagem
	

	protected int hp;			//HP do personagem
	protected int atk;			//Ataque do personagem
	protected int def;			//Defesa do personagem
	protected int magatk;		//Ataque mágico do personagem
	
	public float speed;			//Velocidade de movimento
	public float dashspeed;		//Velocidade do dash
	public float jumpstr;		//Força de salto
	public Transform FloorVerify;	//Componente que auxilia na verificação se a personagem está ou não sobre o chão
	public double dashcooldown = 2.0f;	//Cooldown do dash
	public double respawntime = 0.0f;

	protected void Movement(){

		this.onthefloor = Physics2D.Linecast(transform.position, FloorVerify.position, 1 << LayerMask.NameToLayer("Floor"));
		

		//Movimento para a direita
		if(Input.GetAxisRaw("Horizontal") > 0){
			transform.Translate(Vector2.right * this.speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0);
		}
		
		//Movimento para a esquerda
		if(Input.GetAxisRaw("Horizontal") < 0){
			transform.Translate(Vector2.right * this.speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,180);
		}
		
		//Salto e Salto duplo
		if(Input.GetButtonDown("Jump") && this.onthefloor){
			rb.velocity = new Vector2(rb.velocity.x, 0);
			rb.AddForce(new Vector2(0, jumpstr));
			this.doublejump = true;
			this.canairdash = true;
		}else if(Input.GetButtonDown("Jump") && this.doublejump){
			rb.velocity = new Vector2(rb.velocity.x, 0);
			rb.AddForce(new Vector2(0, jumpstr));
			this.doublejump = false;
		}

		//Dash e Dash aéreo
		if((Input.GetKeyDown(KeyCode.X) && this.candash) || (Input.GetKeyDown(KeyCode.X) && this.canairdash)){
			transform.Translate(Vector2.right * this.dashspeed * Time.deltaTime);
			rb.velocity = new Vector2(rb.velocity.x, 0);
			this.candash = false;
			this.canairdash = false;
		}

		//Finalizando o cooldown da habilidade de dash
		if(this.dashcooldown <= 0.0f && this.onthefloor){
			this.candash = true;
			this.dashcooldown = 2.0f;
		}

		//Atualiza cooldown do dash
		this.dashcooldown -= 0.1f;
	}

	//Setters
	public void setHP(int hp){ this.hp = hp; }
	public void setAtk(int atk){ this.atk = atk; }
	public void setDef(int def) { this.def = def; }
	public void setMagAtk(int magatk){ this.magatk = magatk; }

	//Getters
	public int getHp(){ return this.hp; }
	public int getAtk(){ return this.atk; }
	public int getDef(){ return this.def; }
	public int getMagAtk(){ return this.magatk; }

	//Método para auxiliar quando um personagem toma dano
	protected void takeDamage(int damage){
	
	}

	protected void YouDied(){
		if(this.hp <= 0){
			this.isdead = true;
			this.respawntime = 15.0f;
		}
	}
}
