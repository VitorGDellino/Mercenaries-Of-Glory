using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour{
    private Character player;

    void Awake(){
        this.player = GetComponentInParent<Character>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player") && player.gameObject != other.gameObject){
            Debug.Log(other.name);
            Debug.Log("Apanhei");
            other.SendMessageUpwards("takeDamage", this.player.getAtk());
        }    
    }
}
