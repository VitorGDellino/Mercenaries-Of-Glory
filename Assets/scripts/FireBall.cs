using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour{

    public int damage = 25;
    public float fireBallSpeed = 8.0f;
    private float reach = 2.0f;

    private Vector3 pos;
    private Transform myTransform;
    public InfAtk atkInfo;

    void Start(){
        myTransform = transform;
        pos = myTransform.position;
        atkInfo = new InfAtk(damage, gameObject.tag);
    }

    void Update(){
        myTransform.Translate(new Vector3(1,0,0) * fireBallSpeed * Time.deltaTime);
        if(myTransform.position.x >= pos.x + reach || myTransform.position.x <= pos.x - reach){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Player1")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			Destroy (gameObject);
		}
		if(col.gameObject.CompareTag("Player2")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			Destroy (gameObject);
		}
		if(col.gameObject.CompareTag("Player3")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			Destroy (gameObject);
		}
		if(col.gameObject.CompareTag("Player4")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
			Destroy (gameObject);
		}
        if(col.gameObject.CompareTag("Enemy")){
			col.gameObject.SendMessageUpwards("takeDamage", this.atkInfo);
			Destroy (gameObject);
		}
    }
}