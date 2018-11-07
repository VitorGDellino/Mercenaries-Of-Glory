using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gale : MonoBehaviour{
    private int damage = 30;
    private float galeSpeed = 8.0f;

    private float reach = 4.0f;

    private Vector3 pos;

    private Transform myTransform;
    public InfAtk atkInfo;

    private Character player;

    void Awake(){
        this.player = GetComponent<Character>();
    }

    void Start(){
        myTransform = transform;
        pos = myTransform.position;
        atkInfo = new InfAtk(damage, gameObject.tag);
    }

    void Update(){
        myTransform.Translate(new Vector3(1,0,0) * galeSpeed * Time.deltaTime);
        if(myTransform.position.x >= pos.x + reach || myTransform.position.x <= pos.x - reach){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("Player1")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
		}
		if(col.gameObject.CompareTag("Player2")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
		}
		if(col.gameObject.CompareTag("Player3")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
		}
		if(col.gameObject.CompareTag("Player4")){
			col.gameObject.SendMessageUpwards("takeDamage", this.damage);
		}
        if(col.gameObject.CompareTag("Enemy")){
			col.gameObject.SendMessageUpwards("takeDamage", this.atkInfo);
		}
	}
}