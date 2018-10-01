using UnityEngine;
using System.Collections;

public class SmashTrigger : MonoBehaviour{
    private Warrior player;

    void Awake(){
        this.player = GetComponentInParent<Warrior>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player") && player.gameObject != other.gameObject){
            Debug.Log(other.name);
            Debug.Log("Apanhei");
            //alterar valor pqe é mto forte o golpe e dar stun
            other.SendMessageUpwards("takeDamage", this.player.getAtk() + 20);
            // TODO stun
        }    
    }
}
