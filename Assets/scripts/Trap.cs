using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	public int damage = 5;
	public float stun = 2.0f;

	private Transform myTransform;
    public InfAtk atkInfo;

	public AudioClip closingTrap;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        atkInfo = new InfAtk(damage, gameObject.tag);
	}

	void Awake(){
		source = GetComponent<AudioSource>();
		source.clip = closingTrap;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("Player1")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			col.gameObject.SendMessageUpwards("takeStun", this.stun);
			source.PlayOneShot(closingTrap, 0.7f);
		}
		if(col.gameObject.CompareTag("Player2")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			col.gameObject.SendMessageUpwards("takeStun", this.stun);
			source.PlayOneShot(closingTrap, 0.7f);
		}
		if(col.gameObject.CompareTag("Player3")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			col.gameObject.SendMessageUpwards("takeStun", this.stun);
			source.PlayOneShot(closingTrap, 0.7f);
		}
		if(col.gameObject.CompareTag("Player4")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			col.gameObject.SendMessageUpwards("takeStun", this.stun);
			source.PlayOneShot(closingTrap, 0.7f);
		}
        if(col.gameObject.CompareTag("Enemy")){
			col.gameObject.SendMessageUpwards("takeDamage", this.atkInfo);
			source.PlayOneShot(closingTrap, 0.7f);
		}
		Invoke("DestruirObjeto", 1.0f);
	}

	void DestruirObjeto(){
		Destroy (gameObject);
	}
}